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
        public Attribute[] Attributes { get; private set; }
        public Method[] Methods { get; private set; }
        public Relationship[] Relationships { get; private set; }
        public Message[] Messages { get; private set; }
        public Diagram(string name,Class[] classes, Attribute[] attributes, Method[] methods, Relationship[] relationships, Message[] messages)
        {
            Name = name;
            Classes = classes;
            Attributes = attributes;
            Methods = methods;
            Relationships = relationships;
            Messages = messages;
        }

        public bool HasErrors()
        {
            return false;
        }
    }
}
