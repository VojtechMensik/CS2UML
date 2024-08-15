using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
//http://xmltocsharp.azurewebsites.net/
namespace DrawioToolsLib
{
    [XmlRoot(ElementName = "mxGeometry")]
    public class MxGeometry
    {
        
        [XmlAttribute(AttributeName = "x")]
        public string X { get; set; }
        [XmlAttribute(AttributeName = "y")]
        public string Y { get; set; }
        [XmlAttribute(AttributeName = "width")]
        public string Width { get; set; }
        [XmlAttribute(AttributeName = "height")]
        public string Height { get; set; }
        [XmlAttribute(AttributeName = "as")]
        public string As { get; set; }
    }


    [XmlRoot(ElementName = "mxCell")]
    public class MxCell
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "parent")]
        public string ParentId { get; set; }
        public MxCell Parent { get; set; }
        public List<MxCell> Children { get; set; }
        [XmlElement(ElementName = "mxGeometry")]
        public MxGeometry MxGeometry { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
        [XmlAttribute(AttributeName = "style")]
        public string Style { get; set; }
        [XmlAttribute(AttributeName = "vertex")]
        public string Vertex { get; set; }        
    }

    [XmlRoot(ElementName = "root")]
    public class Root
    {
        [XmlElement(ElementName = "mxCell")]
        public List<MxCell> MxCell { get; set; }
    }

    [XmlRoot(ElementName = "mxGraphModel")]
    public class MxGraphModel
    {
        [XmlElement(ElementName = "root")]
        public Root Root { get; set; }
        [XmlAttribute(AttributeName = "dx")]
        public string Dx { get; set; }
        [XmlAttribute(AttributeName = "dy")]
        public string Dy { get; set; }
        [XmlAttribute(AttributeName = "grid")]
        public string Grid { get; set; }
        [XmlAttribute(AttributeName = "gridSize")]
        public string GridSize { get; set; }
        [XmlAttribute(AttributeName = "guides")]
        public string Guides { get; set; }
        [XmlAttribute(AttributeName = "tooltips")]
        public string Tooltips { get; set; }
        [XmlAttribute(AttributeName = "connect")]
        public string Connect { get; set; }
        [XmlAttribute(AttributeName = "arrows")]
        public string Arrows { get; set; }
        [XmlAttribute(AttributeName = "fold")]
        public string Fold { get; set; }
        [XmlAttribute(AttributeName = "page")]
        public string Page { get; set; }
        [XmlAttribute(AttributeName = "pageScale")]
        public string PageScale { get; set; }
        [XmlAttribute(AttributeName = "pageWidth")]
        public string PageWidth { get; set; }
        [XmlAttribute(AttributeName = "pageHeight")]
        public string PageHeight { get; set; }
        [XmlAttribute(AttributeName = "math")]
        public string Math { get; set; }
        [XmlAttribute(AttributeName = "shadow")]
        public string Shadow { get; set; }
    }

    [XmlRoot(ElementName = "diagram")]
    public class Diagram
    {
        [XmlElement(ElementName = "mxGraphModel")]
        public MxGraphModel MxGraphModel { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "mxfile")]
    public class DrawioXmlFile
    {
        [XmlElement(ElementName = "diagram")]
        public List<Diagram> Diagram { get; set; }
        [XmlAttribute(AttributeName = "host")]
        public string Host { get; set; }
        [XmlAttribute(AttributeName = "modified")]
        public string Modified { get; set; }
        [XmlAttribute(AttributeName = "agent")]
        public string Agent { get; set; }
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }
        [XmlAttribute(AttributeName = "etag")]
        public string Etag { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        
    }

}
