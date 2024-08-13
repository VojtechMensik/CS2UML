using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmlDiagramToolsLib
{
    public class Class : Classifier
    {
        public const string FormatUML = " {-i-} ";
        public enum Modifier { Abstract}
        public Modifier[] Modifiers { get; protected set; }
        public Attribute[] Attributes { get; protected set; }
        public Method[] Methods { get; protected set; }
        public Class(string name, AccessModifier modifier, Attribute[] attributes, Method[] methods, Message[] messages) :base(name, modifier, messages)
        {
            Attributes = attributes;
            Methods = methods;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            
            return Name;
            
        }
        
    }
}
