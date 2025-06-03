using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSToolsLib
{
    public class NamespaceWalker : CSharpSyntaxWalker
    {
        public string s;
        public NamespaceWalker() : base(SyntaxWalkerDepth.Node)
        {
            s = "";
        }
        public override void Visit(SyntaxNode node)
        {
            base.Visit(node);
        }
        public override void VisitIdentifierName(IdentifierNameSyntax node)
        {
            s += node.Identifier.ToString() + " " + node.Kind().ToString() + "\n";
            base.VisitIdentifierName(node);
        }
    }
}
