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
            string main = string.Format("{0} {1}", (char)AccessModifierProperty, Name);
            string datatype = string.Format(" : {0}", Datatype.Trim());
            if (Datatype.Length > 0)
                main += datatype;
            return main;
        }
    }
}
