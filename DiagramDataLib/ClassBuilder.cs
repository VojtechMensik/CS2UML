using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UmlDiagramToolsLib.Classifier;
namespace UmlDiagramToolsLib
{
    public class ClassBuilder
    {
        private List<Attribute> attributes;
        private List<Method> methods;
        private List<Message> messages;
        public AccessModifier AccessModifierProperty { get; set; }
        public string Name { get; set; }
        public Attribute[] Attributes { get { return attributes.ToArray(); } private set { } }
        public Method[] Methods { get { return methods.ToArray(); } private set { } }
        
        public Message[] Messages { get { return messages.ToArray(); } private set { } }
        public ClassBuilder(string name, AccessModifier modifier)
        {
            Name = name;
            AccessModifierProperty = modifier;
            attributes = new List<Attribute>();
            methods = new List<Method>();
            messages = new List<Message>();
        }
        public void Add(Attribute attribute)
        {
            attributes.Add(attribute);
        }
        public void Add(Attribute[] attributes)
        {
            this.attributes.AddRange(attributes);
        }
        public void Add(Method method)
        {
            methods.Add(method);
        }
        public void Add(Method[] methods)
        {
            this.methods.AddRange(methods);
        }
        public void Add(Message message)
        {
            messages.Add(message);
        }
        public void Add(Message[] messages)
        {
            this.messages.AddRange(messages);
        }
        public Class Build()
        {
            return new Class(Name, AccessModifierProperty, Attributes, Methods, Messages);
        }
    }
}
