using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UmlDiagramToolsLib
{
    public class Method : Classifier
    {
        public const string FormatUML = "{i}({o}):{-o}";
        
        public struct MethodArgument
        {
            public const string FormatUML = "{i}:{-o},{-l}";
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
        public static bool Validate(string input, out Method method)
        {
            input = input.Replace(" ", "");
            AccessModifier modifier;
            method = null;
            string datatype;
            string name;


            //ValidateAccessModifier(input[0], out modifier);
            input = input.Remove(0, 1);
            
            string[] split = input.Split('(',')');

            string[] arguments = split[2].Split(':',',');
            MethodArgument[] methodArguments = new MethodArgument[arguments.Length / 2];
            for (int i = 0;i<arguments.Length;i+=2)
            {
                methodArguments[i / 2] = new MethodArgument(arguments[i], arguments[i+1]);
            }
            //method = new Method(split[0], modifier, split[3],methodArguments);
            return true;
        }
    }
}
