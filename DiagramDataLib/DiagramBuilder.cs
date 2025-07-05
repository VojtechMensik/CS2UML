using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UmlDiagramToolsLib.Classifier;
namespace UmlDiagramToolsLib
{
    public abstract class DiagramBuilder
    {
        //výchozí hodnoty
        /// <summary>
        /// 
        /// </summary>
        private AccessModifier defClassAccMod;
        private string defClassName;
        private int id;
        //
        public string DiagramName { get; set; }
        private List<Message> diagramMessages;
        private List<Class> finishedClasses;
        private List<ClassBuilder> unfinishedClasses;
        public Class[] FinishedClasses { get { return finishedClasses.ToArray(); } }        
        public ClassBuilder[] UnfinishedClasses { get { return unfinishedClasses.ToArray(); } }        
        public DiagramBuilder(string defaultDiagramName, AccessModifier defaultClassAccessModifier, string defaultClassName = "Class")
        {

            //výchozí hodnoty
            id = 1;
            DiagramName = defaultDiagramName;
            defClassAccMod = defaultClassAccessModifier;
            defClassName = defaultClassName;
            //inicializace
            finishedClasses = new List<Class>();
            unfinishedClasses = new List<ClassBuilder>();
            diagramMessages = new List<Message>();
        }        
        public ClassBuilder StartNewClass()
        {
            ClassBuilder classBuilder = new ClassBuilder(defClassName, defClassAccMod);
            return classBuilder;
        }
        public void FinishClass(ClassBuilder unfinishedClass)
        {
            if(unfinishedClasses.Remove(unfinishedClass))
            {
                if (unfinishedClass.Name == defClassName)
                {
                    unfinishedClass.Name += id.ToString();
                    id++;
                }
                finishedClasses.Add(unfinishedClass.Build());
                return;
            }
            throw new ArgumentException("classBuilder instance must be present inside unfinishedClasses collection to be finished", "classBuilder");
            
        }
        public Diagram Build()
        {            
            return new Diagram(DiagramName, FinishedClasses.ToArray(),
                new Attribute[0], new Method[0], new Relationship[0],
                diagramMessages.ToArray());
        }
        public void ClearData()
        {
            finishedClasses.Clear();
            unfinishedClasses.Clear();
            diagramMessages.Clear();
        }
    }
}
