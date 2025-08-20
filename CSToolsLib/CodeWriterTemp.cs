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
                            PredefinedType(ChoosePredefinedType(attribute.Datatype.Trim(), false)))
                        .AddVariables(VariableDeclarator(attribute.Name.Trim()))
                        ));
            }
            foreach(UmlDiagramToolsLib.Method method in @class.Methods)
            {
                List<ParameterSyntax> parameterListCollection = new List<ParameterSyntax>();
                foreach (UmlDiagramToolsLib.Method.MethodArgument argument in method.Arguments)
                {
                    parameterListCollection.Add(
                        Parameter(
                            Identifier(argument.Name.Trim()))
                        .WithType(
                            PredefinedType(ChoosePredefinedType(argument.DataType.Trim(), false))
                        ));
                }
                classSyntax = classSyntax.AddMembers(
                    MethodDeclaration(
                        PredefinedType(ChoosePredefinedType(method.ReturnType.Trim(),true)), method.Name.Trim())
                    .AddParameterListParameters(parameterListCollection.ToArray())
                    .WithBody(Block())
                    );
            }
            
            return classSyntax;
        }
        public SyntaxToken ChoosePredefinedType(string datatype,bool method)
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
                case "":
                    if(method)
                        syntaxToken = Token(SyntaxKind.VoidKeyword);
                    else
                        syntaxToken = Token(SyntaxKind.ObjectKeyword);
                        break;
                case "decimal":
                    syntaxToken = Token(SyntaxKind.DecimalKeyword);
                    break;
                case "byte":
                    syntaxToken = Token(SyntaxKind.ByteKeyword);
                    break;
                case "sbyte":
                    syntaxToken = Token(SyntaxKind.SByteKeyword);
                    break;
                case "short":
                    syntaxToken = Token(SyntaxKind.ShortKeyword);
                    break;
                case "ushort":
                    syntaxToken = Token(SyntaxKind.UShortKeyword);
                    break;
                case "long":
                    syntaxToken = Token(SyntaxKind.LongKeyword);
                    break;
                case "ulong":
                    syntaxToken = Token(SyntaxKind.ULongKeyword);
                    break;
                case "char":
                    syntaxToken = Token(SyntaxKind.CharKeyword);
                    break;
                case "object":
                    syntaxToken = Token(SyntaxKind.ObjectKeyword);
                    break;
            }

            return syntaxToken;
        }
    }
}
