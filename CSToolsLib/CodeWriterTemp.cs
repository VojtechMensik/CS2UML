using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UmlDiagramToolsLib;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static UmlDiagramToolsLib.Classifier;
namespace CSToolsLib
{
    public class CodeWriterTemp
    {        
        public ClassDeclarationSyntax Class(Class @class)
        {
            ClassDeclarationSyntax classSyntax = ClassDeclaration(@class.Name);
            classSyntax = classSyntax.AddModifiers(ChooseAccessModifier(@class.AccessModifierProperty));
            foreach (UmlDiagramToolsLib.Attribute attribute in @class.Attributes)
            {
                classSyntax = classSyntax.AddMembers(
                    FieldDeclaration(
                        VariableDeclaration(
                            PredefinedType(ChoosePredefinedType(attribute.Datatype.Trim(), false)))
                        .AddVariables(VariableDeclarator(attribute.Name.Trim())))
                    .WithModifiers(TokenList(ChooseAccessModifier(attribute.AccessModifierProperty))));                      
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
                    .WithModifiers(TokenList(ChooseAccessModifier(method.AccessModifierProperty)))
                    .AddParameterListParameters(parameterListCollection.ToArray())
                    .WithBody(Block())
                    );
            }
            
            return classSyntax;
        }
        public SyntaxToken ChooseAccessModifier(Classifier.AccessModifier modifier)
        {
            SyntaxToken token = Token(SyntaxKind.None);
            switch (modifier)
            {
                case Classifier.AccessModifier.Public:
                    token = Token(SyntaxKind.PublicKeyword);
                    break;
                case Classifier.AccessModifier.Protected:
                    token = Token(SyntaxKind.ProtectedKeyword);
                    break;
                case Classifier.AccessModifier.Private:
                    token = Token(SyntaxKind.PrivateKeyword);
                    break;
                case Classifier.AccessModifier.Package:
                    token = Token(SyntaxKind.InternalKeyword);
                    break;
            }
            return token;
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
                case "var":
                    syntaxToken = Token(SyntaxKind.VarKeyword);
                    break;                
            }

            return syntaxToken;
        }
    }
}
