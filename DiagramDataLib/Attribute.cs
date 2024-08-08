using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace UmlDiagramToolsLib
{
    public class Attribute : Classifier
    {
        public const string FormatUML = "{-i-}:{+o-}";
        public string Datatype {  get; protected set; }
        public Attribute(string name, AccessModifier modifier, string datatype, Message[] messages) :base(name,modifier, messages)
        {
            Datatype = datatype;
        }
        public override string ToString()
        {
            return string.Format("{0} {1} : {2}",(char)AccessModifierProperty,Name,Datatype);
        }
        public static bool Validate(string input, out Attribute attribute)
        {                        
            AccessModifier modifier;
            attribute = null;
            string datatype;
            string name;
            input = input.Replace(" ", "");
            //if(!ValidateAccessModifier(input[0],out modifier))
                return false;
            input = input.Remove(0,1);
            string[] split = input.Split(':');
            if(split.Length != 2)           
                return false;    
            foreach(string s in split)
            /*    if(ValidateText(s) == false) return false;
            attribute = new Attribute(split[0], modifier, split[1]);*/
            return true;           
        }
    }
}
