using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSToolsLib
{
    public class NamespaceCollection
    {
        public IdentifierNameSyntax namespaceIdentifier { get; private set; }
        public NamespaceDeclarationSyntax[] namespaceDeclarations { get; private set; }
        public NamespaceCollection[] inserted { get; private set; }
    }
}
