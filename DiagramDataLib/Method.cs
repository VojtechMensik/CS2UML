using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UmlDiagramToolsLib
{
    public class Method : Classifier
    {
        public const string FormatUML = "{-i+}({-o-}{-v+}):{+o}";
        
        public struct MethodArgument
        {
            public const string FormatUML = "{-i-}:{+o-},{+l-}";
            public string Name { get; set; }
            public string DataType { get; set; }
            public MethodArgument(string name, string dataType)
            {
                Name = name;
                DataType = dataType;
            }
            public override string ToString()
            {
                return Name + " : " + DataType;
            }
        }
        public string ReturnType {  get; set; }
        public MethodArgument[] Arguments { get; set; }
        public Method(string name, AccessModifier modifier, string returnType, MethodArgument[] arguments, Message[] messages) :base(name,modifier, messages) 
        {
            ReturnType = returnType;
            Arguments = arguments;
        }
        public override string ToString()
        {
            string parameters = "";
            if(Arguments.Length > 0)
            {
                parameters = Arguments[0].ToString();
                for (int i = 1; i < Arguments.Length; i++)
                {
                    parameters += ", " + Arguments[i].ToString();
                }
            }
            return string.Format("{0} {1}({3}) : {4}",(char)AccessModifierProperty,Name,parameters,ReturnType);
        }
        
    }
}
