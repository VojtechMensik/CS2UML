using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmlDiagramToolsLib
{
    public abstract class DiagramBuilder
    {
        public string DiagramName { get; private set; }
        private List<Class> finishedClasses;
        public Class[] FinishedClasses { get { return finishedClasses.ToArray(); } }
        
        public ClassBuilder NewClass { get; private set; }
        //WIP
        private List<Relationship> relationships;
        private List<Message> messages;
        public DiagramBuilder(string defaultDiagramName)
        {
            DiagramName = defaultDiagramName;
            finishedClasses = new List<Class>();

            relationships = new List<Relationship>();
            messages = new List<Message>();
        }
        public Diagram Build()
        {
            return new Diagram(DiagramName,classes.ToArray(), attributes.ToArray(), methods.ToArray(), relationships.ToArray(), messages.ToArray());
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
        public void SetName(string diagramName)
        { 
            DiagramName = diagramName;
        }
    }
}
