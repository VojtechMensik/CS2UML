using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using UmlDiagramToolsLib;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
namespace CSToolsLib
{
    public class CodeWriterTemp
    {        
        public ClassDeclarationSyntax Class(Class @class)
        {
            SyntaxKind accessModifier = SyntaxKind.PublicKeyword;
            switch(@class.AccessModifierProperty)
            {
                case Classifier.AccessModifier.Public:
                    accessModifier = SyntaxKind.PublicKeyword;
                    break;
                case Classifier.AccessModifier.Protected:
                    accessModifier = SyntaxKind.ProtectedKeyword;
                    break;
                case Classifier.AccessModifier.Private:
                    accessModifier = SyntaxKind.PrivateKeyword;
                    break;
                case Classifier.AccessModifier.Package:
                    accessModifier = SyntaxKind.InternalKeyword;
                    break;
            }
            ClassDeclarationSyntax classSyntax = ClassDeclaration(@class.Name);
            classSyntax.AddModifiers(Token(accessModifier));
            foreach (UmlDiagramToolsLib.Attribute attribute in @class.Attributes)
            {
                classSyntax =classSyntax.AddMembers(
                    FieldDeclaration(
                        VariableDeclaration(
                            PredefinedType(ChoosePredefinedType(attribute.Datatype)))
                        .AddVariables(VariableDeclarator(attribute.Name))
                        ));
            }
            foreach(UmlDiagramToolsLib.Method method in @class.Methods)
            {
                List<ParameterSyntax> parameterListCollection = new List<ParameterSyntax>();
                foreach (UmlDiagramToolsLib.Method.MethodArgument argument in method.Arguments)
                {
                    parameterListCollection.Add(
                        Parameter(
                            Identifier(argument.Name))
                        .WithType(
                            PredefinedType(ChoosePredefinedType(argument.DataType))
                        ));
                }
                classSyntax = classSyntax.AddMembers(
                    MethodDeclaration(
                        PredefinedType(ChoosePredefinedType(method.ReturnType)), method.Name)
                    .AddParameterListParameters(parameterListCollection.ToArray())
                    .WithBody(Block())
                    );
            }
            
            return classSyntax;
        }
        public SyntaxToken ChoosePredefinedType(string datatype)
        {
            SyntaxToken syntaxToken = Token(SyntaxKind.None);
            switch(datatype)
            {
                case "int":
                    syntaxToken = Token(SyntaxKind.IntKeyword);
                    break;
                case "float":
                    syntaxToken= Token(SyntaxKind.FloatKeyword);
                    break;
                case "double":
                    syntaxToken = Token(SyntaxKind.DoubleKeyword);
                    break;
                case "string":
                    syntaxToken = Token(SyntaxKind.StringKeyword);
                    break;
                case "bool":
                    syntaxToken = Token(SyntaxKind.BoolKeyword);
                    break;
            }

            return syntaxToken;
        }
    }
}
