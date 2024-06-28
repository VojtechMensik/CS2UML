using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DrawioToolsLib
{
    public class XmlDiagramMaker
    {
        private IdManager idManager;
        private XmlSerializer serializer;
        public XmlDiagramMaker() 
        {
            serializer = new XmlSerializer(typeof(Mxfile));
        }
        public Mxfile Make(Stream stream)
        {
            Mxfile mxfile = (Mxfile)serializer.Deserialize(stream);
            return mxfile;
        }
    }
}
