using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
namespace CSToolsLib
{
    public class NamespaceWalker : CSharpSyntaxWalker
    {
        public NamespaceWalker() : base(SyntaxWalkerDepth.Node)
        {

        }
        public override void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
        {
            base.VisitNamespaceDeclaration(node);
        }
    }

}


