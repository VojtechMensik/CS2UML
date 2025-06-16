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
        private Color csColor;
        private Color drawioColor;
        private void UpdateControlButton()
        {

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
    }
}
