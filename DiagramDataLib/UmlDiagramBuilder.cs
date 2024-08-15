using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UmlDiagramToolsLib.Classifier;
using static UmlDiagramToolsLib.UmlValidator;
using static UmlDiagramToolsLib.Method;
namespace UmlDiagramToolsLib
{
    public abstract class UmlDiagramBuilder
    {
        protected List<ClassBuilder> newClassBuilders;

        private List<ClassBuilder> classBuilders;
        private List<Attribute> attributes;
        private List<Method> methods;
        private List<Relationship> relationships;
        private List<Message> messages;

        private Class defaultClass;
        private Attribute defaultAttribute;
        private Method defaultMethod;
        private MethodArgument defaultMethodArgument;
        public UmlDiagramBuilder(string defaultClassName,string defaultAttributeName,string defaultDatatype, 
            string defaultMethodName, string defaultReturnType, string defaultArgumentName, string defaultArgumentDatatype)
        {
            newClassBuilders = new List<ClassBuilder>();
            classBuilders = new List<ClassBuilder>();
            attributes = new List<Attribute>();
            methods = new List<Method>();
            relationships = new List<Relationship>();
            messages = new List<Message>();
            defaultClass = new Class(defaultClassName,AccessModifier.Public,new Attribute[0],new Method[0],new Message[0]);
            defaultAttribute = new Attribute(defaultAttributeName, AccessModifier.Public, defaultDatatype, new Message[0]);
            defaultMethod = new Method(defaultMethodName, AccessModifier.Public, defaultReturnType, new MethodArgument[0],new Message[0]);
            defaultMethodArgument = new MethodArgument(defaultArgumentName,defaultArgumentDatatype, new Message[0]);
            
        }
        public virtual Diagram Build()
        {
            Class[] classes = new Class[classBuilders.Count];
            for (int i = 0;i<classes.Length;i++)
            {
                classes[i] = classBuilders[i].Build();
            }
            return new Diagram(classes,attributes.ToArray(),methods.ToArray(),relationships.ToArray(),messages.ToArray());
        }
        protected bool Add(string umlString, out bool newClass, out Message[] messages)
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
