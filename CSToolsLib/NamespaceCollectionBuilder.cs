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
    public class NamespaceCollectionBuilder
    {
        public class NamespaceCollection
        {
            public IdentifierNameSyntax namespaceIdentifier { get; private set; }
            public NamespaceDeclarationSyntax[] namespaceDeclarations { get; private set; }
            public NamespaceCollection[] inserted { get; private set; }
        }
        private NamespaceDeclarationSyntax[] namespaceDeclarations;
        private IdentifierNameSyntax namespaceIdentifier;
        public NamespaceCollectionBuilder() 
        {
            
        }
        public bool CheckType()
        {
            return false;
        }
        public void Add()
        {

        }
        public void Build()
        {

        }

    }
}
