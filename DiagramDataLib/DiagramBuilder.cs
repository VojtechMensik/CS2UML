using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmlDiagramToolsLib
{
    public abstract class DiagramBuilder
    {
        public string DiagramName { get; set; }
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
            return new Diagram(DiagramName,FinishedClasses.ToArray(), new Attribute[0], new Method[0], new Relationship[0], new Message[0]);
        }
        public void StartNewClass()
        {
            NewClass = new ClassBuilder("",Classifier.AccessModifier.Private);
        }
        public void FinishNewClass()
        {
            finishedClasses.Add(NewClass.Build());
            
        }
        


    }
}
