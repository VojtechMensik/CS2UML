using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace UmlDiagramToolsLib
{
    public class Message
    {

        public enum Category {Error,Warning, Information }
        public Category Type { get; private set; }
        public string Input { get; set; }
        public Message(Category type)
        {
            Type = type;
        }
        public Message(Category type, string input)
        {
            Type = type;
            Input = input;
        }
    }
}
