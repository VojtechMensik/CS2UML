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

namespace CS2UML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK) 
            {
                string retezec;
                using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                {
                    retezec = sr.ReadToEnd();                    
                }
                string segmenty = retezec.Split(;
            
            
            }
        }
    }
}
