using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UmlDiagramToolsLib.Classifier;

namespace UmlDiagramToolsLib
{
    public abstract class UmlDiagramBuilder
    {
        private List<Class> classes;
        private List<Attribute> attributes;
        private List<Method> methods;
        private List<Relationship> relationships;
        private List<Message> messages;
        public UmlDiagramBuilder()
        {
            classes = new List<Class>();
            attributes = new List<Attribute>();
            methods = new List<Method>();
            relationships = new List<Relationship>();
            messages = new List<Message>();
        }
        public Diagram Build()
        {
            return new Diagram(classes.ToArray(),attributes.ToArray(),methods.ToArray(),relationships.ToArray(),messages.ToArray());
        }
        public void Add(Class @class)
        {

        }
        


    }
}
