using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CS2UML
{
    [XmlRoot("mxfile")]
    public class XmlFile
    {
        [XmlElement("diagram")]
        public Diagram[] Diagram {  get; set; }
        [XmlElement("host")]
        public string Host { get; set; }
        [XmlElement("modified")]
        public string Modified { get; set; }
        [XmlElement("agent")]
        public string Agent { get; set; }
        [XmlElement("etag")]
        public string ETag { get; set; }
        [XmlElement("version")]
        public string Version { get; set; }
        [XmlElement("type")]
        public string Type { get; set; }
    }
    public class Diagram
    {
        [XmlElement("id")]
        public string ID { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
    }
    public class GraphModel
    {

    }
    public class Root
    {

    }
}
