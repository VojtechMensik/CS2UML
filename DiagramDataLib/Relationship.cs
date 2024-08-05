using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmlDiagramToolsLib
{
    public class Relationship
    {
        public enum Type{Association,Inheritance,Implementation,Dependency,Aggregation}
        public struct Connection
        {
            public Connection(Class @class, bool multiplicity, int min, int max, bool pointedAt)
            {
                Class = @class;
                Multiplicity = multiplicity;
                Min = min;
                Max = max;
                PointedAt = pointedAt;
            }

            public Class Class { get; private set; }
            public bool Multiplicity { get; private set; }
            public int Min { get; private set; }
            public int Max { get; private set; }
            public bool PointedAt { get; private set; }
        }
        public Connection[] Connections { get; set; }
        public Message Messages { get; set; }
        public Relationship(Connection[] connections, Message messages)
        {
            Connections = connections;
            Messages = messages;
        }
    }
}
