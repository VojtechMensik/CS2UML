using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrawioToolsLib;
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
        private const Color csColor = Color.FromArgb(129; 55; 135);
        /// <summary>
        /// Drawio selected - assigned color
        /// </summary>
        private const Color drawioColor = Color.FromArgb(240; 135; 5)
        /// <summary>
        /// None selected - assigned color
        /// </summary>
        private const Color noneColor = Color.Gray;
        private bool InputFilesChosen()
        {
            foreach (Control control in groupBoxInputFileControls.Controls)
            {
                if(control is CustomRadioButton)                
                    if( (control as CustomRadioButton).Checked )
                        return true;                
            }
            return false;
        }
        private int InputFilesChosen()
        {
            return radioButtonDrawioIn.Checked == true || radioButtonCsharpIn.Checked == true;
        }
        private bool OutputFilesChosen()
        {
            foreach (Control control in groupBoxOutputFileControls.Controls)
            {
                if (control is CustomRadioButton)
                    if ((control as CustomRadioButton).Checked)
                        return true;
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// 0=No file type is selected to be on output
        /// 1=Drawio file type is selected to be on output
        /// 2=Csharp file type is selected to be on output
        /// </returns>
        private int OutputFilesChosen()
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
            return 0;
        }
        private void UpdateControlButton()
        {
            if (radioButtonCsharpOut.Checked)
            {

            }
            else
                if (radioButtonDrawioOut.Checked)
            {

            }
            else
            {

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

        }

        private void radioButtonCsharpIn_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCsharpIn.Checked && radioButtonCsharpOut.Checked)
                radioButtonCsharpOut.Checked = false;
        }

        private void radioButtonDrawioOut_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonCsharpOut_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCsharpIn.Checked && radioButtonCsharpOut.Checked)
                radioButtonCsharpIn.Checked = false;
        }

        private void buttonQuide_Click(object sender, EventArgs e)
        {

        }
    }
}
