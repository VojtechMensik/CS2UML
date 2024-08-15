using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCodeLib
{
    public class ClassWalker : CSharpSyntaxWalker
    {
        public List<StringBuilder> List { get; private set; }
        public StringBuilder StringBuilder { get; private set; }
        public ClassWalker() :base(SyntaxWalkerDepth.Node)
        {
            List = new List<StringBuilder>();
            StringBuilder = new StringBuilder();
        }
        public override void VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            StringBuilder.Append(node.ToString());            
            base.VisitClassDeclaration(node);
        }
        
    }
    public class UtilSyntaxtRewriter : CSharpSyntaxRewriter
    {
        public List<SyntaxNode> List { get; private set; }
        public UtilSyntaxtRewriter()
        {
            List = new List<SyntaxNode>();
        }
        public override SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            
            List.Add(node);
            foreach (SyntaxNode innerNode in node.DescendantNodes())
            {
                Visit(innerNode);
            }
            return null;
        }
        public SyntaxNode[] GrabClass(SyntaxNode node)
        {
            List.Clear();
            Visit(node);
            return List.ToArray();
        }
    }
    public class UtilSyntaxtWalker : CSharpSyntaxWalker
    {
        public UtilSyntaxtWalker() : base(SyntaxWalkerDepth.Token)
        {

        }
    }

}
