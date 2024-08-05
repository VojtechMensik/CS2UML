using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UmlDiagramToolsLib.Classifier;
namespace UmlDiagramToolsLib
{
    internal class UmlValidator
    {
        private struct FormatItem
        {
            public enum Type { Item = 'i', Optional = 'o', Loop = 'l', Validate = 'v' }
            public Type type;
            public bool validateLeft;
            public bool validateRight;
            FormatItem(string s)
            {
                type = (Type)s[2];
                validateLeft = s[1] == '+';
                validateRight = s[3] == '+';
            }
            public override string ToString()
            {
                string s = "{";
                if (validateLeft)
                {
                    s = s + '+';
                }
                else
                    s = s + "-";
                s = s + type;
                if (validateRight)
                {
                    s = s + '+';
                }
                else
                {
                    s = s + "-";
                }
                s += "}";
                return type.ToString();
            }
            private static bool ValidateAccessModifier(char input, out AccessModifier modifier)
            {
                modifier = AccessModifier.Private;
                switch (input)
                {
                    case (char)AccessModifier.Public:
                    case (char)AccessModifier.Protected:
                    case (char)AccessModifier.Private:
                        modifier = (AccessModifier)input;
                        break;
                    default:
                        return false;
                }
                return true;
            }
            private static bool DeserializeUML(string input, string FormatUML, out string[] output)
            {
                //{i} -> poviná položka item
                //{o} -> dobrovolná položka optional
                //{l} -> opakuj od začátku loop
                //{x} -> nemají se získávat žádný data, pouze validace                               
                string[] specString = { "{-i-}", "{-o-}","{-l-}",
                "{+i-}", "{+o-}", "{+l-}",
                "{-i+}", "{-o+}", "{-l+}",
                "{+i+}", "{+o+}", "{+l+}" };
                string[] formatSeparators = FormatUML.Split(specString, StringSplitOptions.RemoveEmptyEntries);
                FormatItem[] formatItems = new FormatItem[formatSeparators.Length];
                for (int i = 0; i < formatSeparators.Length; i++)
                {
                    formatItems[i] = new FormatItem(FormatUML.Split(formatSeparators, StringSplitOptions.RemoveEmptyEntries)[i]);
                }
                //kurzor začíná na 0 index
                //určím zda separátor nebo položka
                //posunu kurzor na začátek separátoru pokud je další separátor
                //načtení formátu položky
                //validace pomocí separátorů
                //kontrola separátoru vlevo
                //určím další separátor v pořadí
                //kontrola separátoru vpravo
                //určím typ položky a vyhodnotím akci
                //-uložení dat - uložím text až po další separátor pak vymažu
                //-validace - provedu kontrolu separátorů
                //-loop - loopuje se 
                //
                for (int i = 0; i < formatItems.Length; i++)
                {
                    int position;
                    FormatItem formatItem = formatItems[i];
                    if(formatItem.validateLeft && formatSeparators[i] != "")
                    {
                        position = 0;
                        string leftSeparator = formatSeparators[i];
                        input.IndexOf(leftSeparator);
                        
                    }
                    if(formatItem.validateRight && formatSeparators[i+1] != "")
                    {
                        position = 0;
                        string rightSeparator = formatSeparators[i+1];
                    }
                    input = input.Remove(0, input.IndexOf(formatSeparators[i]) + formatSeparators[i].Length);
                }
                output = new string[formatSeparators.Length];
                return true;
            }
            public static Classifier Validate(string input)
            {

                return null;

            }
        }
        
    }
}
