using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using UmlDiagramToolsLib;
namespace CSToolsLib
{
    public class ClassWalker : CSharpSyntaxWalker
    {
        private ClassBuilder classBuilder;
        public ClassWalker() : base (SyntaxWalkerDepth.Node)
        {
            
        }
        public override void VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            string name = "defaultName"; Classifier.AccessModifier modifier = Classifier.AccessModifier.Private;
            SyntaxToken[] childTokens = node.ChildTokens().ToArray();
            foreach (SyntaxToken token in childTokens)
            {
                switch (token.Kind())
                {
                    case SyntaxKind.IdentifierToken:
                        name = token.Text;
                        break;
                    case SyntaxKind.PrivateKeyword:
                        modifier = Classifier.AccessModifier.Private;
                        break;
                    case SyntaxKind.ProtectedKeyword:
                        modifier = Classifier.AccessModifier.Protected;
                        break;
                    case SyntaxKind.PublicKeyword:
                        modifier = Classifier.AccessModifier.Public;
                        break;
                    case SyntaxKind.InternalKeyword:
                        modifier = Classifier.AccessModifier.Package;
                        break;
                }
            }
            classBuilder = new ClassBuilder(name, modifier);
            base.VisitClassDeclaration(node);
        }
        public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            string name = "defaultName"; Classifier.AccessModifier modifier = Classifier.AccessModifier.Private; string returnType = "";
            List<Method.MethodArgument> arguments = new List<Method.MethodArgument>();
            foreach (SyntaxToken token in node.ChildTokens().ToArray())
            {
                switch (token.Kind())
                {
                    case SyntaxKind.IdentifierToken:
                        name = token.Text;
                        break;
                    case SyntaxKind.PrivateKeyword:
                        modifier = Classifier.AccessModifier.Private;
                        break;
                    case SyntaxKind.ProtectedKeyword:
                        modifier = Classifier.AccessModifier.Protected;
                        break;
                    case SyntaxKind.PublicKeyword:
                        modifier = Classifier.AccessModifier.Public;
                        break;
                    case SyntaxKind.InternalKeyword:
                        modifier = Classifier.AccessModifier.Package;
                        break;
                }
            }
            foreach (SyntaxNode syntaxNode in node.ChildNodes().ToArray())
            {
                switch (syntaxNode.Kind())
                {
                    case SyntaxKind.PredefinedType:
                        returnType = syntaxNode.GetFirstToken().Text;
                        break;
                    case SyntaxKind.ParameterList:                        
                        foreach(SyntaxNode parameter in syntaxNode.ChildNodes().ToArray())
                        {
                            string argName, argType;
                            argName = parameter.ChildTokens().First().Text;
                            argType = parameter.ChildNodes().First().GetFirstToken().Text;
                            arguments.Add(new Method.MethodArgument(argName, argType, new Message[0]));
                        }
                        break;
                }
            }
            Method method = new Method(name,modifier,returnType,arguments.ToArray(), new Message[0]);
            classBuilder.Add(method);
        }
        public override void VisitFieldDeclaration(FieldDeclarationSyntax node)
        {
            string name = "defaultName", dataType = ""; Classifier.AccessModifier modifier = Classifier.AccessModifier.Private;
            foreach (SyntaxToken token in node.ChildTokens().ToArray())
            {
                switch (token.Kind())
                {
                    case SyntaxKind.PrivateKeyword:
                        modifier = Classifier.AccessModifier.Private;
                        break;
                    case SyntaxKind.ProtectedKeyword:
                        modifier = Classifier.AccessModifier.Protected;
                        break;
                    case SyntaxKind.PublicKeyword:
                        modifier = Classifier.AccessModifier.Public;
                        break;
                    case SyntaxKind.InternalKeyword:
                        modifier = Classifier.AccessModifier.Package;
                        break;
                }
            }
            foreach (SyntaxNode syntaxNode in node.ChildNodes().First().ChildNodes())
            {
                switch (syntaxNode.Kind())
                {
                    case SyntaxKind.VariableDeclarator:
                        name = syntaxNode.GetFirstToken().Text;
                        break;
                    case SyntaxKind.PredefinedType:
                        dataType = syntaxNode.GetFirstToken().Text;
                        break;
                }
            }
            UmlDiagramToolsLib.Attribute attribute = new UmlDiagramToolsLib.Attribute(name,modifier,dataType,new Message[0]);
            classBuilder.Add(attribute);
        }
        public UmlDiagramToolsLib.Class GetClass()
        {
            return classBuilder.Build();
        }
    }
    
}
