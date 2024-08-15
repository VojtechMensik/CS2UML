using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using UmlDiagramToolsLib;

namespace DrawioToolsLib
{
    internal class DrawioDiagramBuilder : UmlDiagramBuilder
    {
        private bool missing;
        private DrawioXmlFile file;
        public DrawioDiagramBuilder(Diagram diagram) :base("genericClass","genericAttribute","","genericMethod","","","")
        {          
            missing = false;
            List<MxCell> original = new List<MxCell>();
            foreach (MxCell cell in diagram.MxGraphModel.Root.MxCell)
            {
                if (cell.Style != null && cell.Value != null && cell.MxGeometry != null)
                {
                    if (cell.Parent != null)
                    {
                        MxCell parent = cell.Parent;
                        if(parent.Style != null && cell.Value != null && cell.MxGeometry != null)
                            original.Add(parent);
                    }
                }                                
            }
            original = original.Distinct().ToList();
            foreach (MxCell cell in original)
            {
                if (cell.Style != null && cell.Value != null && cell.MxGeometry != null)
                {
                    if (!Add(cell.Value.Replace(" ", ""), out bool newClass, out Message[] messages))
                        missing = true;
                    if (newClass)
                    {
                        ClassBuilder newClassBuilder = newClassBuilders.Last();
                        foreach (MxCell child in cell.Children)
                        {
                            if (!AddToClass(child.Value, newClassBuilder, out messages, out bool a))
                                missing = true;

                        }
                        FinishClass(newClassBuilder);
                    }
                }
            }
        }
        public override UmlDiagramToolsLib.Diagram Build()
        {

            return base.Build();
        }        


    }
}
