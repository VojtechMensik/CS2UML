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
        private static bool DeserializeUML(string input,string FormatUML, out string[] output)
        {
            //{i} -> poviná položka item
            //{o} -> dobrovolná položka optional
            //{l} -> opakuj od začátku loop
            //{-x}/{x-}/{-x-} -> musí obsahovat oddělovače na levé/pravé/obou stranách aby byla data validní (x znamená libovolný typ položky)
            List<string> items = new List<string>();
            
            
            output = items.ToArray();
            return true;
        }
        public static Classifier Validate(string input)
        {
            
            return null;
            
        }
        
    }
}
