using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSToolsLib
{
    public class CSharpFileHandler
    {
        public UmlDiagramToolsLib.Diagram[] ReadFile(Stream stream)
        {
            var cSharpSyntaxTree = CSharpSyntaxTree.ParseText("");
            using (StreamReader sr = new StreamReader(stream))
            {
               cSharpSyntaxTree = CSharpSyntaxTree.ParseText(sr.ReadToEnd());
            }
            return null;
        }
        public void WriteFile(Stream stream, UmlDiagramToolsLib.Diagram[] input)
        {

        }
        private class MainWalker : CSharpSyntaxWalker
        {
            public List<NamespaceDeclarationSyntax> namespaces;
            public MainWalker() 
            {
                namespaces = new List<NamespaceDeclarationSyntax>();
            }
            public override void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
            {
                namespaces.Add(node);
            }
        }
        private class NamespaceWalker : CSharpSyntaxWalker
        {
            public NamespaceWalker()
            {

            }
            public override void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
            {
                node.DescendantNodes();



                base.VisitNamespaceDeclaration(node);                
            }
        }
    }
}
