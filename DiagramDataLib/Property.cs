﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmlDiagramToolsLib
{
    public class Property : Attribute
    {
        public Property() : base("",new Classifier.AccessModifier(),"")
        {
            throw new NotImplementedException();
        }
    }
}
