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
    public class NamespaceCollector
    {
        

        private NamespaceSeeker namespaceSeeker;
        public List<NamespaceDeclarationSyntax> storedNamespaceNodes;

        public NamespaceCollector()
        {
            namespaceSeeker = new NamespaceSeeker();
            storedNamespaceNodes = new List<NamespaceDeclarationSyntax>();
        }
        public void CollectNamespaces(SyntaxNode rootNode)
        {
            namespaceSeeker.Visit(rootNode);
            storedNamespaceNodes.AddRange(namespaceSeeker.GetStoredNamespaceNodes());
            

        }
        

    }
    
}
