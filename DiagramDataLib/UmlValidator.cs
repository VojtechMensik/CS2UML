using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UmlDiagramToolsLib.Classifier;
namespace UmlDiagramToolsLib
{
    public static class UmlValidator
    {
        /*
         * Disallowed Characters in C# Attribute Names

    Spaces: Spaces are not allowed within attribute names.
    Special Characters: Special characters such as !, #, $, %, ^, &, *, (, ), -, +, =, {, }, [, ], :, ;, '", <, >, ,, ., ?, /, `, |, ~
        UML
        Special Characters: Including but not limi !, #, $, %, ^, &, *, (, ), -, +, =, {, }, [, ], :, ;, '", <, >, ,, ., ?, /, `, |, ~
         * */
        private class FormatItem
        {
            public static readonly string[] AllToString = {
                "{-i-}", "{-o-}","{-l-}","{-v-}",
                "{+i-}", "{+o-}", "{+l-}","{+v-}",
                "{-i+}", "{-o+}", "{-l+}","{-v+}",
                "{+i+}", "{+o+}", "{+l+}","{+v+}"};
            private string s;
            public enum Type { Item = 'i', Optional = 'o', Loop = 'l', Validate = 'v' }
            public Type ItemType{ get; private set; }
            public bool ValidateLeft { get; private set; }
            public bool ValidateRight { get; private set; }
            public bool Valid { get; private set; }
            public string LeftSeparator { get; private set; }
            public string RightSeparator { get; private set; }
            public FormatItem(string s, string leftSeparator, string rightSeparator)
            {
                this.s = s;
                ItemType = (Type)s[2];
                ValidateLeft = s[1] == '+';
                ValidateRight = s[3] == '+';
                Valid = !(s[1] == '+' && leftSeparator == "") || !(s[3] == '+' && rightSeparator == "");
            }
            public bool HasLeftSeparator()
            {
                return LeftSeparator != "";
            }
            public bool HasRightSeparator()
            {
                return RightSeparator != "";
            }
            public override string ToString()
            {
                return s;
            }
        }
        public static bool ValidateName(string input, out Message[] messages)
        {
            messages = null;
            return true;
        }
        public static bool ValidateDatatype(string input, out Message[] messages)
        {
            messages = null;
            return true; 
        }
        public static bool ValidateAccessModifier(char input, out AccessModifier modifier)
        {
            modifier = AccessModifier.Private;
            switch (input)
            {
                case (char)AccessModifier.Public:
                case (char)AccessModifier.Protected:
                case (char)AccessModifier.Private:
                case (char)AccessModifier.Package:
                    modifier = (AccessModifier)input;
                    break;
                default:
                    return false;
            }
            return true;
        }
        public static bool DeserializeUML(string input, string FormatUML, out string[] output, out Message[] messages)
        {
            List<string> outputList = new List<string>();
            List<Message> messagesList = new List<Message>();
            //default values
            output = new string[0];
            messages = new Message[0];
            //            
            //{i} -> poviná položka item
            //{o} -> dobrovolná položka optional
            //{l} -> opakuj od začátku loop
            //{v} -> nejsou vyhodnoceny žádné speciální akce
            List<string> itemSeparators = new List<string>();
            List<FormatItem> formatItems = new List<FormatItem>();
            {
                
                itemSeparators.AddRange(FormatUML.Split(FormatItem.AllToString, StringSplitOptions.None));
                string[] formatItemsString = FormatUML.Split(itemSeparators.ToArray(), StringSplitOptions.None);
                for (int i = 0; i < formatItemsString.Length; i++)
                {
                    if (formatItemsString[i].Length > 5)
                        for (int j = 0; j < formatItemsString[i].Length; j += 5)
                        {
                            
                            formatItems.Add(new FormatItem(formatItemsString[i].Substring(j, 5), itemSeparators[i], itemSeparators[i+1]));
                        }
                    else
                        formatItems.Add(new FormatItem(formatItemsString[i], itemSeparators[i], itemSeparators[i + 1]));
                }
            }
            for(int i = 0;i<itemSeparators.Count;i++)
            {
                if(itemSeparators[i] == "")
                    itemSeparators.RemoveAt(i);
            }
            //značí že už nejsou další separátory
            itemSeparators.Add("");
            /*
            kurzor začíná na 0 index
            <---->
            buď se očekává položka nebo separátor
            -očekává se položka
            --přečte se text do dalšího separátoru to je položka pokud konec textu return false
            -je to separátor
            --posunu kurzor na konec separátoru
            vyhodnocení formáru položky
            -validace pomocí separátorů
            --kontrola zda levý separátor není ""
            --kontrola zda pravý separátor není ""
            --pokud kontrola není validní, nevyhodnocuje se položka
            určím typ položky a vyhodnotím akci
            -uložení dat - uložím text až po další separátor pak vymažu
            --item - pokud není vyhodnocena vstup není validní return false
            --optional - pokud není vyhodnocena output je ""
            -validace - provedu kontrolu separátorů, ignoruju přečtený vstup
            -loop - loopuje se - pokračuji v vyhodnocování inputu, začínám od začátku s FormatUML pokud není konec input 
            return false pokud se došel na konec input bez toho aby se došel na konec formatUML
            */
            using (StringReader stringReader = new StringReader(input))
            {
                char[] buffer;
                bool hasNoSeparators = itemSeparators.Count == 1;
                
                bool endOfInput = false;
                int separatorIndex = 0;
                int itemIndex = 0;
                List<FormatItem> currentItems = new List<FormatItem>();
                do
                {
                    buffer = new char[input.Length];
                    //read to next separator
                    string nextSeparator = itemSeparators[separatorIndex];
                    endOfInput = stringReader.Read(buffer, 0, nextSeparator.Length) > 0;
                    while (!endOfInput && new string(buffer).Substring(buffer.Length - nextSeparator.Length) != nextSeparator)
                    {
                        endOfInput = stringReader.Read(buffer, 0, 1) > 0;
                    }
                    //prochází pole formatItems do konce dokud nepřečte všechny formatItems před dalším separátorem
                    //pokud je separátor "" == žádné další separátory nejsou -> jde až do konce listu
                    while ((formatItems[itemIndex].RightSeparator != nextSeparator || nextSeparator == "") && itemIndex < formatItems.Count)
                    {
                        currentItems.Add(formatItems[itemIndex]);
                        itemIndex++;
                    }
                    //process all items
                    foreach (FormatItem item in currentItems)
                    {
                        switch (item.ItemType)
                        {
                            case FormatItem.Type.Item:
                                if(item.Valid)
                                {
                                    outputList.Add(new string(buffer));
                                }
                                else
                                {
                                    messagesList.Add(new Message(Message.Category.Error));
                                    messages = messagesList.ToArray();
                                    return false;
                                }                                    
                                break;
                            case FormatItem.Type.Optional:
                                if (item.Valid)
                                    outputList.Add(new string(buffer));
                                else
                                    outputList.Add("");
                                break;
                            case FormatItem.Type.Validate:
                                if (!item.Valid || new string(buffer).Length > 0)
                                {
                                    messagesList.Add(new Message(Message.Category.Error));
                                    messages = messagesList.ToArray();
                                    return false;
                                }
                                break;
                            case FormatItem.Type.Loop:
                                if(item.Valid)
                                {
                                    //-1 beacuse separatorIndex++
                                    separatorIndex = -1;
                                    itemIndex = 0;
                                }
                                break;
                        }
                        buffer = new char[input.Length];
                    }
                    //cycle logic
                    separatorIndex++;
                    currentItems.Clear();
                } while (separatorIndex < itemSeparators.Count && !endOfInput) ;
                if(separatorIndex < itemSeparators.Count || !endOfInput)
                {
                    messagesList.Add(new Message(Message.Category.Error));
                    messages = messagesList.ToArray();
                    return false;
                }

            }
            output = outputList.ToArray();
            messages = messagesList.ToArray();
            return true;
        }

        public static bool Validate(string input, out Class @class, out Message[] messages)
        {
            @class = null;
            messages = null;
            Message[] deserializeMessages;
            string[] data;            
            if (!DeserializeUML(input,Class.FormatUML,out data,out deserializeMessages))
            {
                messages = deserializeMessages;
                return false;
            }
            string text = data[0];
            if (ValidateAccessModifier(text[0], out AccessModifier modifier))
            {
                //is attribute
                return false;
            }
            return true;
        }
        public static bool Validate(string input, out Attribute attribute, out Message[] messages)
        {
            attribute = null;
            messages = null;
            Message[] deserializeMessages;
            string[] data;
            if (!DeserializeUML(input, Attribute.FormatUML, out data, out deserializeMessages))
            {
                messages = deserializeMessages;
                return false;
            }
            Message[] messages1;
            List<Message> constructorMessages = new List<Message>();
            string name = data[0].Substring(1);
            string datatype = data[1];
            AccessModifier modifier;
            ValidateAccessModifier(name[0], out modifier);
            ValidateName(data[0],out messages1);
            constructorMessages.AddRange(messages1);
            ValidateDatatype(data[1],out messages1);
            constructorMessages.AddRange(messages1);
            attribute = new Attribute(name,modifier,datatype,constructorMessages.ToArray());
            messages = deserializeMessages;
            return true;
        }
        public static bool Validate(string input, out Method method, out Message[] messages)
        {
            method = null;
            messages = null;
            Message[] deserializeMessages;
            string[] data;
            if (!DeserializeUML(input, Method.FormatUML, out data, out deserializeMessages))
            {
                messages = deserializeMessages;
                return false;
            }
            return true;
        }
        private static bool Validate(string input, out Method.MethodArgument argument, out Message[] messages)
        {
            argument = new Method.MethodArgument();
            messages = null;
            Message[] deserializeMessages;
            string[] data;
            if (!DeserializeUML(input, Method.MethodArgument.FormatUML, out data, out deserializeMessages))
            {
                messages = deserializeMessages;
                return false;
            }
            return true;
        }

    }
}
