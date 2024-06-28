using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramDataLib
{
    internal class Relationship
    {
        public Class ParentClass { get; protected set; }
        public Class ChildClass { get; protected set; }
        public Relationship() 
        {
            
        }
    }
}
