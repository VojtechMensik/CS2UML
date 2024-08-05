using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmlDiagramToolsLib
{
    public abstract class DiagramBuilder
    {

        private List<Class> classes;
        private List<Attribute> attributes;
        private List<Method> methods;
        private List<Relationship> relationships;
        private List<Message> messages;
        public DiagramBuilder()
        {
            classes = new List<Class>();
            attributes = new List<Attribute>();
            methods = new List<Method>();
            relationships = new List<Relationship>();
            messages = new List<Message>();
        }
        public Diagram Build()
        {
            return new Diagram(classes.ToArray(), attributes.ToArray(), methods.ToArray(), relationships.ToArray(), messages.ToArray());
        }
        public void Add(Class @class)
        {
            classes.Add(@class);
        }
        public void Add(Classifier classifier)
        {
            if (classifier is Class)
                Add(classifier as Class);
            
        }
    }
}
