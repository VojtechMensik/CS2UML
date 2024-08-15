using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using UmlDiagramToolsLib;
using CSharpCodeLib;
using DrawioToolsLib;
using CS2UML;
using UmlDiagramToolsLib;
using static UmlDiagramToolsLib.UmlValidator;
using System.IO;
namespace Tester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*
            listBox1.Items.Clear();
            ClassBuilder classBuilder = null; UmlDiagramToolsLib.Attribute attribute = null; Method method = null; UmlDiagramToolsLib.Message[] messages;
            if(classBuilder != null)
                listBox1.Items.Add(classBuilder.Name);
            if (attribute != null)
            {
                listBox1.Items.Add(attribute.Name);
                listBox1.Items.Add(attribute.Datatype);
            }
            if (method != null)
            {
                listBox1.Items.Add(method.Name);
                listBox1.Items.Add(method.ReturnType);

                foreach (Method.MethodArgument argument in method.Arguments)
                {
                    listBox1.Items.Add("///");
                    listBox1.Items.Add(argument.Name);
                    listBox1.Items.Add(argument.DataType);
                }
            }
            */
            //Testovaní Roslyn API
            /*
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
             */

            //Testování XMLSerializeru
            /*
            Diagram diagram = new Diagram();
            
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Diagram));
            StringWriter sw = new StringWriter();
            xmlSerializer.Serialize(sw, diagram);
            label2.Text = sw.ToString();*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
