using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UmlDiagramToolsLib.Classifier;
using static UmlDiagramToolsLib.UmlValidator;
using static UmlDiagramToolsLib.Method;
using Microsoft.CodeAnalysis.CSharp.Syntax;
namespace UmlDiagramToolsLib
{
    public abstract class UmlDiagramBuilder : DiagramBuilder
    {
        /// <summary>
        /// Prvky v diagramu (co nejsou třída) a nemají vazbu na žádnou třídu
        /// </summary>
        private ClassBuilder root;
        //výchozí hodnoty
        private string defAttributeName;
        private string defAttributeType;
        private string defMethodName;
        private string defMethodType;
        private string defReturnType;
        private string defArgumentName;
        private string defArgumentType;

        public UmlDiagramBuilder(string defaultDiagramName, AccessModifier defaultClassAccess, 
            string defaultClass = "Class",
            string defaultAttr = "attribute",string defaultAttrType = "", 
            string defaultMethod="Method", string defaultReturn="", string defaultArgName="", string defaultArgType = "")
            :base(defaultDiagramName,defaultClassAccess,defaultClass)
        {
            root = new ClassBuilder();
            defAttributeName = defaultAttr;
            defAttributeType = defaultAttrType;
            defMethodName = defaultMethod;
            defReturnType = defaultReturn;
            defArgumentName = defaultArgName;
            defArgumentType = defaultArgType;
        }
        protected bool AddUmlToDiagram(string umlString,out Message[] messages, ClassBuilder addToClass = null)
        {       
            //Co s těma Message??
            messages = new Message[0];
            if (addToClass is null)
                addToClass = root;            
            if(Validate(defClassName,umlString,out ClassBuilder classBuilder,out messages))
            {
                ClassBuilder newClass = StartNewClass();
                newClass = classBuilder;
                return true;
            }
            if(Validate(defAttributeName, defAttributeType, umlString, out Attribute attribute, out messages))
            {
                addToClass.Add(attribute);
                return true;
            }
            if(Validate(defMethodName,defReturnType,defArgumentName,defArgumentType,
                umlString,out Method method,out messages))
            {
                addToClass.Add(method);
                return true;
            }
            this.diagramMessages.AddRange(messages);
            return false;
        }
        protected override void ClearDiagramData()
        {
            root = new ClassBuilder();
            base.ClearDiagramData();
        }
    }
}
