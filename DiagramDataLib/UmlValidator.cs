using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static UmlDiagramToolsLib.Classifier;
namespace UmlDiagramToolsLib
{
    public static class UmlValidator
    {
        public const AccessModifier defaultValue = AccessModifier.Public;
        public static readonly char[] specialChars = { '!', '#', '$', '%', '^', '&', '*', '(', ')', '-', '+', '=', 
            '{', '}', '[', ']', ':', ';', '"', '\'', '<', '>', ',', '.', '?', '/', '`', '|', '~' };
        public static bool ValidateName(string input, out Message[] messages)
        {
            messages = new Message[0];
            foreach(char a in specialChars)
                if(input.Contains(a))
                    return false;
            return input != "";
        }
        public static bool ValidateDatatype(string input, out Message[] messages)
        {
            messages = new Message[0];
            foreach (char a in specialChars)
                if (input.Contains(a))
                    return false;
            return true;
        }
        public static bool ValidateAccessModifier(char input, out AccessModifier modifier)
        {
            modifier = defaultValue;
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

        public static bool Validate(string defaultName, string input, out ClassBuilder classBuilder, out Message[] messages)
        {
            classBuilder = null;
            string[] data;
            List<Message> constructorMessages = new List<Message>();
            if (!DeserializeUML(input, Class.FormatUML, out data, out messages))
                return false;
            {
                Message[] messages1;
                string name = data[0];
                if (ValidateAccessModifier(name[0], out AccessModifier modifier))
                    return false;
                if(ValidateName(name, out messages1))
                    defaultName = name;
                constructorMessages.AddRange(messages1);
            }
            classBuilder = new ClassBuilder(defaultName, defaultValue);
            classBuilder.Add(constructorMessages.ToArray());
            return true;
        }
        public static bool Validate(string defaultName,string defaultDatatype ,string input, out Attribute attribute, out Message[] messages)
        {
            List<Message> constructorMessages = new List<Message>();
            AccessModifier modifier;
            attribute = null;
            string[] data;
            if (!DeserializeUML(input, Attribute.FormatUML, out data, out messages))
                return false;
            {
                Message[] messages1;
                if (data[0].Length < 2)
                    return false;
                if (!ValidateName(data[0].Substring(1), out messages1))
                    return false;

                string name = data[0].Substring(1), datatype;
                if (data.Length == 1)
                    datatype = "";
                else
                    datatype = data[1];
                if (!ValidateAccessModifier(data[0][0], out modifier))
                    return false;                
                if (ValidateName(name, out messages1))
                    defaultName = name;
                constructorMessages.AddRange(messages1);
                if (ValidateDatatype(datatype, out messages1))
                    defaultDatatype = datatype;
                constructorMessages.AddRange(messages1);
            }
            attribute = new Attribute(defaultName,modifier,defaultDatatype,constructorMessages.ToArray());
            return true;
        }
        public static bool Validate(string defaultName, string defaultReturnType,string defaultArgumentName, string defaultArgumentDatatype, string input, out Method method, out Message[] messages)
        {
            Method.MethodArgument[] methodArguments = new Method.MethodArgument[0];
            List<Message> constructorMessages = new List<Message>();
            AccessModifier modifier;
            method = null;
            string[] data;
            string name, arguments = "", returnType = "";
            if (!DeserializeUML(input, Method.FormatUML, out data, out messages))
                return false;
            {                
                Message[] messages1;
                name = data[0].Substring(1);
                if(data.Length > 1)
                    arguments = data[1];
                if(data.Length > 2)
                    returnType = data[2];
                Method.MethodArgument[] methodArguments1;
                if (!ValidateAccessModifier(data[0][0], out modifier))
                {
                    modifier = defaultValue;
                    name = data[0];
                }
                if (!ValidateName(name,out messages1))
                    name = defaultName;
                constructorMessages.AddRange(messages1);
                if (!ValidateDatatype(returnType,out messages1))
                    returnType = defaultReturnType;
                constructorMessages.AddRange(messages1);
                
                if(Validate(defaultArgumentName,defaultArgumentDatatype,arguments,out methodArguments1,out messages1))
                    methodArguments = methodArguments1;
                constructorMessages.AddRange(messages1);
            }
            method = new Method(name,modifier,returnType,methodArguments,constructorMessages.ToArray());
            return true;
        }
        private static bool Validate(string defaultName, string defaultDatatype, string input, out Method.MethodArgument[] arguments, out Message[] messages)
        {
            List<Method.MethodArgument> methodArguments = new List<Method.MethodArgument>();
            List<Message> constructorMessages = new List<Message>();
            arguments = null;
            string[] argumentsString;
            if (!DeserializeUML(input, Method.MethodArgument.FormatUML, out argumentsString, out messages) )
                return false;
            foreach (string s in argumentsString)
            {
                if (DeserializeUML(s, Method.MethodArgument.SubFormatUML,out string[] argumentString,out Message[] messages1))
                {                    
                    string name = argumentString[0], datatype = "";
                    if (argumentString.Length > 1)
                        datatype = argumentString[1];
                    if (!ValidateName(name, out messages1))
                        name = defaultName;
                    constructorMessages.AddRange(messages1);
                    if (!ValidateDatatype(datatype, out messages1))
                        datatype = defaultDatatype;
                    constructorMessages.AddRange(messages1);
                    methodArguments.Add(new Method.MethodArgument(name, datatype, constructorMessages.ToArray()));
                    constructorMessages.Clear();
                }
            }
            arguments = methodArguments.ToArray();
            return true;
        }
        private static bool DeserializeUML(string input, string FormatUML, out string[] output, out Message[] messages)
        {
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
            List<string> outputList = new List<string>();
            List<Message> messagesList = new List<Message>();
            output = outputList.ToArray();
            messages = messagesList.ToArray();                        
            using (StringReader stringReader = new StringReader(input))
            {
                object[] deserializedUmlFormat = DeserializeFormatUML(FormatUML);
                int readIndex = 0;
                List<string> readSeparators = new List<string>();
                readSeparators.Add("");
                List<string> readData = new List<string>();
                bool endOfInput = false, loop;
                do
                {
                    readIndex = 0;
                    loop = false;
                    //data reading
                    int i = 0;
                    if (deserializedUmlFormat[i] is FormatItem[])
                        i++;                    
                    while (i + 1 < deserializedUmlFormat.Length && !endOfInput)
                    {
                        string expectedSeparator = deserializedUmlFormat[i] as string;
                        if (TryReadToNextSeparator(stringReader, expectedSeparator, out string data, out endOfInput))
                        {
                            readSeparators.Add(expectedSeparator);
                            readData.Add(data);
                        }
                        if (endOfInput)
                            readData.Add(data);
                        i+=2;
                    }
                    if (!endOfInput)
                    {
                        readData.Add(stringReader.ReadToEnd());
                        endOfInput = true;
                    }
                    
                    //data processing
                    i = 0;
                    if (deserializedUmlFormat[i] is string)
                        i++;
                    while (i < deserializedUmlFormat.Length)
                    {
                        FormatItem[] formatItems = deserializedUmlFormat[i] as FormatItem[];
                        string leftSeparator = "", rightSeparator = "", data = "";
                        if (readIndex < readSeparators.Count)
                            leftSeparator = readSeparators[readIndex];
                        if (readIndex + 1 < readSeparators.Count)
                            rightSeparator = readSeparators[readIndex + 1];
                        if(readIndex < readData.Count)
                            data = readData[readIndex];
                        ValidateFormatItems(formatItems, leftSeparator, rightSeparator);
                        if(!ProcessFormatItems(formatItems, outputList, data,out loop))
                            return false;
                        i += 2;
                        readIndex++;
                    }
                } while (!endOfInput);
                readIndex--;
                if(loop && readIndex < readData.Count)
                {
                    bool valid = DeserializeUML(readData[readIndex], FormatUML, out string[] loopOutput, out Message[] loopMessages);
                    if (valid)
                    {
                        outputList.AddRange(loopOutput);
                        messagesList.AddRange(loopMessages);
                    }
                    else
                        messagesList.Add(new Message(Message.Category.Error));
                    
                    
                }
            }
            /*
             {
                        string leftSeparator, rightSeparator;
                        if (readSeparators.Count > 0)
                        {
                            leftSeparator = readSeparators.First();
                            readSeparators.RemoveAt(0);
                            if (readSeparators.Count > 0)
                            {
                                rightSeparator = readSeparators.First();
                                readSeparators.RemoveAt(0);
                            }
                            else
                            {
                                rightSeparator = "";
                            }
                        }
                        else
                        {
                            leftSeparator = "";
                            rightSeparator = "";
                        }
                        ValidateFormatItems(formatItems, leftSeparator, rightSeparator);
                    } 
             * */
            output = outputList.ToArray();
            messages = messagesList.ToArray();
            return true;
        }
        private static bool ProcessFormatItems(FormatItem[] formatItems, List<string> outputList,string data,out bool loop)
        {
            loop = false;
            foreach (FormatItem formatItem in formatItems)
            {
                bool valid = formatItem.Validate();
                switch (formatItem.ItemType)
                {
                    case FormatItem.Type.Item:
                        if (!valid || data.Length == 0)
                            return false;
                        outputList.Add(data);
                        data = "";
                        break;
                    case FormatItem.Type.Optional:
                        if (valid && data.Length > 0)
                        {
                            outputList.Add(data);
                            data = "";
                        }
                        else
                            outputList.Add("");
                        break;
                    case FormatItem.Type.Validate:
                        if (data.Length > 0 || !valid)
                            return false;
                        break;
                    case FormatItem.Type.Loop:
                        if(valid)
                            loop = true;
                        break;
                }
            }
            return true;
        }
        /// <summary>
        /// Validates a series of FormatItems
        /// </summary>
        /// <param name="formatItems"></param>
        /// <param name="leftSeparatorValue">separator to the left of the series</param>
        /// <param name="rightSeparatorValue">separator to the right of the series</param>
        private static void ValidateFormatItems(FormatItem[] formatItems, string leftSeparatorValue, string rightSeparatorValue)
        {
            FormatItem first = formatItems[0];
            FormatItem last = formatItems[formatItems.Length - 1];
            for (int i = 0; i < formatItems.Length; i++)
            {
                formatItems[i].Validate();
            }
            first.Validate(leftSeparatorValue, first.RightSeparatorValue);            
            last.Validate(last.LeftSeparatorValue,rightSeparatorValue);
        }
        private static bool TryReadToNextSeparator(StringReader stringReader, string expectedSeparator,out string read, out bool reachedEnd)
        {
            char[] charBuffer = new char[1];
            reachedEnd = false;
            read = "";
            string buffer = "";
            for (int i = 0; i < expectedSeparator.Length && !reachedEnd; i++)
            {                
                reachedEnd = stringReader.Read(charBuffer, 0, 1) == 0;
                buffer += new string(charBuffer);
            }
            while (buffer != expectedSeparator && !reachedEnd)
            {
                read += buffer.Substring(0,1);
                buffer = buffer.Substring(1);
                reachedEnd = stringReader.Read(charBuffer, 0, 1) == 0;
                buffer += new string(charBuffer);
            }
            if(buffer != expectedSeparator)
            {
                read += buffer.Substring(0,buffer.Length-1);
                return false;
            }
            else
                return true;
        }
        private static object[] DeserializeFormatUML(string formatUML)
        {
            List<object> result = new List<object>();
            List<string> itemSeparators = new List<string>();
            //splits separators and formatItems into their own lists
            //formatUml is split in order of: separator, item, separator, ..... , separator,item, separator
            itemSeparators.AddRange(formatUML.Split(FormatItem.AllToString, StringSplitOptions.RemoveEmptyEntries));
            string[] formatItemsString = formatUML.Split(itemSeparators.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            //add the content of ItemSeparators and formatItems to the result list in order of:
            //separator, item, separator, ..... , separator,item, separator
            //all empty separators (of value " ") are removed
            //if multiple items are after another, they are put into an array
            List<FormatItem> formatItemsBuffer = new List<FormatItem>();
            for (int i = 0; i < formatItemsString.Length; i++)
            {                
                if (itemSeparators[i] != " ")
                {
                    if (formatItemsBuffer.Count > 0)
                    {
                        result.Add(formatItemsBuffer.ToArray());
                        formatItemsBuffer.Clear();
                    }
                    result.Add(itemSeparators[i]);
                }
                formatItemsBuffer.Add(new FormatItem(formatItemsString[i], itemSeparators[i], itemSeparators[i + 1]));
            }
            //edge case for if all separators are empty (of value " ")
            if (formatItemsBuffer.Count > 0)
                result.Add(formatItemsBuffer.ToArray());
            return result.ToArray();
        }
        private class FormatItem
        {
            public static readonly string[] AllToString = {
                "{-i-}", "{-o-}","{-l-}","{-v-}",
                "{+i-}", "{+o-}", "{+l-}","{+v-}",
                "{-i+}", "{-o+}", "{-l+}","{-v+}",
                "{+i+}", "{+o+}", "{+l+}","{+v+}"};
            private string toString;
            public enum Type { Item = 'i', Optional = 'o', Loop = 'l', Validate = 'v' }
            public Type ItemType{ get; private set; }
            public bool ValidateLeft { get; private set; }
            public bool ValidateRight { get; private set; }
            public string ExpectedLeftSeparator { get; private set; }
            public string ExpectedRightSeparator { get; private set; }
            public string LeftSeparatorValue { get; private set; }
            public string RightSeparatorValue { get; private set; }
            public FormatItem(string s, string leftSeparator, string rightSeparator)
            {
                toString = s;
                ItemType = (Type)s[2];
                ValidateLeft = s[1] == '+';
                ValidateRight = s[3] == '+';                
                ExpectedLeftSeparator = leftSeparator;
                ExpectedRightSeparator = rightSeparator;
                Validate("", "");
            }
            public bool Validate(string leftSeparator,string rightSeparator)
            {
                LeftSeparatorValue = leftSeparator;
                RightSeparatorValue = rightSeparator;
                return Validate();
            }
            public bool Validate()
            {
                return (!ValidateLeft || ExpectedLeftSeparator == LeftSeparatorValue) && (!ValidateRight || ExpectedRightSeparator == RightSeparatorValue);    
            }
            public override string ToString()
            {
                return toString;
            }
        }

    }
}
