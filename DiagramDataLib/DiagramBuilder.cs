using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UmlDiagramToolsLib.Classifier;
using static UmlDiagramToolsLib.Method;
namespace UmlDiagramToolsLib
{
    public abstract class DiagramBuilder
    {
        //výchozí hodnoty
        //private protected -> jako protected, ale pouze v rámci sestavy (namespace)
        /// <summary>
        /// 
        /// </summary>
        private protected string defDiagramName;
        private protected AccessModifier defClassAccess;
        private protected string defClassName;
        private protected int id;
        //        
        private protected List<Message> diagramMessages;
        private List<Class> finishedClasses;        
        private List<ClassBuilder> unfinishedClasses;
        protected string DiagramName { get; set; }
        protected Class[] FinishedClasses { get { return finishedClasses.ToArray(); } }        
        protected ClassBuilder[] UnfinishedClasses { get { return unfinishedClasses.ToArray(); } }        
        public DiagramBuilder(string defaultDiagramName, AccessModifier defaultClassAccess, string defaultClass = "Class")
        {

            //výchozí hodnoty
            id = 1;
            defDiagramName = defaultDiagramName;
            defClassAccess = defaultClassAccess;
            defClassName = defaultClass;
            //inicializace
            DiagramName = defaultDiagramName;
            finishedClasses = new List<Class>();
            unfinishedClasses = new List<ClassBuilder>();
            diagramMessages = new List<Message>();
        }        
        protected ClassBuilder StartNewClass()
        {
            ClassBuilder classBuilder = new ClassBuilder(defClassName, defClassAccess);
            unfinishedClasses.Add(classBuilder);
            return classBuilder;
        }
        protected void FinishClass(ClassBuilder unfinishedClass)
        {
            if(unfinishedClasses.Remove(unfinishedClass))
            {
                //*E--dosazení výchozích hodnot
                if (unfinishedClass.Name == defClassName)
                {
                    unfinishedClass.Name += id.ToString();
                    id++;
                }
                finishedClasses.Add(unfinishedClass.Build());
                return;
            }
            //TODO - objasnit exception
            //Není to třída na které je pracováné
            throw new ArgumentException("classBuilder instance must be present inside unfinishedClasses collection to be finished", "classBuilder");            
        }        
        protected virtual void ClearDiagramData()
        {
            DiagramName = defDiagramName;
            finishedClasses.Clear();
            unfinishedClasses.Clear();
            diagramMessages.Clear();
        }
        public virtual Diagram Build()
        {
            //finish all
            foreach (ClassBuilder classBuilder in unfinishedClasses)
            { FinishClass(classBuilder); }
            return new Diagram(DiagramName, FinishedClasses.ToArray(),
                new Relationship[0], diagramMessages.ToArray());
        }
    }
}
