using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrawioToolsLib;
using CSharpCodeLib;
using UmlDiagramToolsLib;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using CSToolsLib;
namespace CS2UML
{
    public partial class MenuUI : Form
    {
        public MenuUI()
        {            
            InitializeComponent();

        }
        /// <summary>
        /// Csharp selected - assigned color
        /// </summary>
        private Color csColor = Color.FromArgb(129, 55, 135);
        /// <summary>
        /// Drawio selected - assigned color
        /// </summary>
        private Color drawioColor = Color.FromArgb(240, 135, 5);
        /// <summary>
        /// None selected - assigned color
        /// </summary>
        private Color noneColor = Color.Gray;
        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// -1=No file type is selected to be on input
        /// 
        /// 0=Drawio file type is selected to be on input
        /// 1=Csharp file type is selected to be on input
        /// </returns>
        private int ChosenInputFiles()
        {
            int i = 0;
            foreach (Control control in groupBoxInputFileControls.Controls)
            {
                if (control is CustomRadioButton)
                {
                    if ((control as CustomRadioButton).Checked)
                        return i;
                    i++;
                }
            }
            return -1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// -1=No file type is selected to be on output
        /// 0=Drawio file type is selected to be on output
        /// 1=Csharp file type is selected to be on output
        /// </returns>
        private int ChosenOutputFiles()
        {
            int i = 0;
            foreach (Control control in groupBoxOutputFileControls.Controls)
            {
                if (control is CustomRadioButton)
                {
                    if ((control as CustomRadioButton).Checked)
                        return i;
                    i++;
                }
            }
            return -1;
        }
        private void UpdateControlButton()
        {
            ///Validace formátu\r\n.drawio / .xml
            ///Konverze formátu\r\n.drawio / .xml na .cs
            ///Vyberte formáty souborů\r\npro převod
            string text = "";
            int outF = ChosenOutputFiles(), inF = ChosenInputFiles();
            if(outF == -1 || inF == -1)
            {
                //nejsou vybrány formáty
                controlButton.Text = "Vyberte formáty souborů\r\npro převod";
                controlButton.BorderColor = noneColor;
                controlButton.Enabled = false;
                controlButton.BackColor = SystemColors.Control;
            }
            else
            {
                //jsou vybrány formáty
                controlButton.Enabled = true;
                controlButton.BackColor = Color.White;
                switch(inF)
                {                        
                    case 0:
                        text = ".drawio / .xml";
                        controlButton.BorderColor = drawioColor;
                        break;
                    case 1:
                        text = ".cs";
                        controlButton.BorderColor = csColor;
                        break;
                }
                if(outF == inF)
                {
                    //mód převodu = validace souboru
                    text = "Validace formátu\r\n" + text;
                }                
                else
                {
                    //mód převodu = konverze formátu
                    text = "Konverze formátu\r\n" + text + " na ";
                    switch(outF)
                    {
                        case 0:
                            text += ".drawio / .xml";
                            controlButton.BorderColor = drawioColor;
                            break;
                        case 1:
                            text += ".cs";
                            controlButton.BorderColor = csColor;
                            break;
                    }
                }
                controlButton.Text = text;
            }
        }        
        private void customButton1_Click(object sender, EventArgs e)
        {
            DrawioFileHandler drawioFileHandler = new DrawioFileHandler();
            if (openFileDialog.ShowDialog() == DialogResult.OK && saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (drawioFileHandler.CorrectFormat(openFileDialog.OpenFile()))
                {
                    UmlDiagramToolsLib.Diagram[] diagrams = drawioFileHandler.ReadFile(openFileDialog.OpenFile());
                    drawioFileHandler.WriteFile(saveFileDialog.OpenFile(), diagrams);
                }
            }
        }

        private void radioButtonDrawioIn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControlButton();
        }

        private void radioButtonCsharpIn_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCsharpIn.Checked && radioButtonCsharpOut.Checked)
                radioButtonCsharpOut.Checked = false;
            UpdateControlButton();
        }

        private void radioButtonDrawioOut_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControlButton();
        }

        private void radioButtonCsharpOut_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCsharpIn.Checked && radioButtonCsharpOut.Checked)
                radioButtonCsharpIn.Checked = false;
            UpdateControlButton();
        }
        private void controlButton_Click(object sender, EventArgs e)
        {
            if(radioButtonCsharpIn.Checked)
            {
                openFileDialog.Title = "Otevřít vstupní C# soubor";                
                openFileDialog.Filter = "Csharp files (*.cs)|*.cs|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
            }
            else
            {
                openFileDialog.Title = "Otevřít vstupní Drawio soubor";
                openFileDialog.Filter = "Drawio files (*.drawio;*.xml)|*.drawio;*.xml|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
            }
            if (radioButtonCsharpOut.Checked)
            {
                saveFileDialog.Title = "Uložit výsledný C# soubor jako";
                saveFileDialog.FileName = "ConvertedCsharpCode";
                saveFileDialog.Filter = "Csharp files (*.cs)|*.cs|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
            }
            else
            {
                saveFileDialog.Title = "Uložit výsledný Drawio soubor jako";
                saveFileDialog.FileName = "ConvertedClassDiagram";
                saveFileDialog.Filter = "Drawio files (*.drawio;*.xml)|*.drawio;*.xml|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
            }
            DrawioFileHandler drawioFileHandler = new DrawioFileHandler();
            DialogResult open, save;
            MessageBox.Show("Nyní vyberete vstupní soubory");
            open = openFileDialog.ShowDialog();
            if (open == DialogResult.OK)
            {
                MessageBox.Show("Nyný uložíte zpracované data do souboru");
                save = saveFileDialog.ShowDialog();
                if (open == DialogResult.OK && save == DialogResult.OK)
                {
                    if (radioButtonCsharpIn.Checked && radioButtonDrawioOut.Checked)
                    {
                        string readf;
                        using (StreamReader streamReader = new StreamReader(openFileDialog.OpenFile()))
                        {
                            readf = streamReader.ReadToEnd();

                        }
                        var tree = CSharpSyntaxTree.ParseText(readf);
                        bool valid = false;
                        var mscorelib = MetadataReference.CreateFromFile(typeof(object).Assembly.Location);
                        var compilation = CSharpCompilation.Create("MyCompilation")
                            .AddReferences(mscorelib)
                            .AddSyntaxTrees(tree);
                        var diagnostics = compilation.GetDiagnostics().ToList();
                        for (int i = 0; i < diagnostics.Count; i++)
                        {
                            var diagnostic = diagnostics[i];
                            if (diagnostic.Severity != DiagnosticSeverity.Error)
                            {
                                diagnostics.RemoveAt(i);
                                i--;
                            }
                            else
                                if (diagnostic.Id == "CS5001")
                            {
                                diagnostics.RemoveAt(i);
                                i--;
                            }
                        }
                        valid = diagnostics.Count == 0;
                        if (valid)
                        {
                            ClassWalker classWalker = new ClassWalker();
                            classWalker.Visit(tree.GetRoot());
                            Class[] classes = { classWalker.GetClass() };
                            UmlDiagramToolsLib.Diagram[] diagrams = { new UmlDiagramToolsLib.Diagram("Diagram",classes,new UmlDiagramToolsLib.Attribute[0],
                            new UmlDiagramToolsLib.Method[0], new UmlDiagramToolsLib.Relationship[0], new UmlDiagramToolsLib.Message[0])};
                            using (Stream saveFileDialogStream = saveFileDialog.OpenFile())
                            {
                                drawioFileHandler.WriteFile(saveFileDialogStream, diagrams);
                            }
                        }
                        else
                        {
                            string slovo1 = "chybě"; string slovo2 = "ji";
                            if (diagnostics.Count > 1) { slovo1 = "chybám"; slovo2 = "je"; }
                            if (MessageBox.Show("Při zpracovávání souboru došlo k "+slovo1+" ("+diagnostics.Count+").\nPřejete si "+slovo2+" zobrazit?"
                                ,"Chyba zpracování",MessageBoxButtons.YesNo,MessageBoxIcon.Error) == DialogResult.Yes)
                            {
                                string vypisChyb = "";
                                for (int i = 0; i < diagnostics.Count; i++)
                                {
                                    string chyba = "-Chyba ("+(i+1).ToString()+")-Kód chyby/Popis/Pozice\n";
                                    chyba += diagnostics[i].Id +" / "+ diagnostics[i].GetMessage() + " / Řádek " +
                                        diagnostics[i].Location.GetLineSpan().StartLinePosition.Line.ToString() + "\n";
                                    vypisChyb += chyba;
                                }
                                MessageBox.Show(vypisChyb, "Výpis chyb");
                            }
                        }                        
                    }
                    if (radioButtonDrawioIn.Checked && radioButtonCsharpOut.Checked)
                    {
                        if (drawioFileHandler.CorrectFormat(openFileDialog.OpenFile()))
                        {
                            UmlDiagramToolsLib.Diagram[] diagrams = drawioFileHandler.ReadFile(openFileDialog.OpenFile());
                            CodeWriterTemp codeWriterTemp = new CodeWriterTemp();
                            ClassDeclarationSyntax classDeclarationSyntax = codeWriterTemp.Class(diagrams[0].Classes[0]);
                            using (StreamWriter streamWriter = new StreamWriter(saveFileDialog.OpenFile()))
                            {
                                streamWriter.Write(classDeclarationSyntax.NormalizeWhitespace().ToFullString());
                            }
                            //MessageBox.Show(classDeclarationSyntax.NormalizeWhitespace().ToFullString());
                        }
                    }
                    if (radioButtonDrawioIn.Checked && radioButtonDrawioOut.Checked)
                    {

                        if (drawioFileHandler.CorrectFormat(openFileDialog.OpenFile()))
                        {
                            UmlDiagramToolsLib.Diagram[] diagrams = drawioFileHandler.ReadFile(openFileDialog.OpenFile());
                            
                            string vypisChyb;
                            bool empty;
                            bool hasErrors = DiagramHasErrors(diagrams,out vypisChyb,out empty);
                            if (hasErrors)
                            {
                                if(MessageBox.Show("Při zpracování souboru došlo k nalezením chybných dat.\nPřejete si je zobrazit?","Chybná data",MessageBoxButtons.YesNo,MessageBoxIcon.Error) == DialogResult.Yes)
                                {
                                    MessageBox.Show(vypisChyb, "Výpis chyb");
                                }
                            }
                            if (!empty)
                            {
                                drawioFileHandler.WriteFile(saveFileDialog.OpenFile(), diagrams);
                            }
                        }
                    }


                }
            }
        }
        private bool DiagramHasErrors(UmlDiagramToolsLib.Diagram[] diagrams,out string vypisChyb,out bool emptyDiagram)
        {
            
            bool hasErrors = false;
            UmlDiagramToolsLib.Diagram diagram = diagrams[0];
            emptyDiagram = diagram.Classes.Length > 0;
            vypisChyb = "";
            foreach(UmlDiagramToolsLib.Class @class in diagram.Classes)
            {
                bool chybyVTride = false;
                string vypisTridy = "Chybná data třídy -"+@class.ToString()+"-\n";
                if (@class.Messages.Length > 0)
                {
                    vypisTridy += @class.Messages[0].Input + "\n";
                    chybyVTride = true;
                }                
                foreach (UmlDiagramToolsLib.Attribute attribute in @class.Attributes)
                {
                    if (attribute.Messages.Length > 0)
                    {
                        chybyVTride = true;
                        vypisTridy += attribute.Messages[0].Input + "\n";
                    }
                }
                foreach (UmlDiagramToolsLib.Method method in @class.Methods)
                {
                    bool chybaMetody = false;
                    bool chybaParametru = false;
                    if(method.Messages.Length > 0)
                    { 
                        chybyVTride = true;
                        chybaMetody = true;
                    }                    
                    if (chybaMetody)
                    {
                        vypisTridy += method.Messages[0].Input + "\n";
                    }
                    foreach (UmlDiagramToolsLib.Method.MethodArgument argument in method.Arguments)
                    {
                        if (argument.Messages.Length > 0)
                        {
                            chybyVTride = true;
                            chybaParametru = true;                            
                        }
                    }
                    if(chybaParametru)
                    {
                        vypisTridy += "Chyby parametru metody -" + method.Name.Trim() + "-\n";
                        foreach (UmlDiagramToolsLib.Method.MethodArgument argument in method.Arguments)
                        {
                            if (argument.Messages.Length > 0)
                            {
                                vypisTridy += argument.Messages[0].Input + "\n";
                                break;
                            }
                        }
                    }
                }
                if(chybyVTride)
                {
                    vypisChyb += vypisTridy + "\n";
                    hasErrors = true;
                }
            }
            if (diagram.Messages.Length > 0)
            {
                hasErrors = true;
                vypisChyb += "Nezpracovaná chybná data\n";
                foreach (UmlDiagramToolsLib.Message message in diagram.Messages)
                {
                    vypisChyb += message.Input + "\n";
                }
            }
            return hasErrors;
        }
        private void MenuUI_Load(object sender, EventArgs e)
        {

        }
    }
}
