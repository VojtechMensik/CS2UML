using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UmlDiagramToolsLib.Classifier;

namespace UmlDiagramToolsLib
{
    public abstract class UmlDiagramBuilder
    {
        private List<Class> classes;
        private List<Attribute> attributes;
        private List<Method> methods;
        private List<Relationship> relationships;
        private List<Message> messages;
        public UmlDiagramBuilder()
        {
            classes = new List<Class>();
            attributes = new List<Attribute>();
            methods = new List<Method>();
            relationships = new List<Relationship>();
            messages = new List<Message>();
        }
        public Diagram Build()
        {
            return new Diagram(classes.ToArray(),attributes.ToArray(),methods.ToArray(),relationships.ToArray(),messages.ToArray());
        }
        public void Add(Class @class)
        {

        }
        

        /*private static bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }
        private static bool ValidateName(string input)
        {
            input = input.ToLower();
            if (!((input[0] >= 'a' && input[0] <= 'z') || input[0] == '_'))
                return false;
            for(int i = 1;i<input.Length;i++)
            { 
                if (!((input[i] >= 'a' && input[i] <= 'z') || input[i] == '_' || IsDigit(input[i])))
                    return false;
            }
            return true;
        }
        private static bool ValidateAccessModifier(char input, out AccessModifier modifier)
        {
            modifier = AccessModifier.Private;
            switch (input)
            {
                case (char)AccessModifier.Public:
                case (char)AccessModifier.Protected:
                case (char)AccessModifier.Private:
                    modifier = (AccessModifier)input;
                    break;
                default:
                    return false;
            }
            return true;
        }
        private static bool IsClass(string input)
        {
            return false; 
        }
        public static Classifier Validate(string input)
        {
            return null;
        }*/

    }
}
