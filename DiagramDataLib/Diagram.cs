using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmlDiagramToolsLib
{
    public class Diagram
    {
        public List<Class> classes;
        public Diagram() 
        {
            classes = new List<Class>();
        }
    }
}
