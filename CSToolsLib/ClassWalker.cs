using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
namespace CSToolsLib
{
    public class ClassWalker : CSharpSyntaxWalker
    {

        public ClassWalker() : base (SyntaxWalkerDepth.Node)
        {            
        }
        public override void Visit(SyntaxNode node)
        {

            base.Visit(node);
            
        }
    }
}
