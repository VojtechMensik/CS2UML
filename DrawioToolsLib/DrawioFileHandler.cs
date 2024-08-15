using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using UmlDiagramToolsLib;

namespace DrawioToolsLib
{
    public class DrawioFileHandler
    {

        private int index;
        private XmlSerializer xmlSerializer;
        private DrawioXmlFile file;
        private MxCell ClassCell()
        {
            MxCell classCell = new MxCell();
            MxGeometry classGeometry = new MxGeometry();
            classGeometry.Width = "150"; classGeometry.Height = "52"; classGeometry.As = "geometry"; classGeometry.X = "10"; classGeometry.Y = "10";
            classCell.Style = "swimlane;fontStyle=0;childLayout=stackLayout;horizontal=1;startSize=26;fillColor=none;horizontalStack=0;resizeParent=1;resizeParentMax=0;resizeLast=0;collapsible=1;marginBottom=0;whiteSpace=wrap;html=1;";
            classCell.Vertex = "1"; classCell.MxGeometry = classGeometry; classCell.ParentId = "1";
            index = 0;
            return classCell;
        }
        private MxCell AdditionCell()
        {
            MxCell additionCell = new MxCell();
            MxGeometry additionGeometry = new MxGeometry();
            additionGeometry.As = "geometry"; additionGeometry.Width = "150"; additionGeometry.Height = "26"; additionGeometry.Y = "26";
            additionCell.Style = "text;strokeColor=none;fillColor=none;align=left;verticalAlign=top;spacingLeft=4;spacingRight=4;overflow=hidden;rotatable=0;points=[[0,0.5],[1,0.5]];portConstraint=eastwest;whiteSpace=wrap;html=1;";
            additionCell.Vertex = "1"; additionCell.MxGeometry = additionGeometry;
            return additionCell;
        }
        private Diagram EmptyDiagram()
        {
            Diagram emptyDiagram = new Diagram();
            MxGraphModel model = new MxGraphModel();
            model.Dx = "1102"; model.Dy = "710"; model.Grid = "1"; model.GridSize = "10";
            model.Guides = "1"; model.Tooltips = "1"; model.Connect = "1"; model.Arrows = "1";
            model.Fold = "1"; model.Page = "1"; model.PageScale = "1"; model.PageWidth = "827"; model.PageHeight = "1169"; model.Math = "0"; model.Shadow = "0";
            emptyDiagram.MxGraphModel = model;
            Root empty = new Root();
            empty.MxCell = new List<MxCell>();
            {
                MxCell mxCell = new MxCell(); mxCell.Id = "0";
                MxCell mxCell2 = new MxCell(); mxCell2.Id = "1"; mxCell2.ParentId = "0";
                empty.MxCell.Add(mxCell); empty.MxCell.Add(mxCell2);
            }
            model.Root = empty;
            return emptyDiagram;

        }
        public DrawioFileHandler()
        {
            xmlSerializer = new XmlSerializer(typeof(DrawioXmlFile));
        }
        public bool CorrectFormat(Stream stream)
        {
            XmlReader xmlReader = XmlReader.Create(stream);
            return xmlSerializer.CanDeserialize(xmlReader);
        }
        public UmlDiagramToolsLib.Diagram[] ReadFile(Stream stream)
        {
            file = xmlSerializer.Deserialize(stream) as DrawioXmlFile;
            List<UmlDiagramToolsLib.Diagram> result = new List<UmlDiagramToolsLib.Diagram>();
            foreach (Diagram diagram in file.Diagram)
            {
                List<MxCell> mxCells = diagram.MxGraphModel.Root.MxCell;
                //parent set
                {
                    string[] id = new string[mxCells.Count];
                    for (int i = 0; i < id.Length; i++)
                        id[i] = mxCells[i].Id;
                    for (int i = 0; i < mxCells.Count; i++)
                    {
                        int indexOf = Array.IndexOf(id, mxCells[i].ParentId);
                        if (indexOf != -1)
                        {
                            mxCells[i].Parent = mxCells[indexOf];
                            mxCells[i].Parent.Children.Add(mxCells[i]);
                        }
                    }
                }
                //build diagram
                {
                    result.Add(new DrawioDiagramBuilder(diagram).Build());
                }


            }
            return result.ToArray();
        }
        public void WriteFile(Stream stream, UmlDiagramToolsLib.Diagram[] input)
        {
            int classX = 10, classY = 10;
            Diagram[] diagrams = new Diagram[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                diagrams[i] = EmptyDiagram();
                diagrams[i].Id = Id();
                diagrams[i].Name = "Diagram-"+i.ToString();
                List<MxCell> rootCells = diagrams[i].MxGraphModel.Root.MxCell;
                foreach (Class @class in input[i].Classes)
                {
                    MxCell classCell = ClassCell();
                    classCell.Value = @class.ToString();
                    classCell.Id = Id()+"-"+index.ToString();
                    classCell.MxGeometry.X = classX.ToString();
                    classCell.MxGeometry.Y = classY.ToString();
                    rootCells.Add(classCell);
                    classX += 160;
                    index++;
                    int yOffset = 16;
                    foreach(UmlDiagramToolsLib.Attribute attribute in @class.Attributes)
                    {
                        MxCell addition = AdditionCell();
                        addition.Id = Id()+"-"+index.ToString();
                        addition.Value = attribute.ToString();
                        addition.ParentId = classCell.Id;
                        addition.MxGeometry.Y = (classY + yOffset).ToString();
                        yOffset += 16;
                        index++;
                        rootCells.Add(addition);
                    }
                    foreach(Method method in @class.Methods)
                    {
                        MxCell addition = AdditionCell();
                        addition.Id= Id()+"-"+index.ToString();
                        addition.Value = method.ToString();
                        addition.ParentId = classCell.Id;
                        addition.MxGeometry.Y = (classY + yOffset).ToString();
                        yOffset += 16;
                        index++;
                        rootCells.Add(addition);
                    }
                }
                {
                    bool empty = true;
                    MxCell unsorted = ClassCell();
                    unsorted.Id = Id() + "-" + index.ToString();
                    unsorted.Value = "Generic Class";
                    unsorted.MxGeometry.X = classX.ToString();
                    unsorted.MxGeometry.Y = classY.ToString();
                    rootCells.Add(unsorted);
                    classX += 160;
                    index++;
                    int yOffset = 0;
                    foreach (UmlDiagramToolsLib.Attribute attribute in input[i].Attributes)
                    {
                        MxCell addition = AdditionCell();
                        addition.Id = Id() + "-" + index.ToString();
                        addition.Value = attribute.ToString();
                        addition.ParentId = unsorted.Id;
                        addition.MxGeometry.Y = (classY + yOffset).ToString();
                        yOffset += 16;
                        index++;
                        rootCells.Add(addition);
                        empty = false;
                    }
                    foreach(UmlDiagramToolsLib.Method method in input[i].Methods)
                    {
                        MxCell addition = AdditionCell();
                        addition.Id = Id() + "-" + index.ToString();
                        addition.Value = method.ToString();
                        addition.ParentId = unsorted.Id;
                        addition.MxGeometry.Y = (classY + yOffset).ToString();
                        yOffset += 16;
                        index++;
                        rootCells.Add(addition);
                        empty = false;
                    }
                    if(empty)
                        rootCells.Remove(unsorted);
                    
                }
            }
            file.Diagram.Clear();
            file.Diagram.AddRange(diagrams);
            xmlSerializer.Serialize(stream, file);

        }
        private string Id()
        {
            return Guid.NewGuid().ToString();
        }

    }
}
