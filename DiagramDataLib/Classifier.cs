using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DiagramDataLib
{
    public abstract class Classifier
    {
        public enum AccessModifier { Private='-', Public='+', Protected='#',Package='~'}
        public AccessModifier AccessModifierProperty {  get; protected set; }
        public string Name {  get; protected set; } 
        public List<>
        public Classifier(string name, AccessModifier modifier)
        {
            Name = name;
            AccessModifierProperty = modifier;
        }
        

    }
}
