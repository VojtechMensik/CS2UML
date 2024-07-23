using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmlDiagramToolsLib
{
    public class Class : Classifier
    {
        public const string FormatUML = "{0}";
        public enum Modifier { Abstract}

        public Attribute[] attributes;
        public Method[] methods;
        public Class(string name, AccessModifier modifier, Attribute[] attributes, Method[] methods) :base(name, modifier)
        {
            this.attributes = attributes;
            this.methods = methods;
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
