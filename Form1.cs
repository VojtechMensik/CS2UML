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
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.MSBuild;
using System.Xml;
using System.Xml.Serialization;
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
            //XmlSerializer serializer = new XmlSerializer(typeof(Form1));
            if(openFileDialog1.ShowDialog() == DialogResult.OK) 
            {                


            }
            var root = CSharpSyntaxTree.ParseText(File.ReadAllText(@"D:\Users\Vojta\Github\CS2UML\PlaceholderClass.cs")).GetRoot();            
            var classArray = root.DescendantNodes().OfType<ClassDeclarationSyntax>().ToList();
            for(int i = 0; i < classArray.Count; i++) 
            {
                //classArray[i] = classArray[i].DescendantNodes().OfType<ClassDeclarationSyntax>()
            }
            //label1.Text = classDeclaration.Count().ToString() + "\n";
            foreach(ClassDeclarationSyntax c in classArray)
            {
                label1.Text += c.ToString() + "\n";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Diagram diagram = new Diagram();
            
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Diagram));
            StringWriter sw = new StringWriter();
            xmlSerializer.Serialize(sw, diagram);
            label2.Text = sw.ToString();
        }
    }
}
