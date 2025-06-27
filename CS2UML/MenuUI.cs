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
            if (openFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (drawioFileHandler.CorrectFormat(openFileDialog1.OpenFile()))
                {
                    UmlDiagramToolsLib.Diagram[] diagrams = drawioFileHandler.ReadFile(openFileDialog1.OpenFile());
                    drawioFileHandler.WriteFile(saveFileDialog1.OpenFile(), diagrams);
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

        private void buttonQuide_Click(object sender, EventArgs e)
        {
            DrawioFileHandler drawioFileHandler = new DrawioFileHandler();
            if (openFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (drawioFileHandler.CorrectFormat(openFileDialog1.OpenFile()))
                {
                    UmlDiagramToolsLib.Diagram[] diagrams = drawioFileHandler.ReadFile(openFileDialog1.OpenFile());
                    drawioFileHandler.WriteFile(saveFileDialog1.OpenFile(), diagrams);
                }
            }
        }

        private void controlButton_Click(object sender, EventArgs e)
        {
            DrawioFileHandler drawioFileHandler = new DrawioFileHandler();
            if (openFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (true)
                {
                    string readf;
                    using(StreamReader streamReader = new StreamReader(openFileDialog1.OpenFile()))
                    {
                        readf = streamReader.ReadToEnd();

                    }
                    var tree = CSharpSyntaxTree.ParseText(readf);
                    ClassWalker classWalker = new ClassWalker();
                    classWalker.Visit(tree.GetRoot());
                    Class[] classes = { classWalker.GetClass() };
                    UmlDiagramToolsLib.Diagram[] diagrams = { new UmlDiagramToolsLib.Diagram("Diagram",classes,new UmlDiagramToolsLib.Attribute[0],
                    new UmlDiagramToolsLib.Method[0], new UmlDiagramToolsLib.Relationship[0], new UmlDiagramToolsLib.Message[0])};
                    drawioFileHandler.WriteFile(saveFileDialog1.OpenFile(), diagrams);
                }
            }
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            CodeWriterTemp codeWriterTemp;
        }

        private void MenuUI_Load(object sender, EventArgs e)
        {

        }
    }
}
