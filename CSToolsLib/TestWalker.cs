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
    public class TestWalker : CSharpSyntaxWalker
    {
        public List<string> nodesOut = new List<string>();
        public TestWalker() : base (SyntaxWalkerDepth.Node)
        {
        
        }
        public override void Visit(SyntaxNode node)
        {
            nodesOut.Add(node.GetFirstToken().ToString());
            base.Visit(node);
        }
    }
}
