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
        protected List<ClassBuilder> newClassBuilders;
        private List<ClassBuilder> classBuilders;
        //root non-class clasifiers
        private List<Attribute> attributes;
        private List<Method> methods;
        //
        private List<Relationship> relationships;
        private List<Message> messages;
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
            newClassBuilders = new List<ClassBuilder>();
            classBuilders = new List<ClassBuilder>();
            attributes = new List<Attribute>();
            methods = new List<Method>();
            relationships = new List<Relationship>();
            messages = new List<Message>();
            defAttributeName = defaultAttr;
            defAttributeType = defaultAttrType;
            defMethodName = defaultMethod;
            defReturnType = defaultReturn;
            defArgumentName = defaultArgName;
            defArgumentType = defaultArgType;
        }
        public virtual Diagram Build()
        {
            Class[] classes = new Class[classBuilders.Count];
            for (int i = 0;i<classes.Length;i++)
            {
                classes[i] = classBuilders[i].Build();
            }
            return new Diagram(DiagramName,classes,relationships.ToArray(),messages.ToArray());
        }
        protected bool AddToDiagram(string umlString, out bool newClass, out Message[] messages)
        {
            Message[] messages1; messages = new Message[0];            
            ClassBuilder classBuilder; Attribute attribute; Method method;
            newClass = false;
            if(Validate(defaultClass.Name,umlString, out classBuilder,out messages1))
            {
                newClass = true;
                messages = messages1;
                newClassBuilders.Add(classBuilder);
                return true;
            }
            if(Validate(defaultAttribute.Name,defaultAttribute.Datatype,umlString, out attribute,out messages1))
            {
                messages = messages1;
                attributes.Add(attribute);
                return true;
            }
            if(Validate(defaultMethod.Name,defaultMethod.ReturnType,defaultMethodArgument.Name,defaultMethodArgument.DataType,umlString, out method,out messages1))
            {
                messages = messages1;
                methods.Add(method);
                return true;
            }
            return false;
        }
        protected bool AddToClass(string umlString, ClassBuilder classBuilder,out Message[] messages,out bool newClass)
        {
            Message[] messages1; messages = new Message[0];
            Attribute attribute; Method method; newClass = false;
            ClassBuilder newClassBuilder;
            if (Validate(defaultClass.Name, umlString, out newClassBuilder, out messages1))
            {
                messages = messages1;
                newClass = true;
                newClassBuilders.Add(newClassBuilder);
                return false;
            }
            if (Validate(defaultAttribute.Name, defaultAttribute.Datatype, umlString, out attribute, out messages1))
            {
                messages = messages1;
                classBuilder.Add(attribute);               
                return true;
            }
            if (Validate(defaultMethod.Name, defaultMethod.ReturnType, defaultMethodArgument.Name, defaultMethodArgument.DataType, umlString, out method, out messages1))
            {
                messages = messages1;
                classBuilder.Add(method);
                return true;
            }
            return false;
        }
        protected void FinishClass(ClassBuilder classBuilder)
        {
            newClassBuilders.Remove(classBuilder);
            classBuilders.Add(classBuilder);
        }
        


    }
}
