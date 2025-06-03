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
    public class NamespaceSeeker : CSharpSyntaxWalker
    {
        private List<NamespaceDeclarationSyntax> storedNamespaceNodes;

        public NamespaceSeeker() : base(SyntaxWalkerDepth.Node)
        {
            storedNamespaceNodes = new List<NamespaceDeclarationSyntax>();
        }
        public override void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
        {
            storedNamespaceNodes.Add(node);            
        }
        public NamespaceDeclarationSyntax[] GetStoredNamespaceNodes()
        {
            NamespaceDeclarationSyntax[] returnArray = storedNamespaceNodes.ToArray();
            storedNamespaceNodes.Clear();
            return returnArray;
        }
    }

}


