using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UmlDiagramToolsLib
{
    public class Diagram
    {
        public string Name { get; private set; }
        public Class[] Classes { get; private set; }
        public Relationship[] Relationships { get; private set; }
        public Message[] Messages { get; private set; }
        public Diagram[] diagrams { get; private set; }
        public Diagram(string name,Class[] classes, Relationship[] relationships, Message[] messages)
        {
            Name = name;
            Classes = classes;
            Relationships = relationships;
            Messages = messages;
        }

        public bool HasErrors()
        {
            return false;
        }
    }
}
