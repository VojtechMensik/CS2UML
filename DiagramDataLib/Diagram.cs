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
        public Class[] Classes { get; private set; }
        public Attribute[] Attributes { get; private set; }
        public Method[] Methods { get; private set; }
        public Relationship[] Relationships { get; private set; }
        public Message[] Messages { get; private set; }
        public Diagram(Class[] classes, Attribute[] attributes, Method[] methods, Relationship[] relationships, Message[] messages)
        {
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
