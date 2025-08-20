using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace UmlDiagramToolsLib
{
    public class Attribute : Classifier
    {
        public const string FormatUML = " {-i-}:{+o-} ";
        public string Datatype {  get; protected set; }
        public Attribute(string name, AccessModifier modifier, string datatype, Message[] messages) :base(name,modifier, messages)
        {
            Datatype = datatype;
        }
        public override string ToString()
        {
            return string.Format("{0} {1} : {2}",(char)AccessModifierProperty,Name,Datatype);
        }
    }
}
