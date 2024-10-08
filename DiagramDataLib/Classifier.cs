﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace UmlDiagramToolsLib
{
    public abstract class Classifier
    {
        public enum AccessModifier { Private='-', Public='+', Protected='#',Package='~'}
        public AccessModifier AccessModifierProperty {  get; protected set; }
        public string Name {  get; protected set; }
        public Message[] Messages { get; protected set; }
        public Classifier(string name, AccessModifier modifier, Message[] messages)
        {
            Name = name;
            AccessModifierProperty = modifier;
            Messages = messages;
        }
  
        

    }
}
