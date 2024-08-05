using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawioToolsLib
{
    class DrawioDiagramBuilder 
    {
        public Diagram[] Diagrams { get; private set; }
        public DrawioDiagramBuilder(DrawioXmlFile file) 
        {
            foreach(Diagram diagram in file.Diagram)
            {
                //diagram.MxGraphModel.Root.MxCell[0];
            }
        }
        
        
    }
}
