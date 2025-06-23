
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
using CSToolsLib;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
            TestWalker testWalker = new TestWalker();
            var tree = CSharpSyntaxTree.ParseText(@"
namespace CSToolsLib
{    
    internal class EmptyClass
    {

        public EmptyClass() 
        { 
        }

    }
    namespace Test2
    {

    }
}
");
            testWalker.Visit(tree.GetRoot());
            
        }
        public class TestWalker : CSharpSyntaxWalker
        {
            private int count = 0;
            public List<string> nodesOut = new List<string>();
            public TestWalker() : base(SyntaxWalkerDepth.Node)
            {
                
            }
            public override void Visit(SyntaxNode node)
            {
                count++;                
                MessageBox.Show(node.Kind().ToString() + " " + node.ChildTokens().First());
                base.Visit(node);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
             NamespaceWalker nsWalker = new NamespaceWalker();
             NamespaceSeeker namespaceSeeker = new NamespaceSeeker();
             var tree = CSharpSyntaxTree.ParseText(@"
namespace CSToolsLib
{    
    internal class EmptyClass
    {

        public EmptyClass() 
        { 
        }

    }
    namespace Test2
    {

    }
}
"); 
            nsWalker.Visit(tree.GetRoot());
            namespaceSeeker.Visit(tree.GetRoot());
            NamespaceDeclarationSyntax[] nameA = namespaceSeeker.GetStoredNamespaceNodes();
            foreach (NamespaceDeclarationSyntax name in nameA)
            {
                MessageBox.Show(name.ToFullString());
                namespaceSeeker.Visit(name);
                
            }
            //MessageBox.Show(nsWalker.s);
            //button2Visit();
        }
        private void button2Visit(NamespaceDeclarationSyntax[] node, NamespaceSeeker namespaceSeeker)
        {
            for (int i = 0; i < node.Length; i++)
            {

            }
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

        private void button4_Click(object sender, EventArgs e)
        {
            ClassWalker classWalker = new ClassWalker();
            var tree = CSharpSyntaxTree.ParseText(@"public class Customer2
    {
        private string name;
        private string billingAdress;
        private string defaultShippingAddress;

        public Customer2()
        {

        }
        public bool SignUp(string name)
        {
            return false;
        }
        public bool Login(string name, string password)
        {
            return false;
        }
    }");
            classWalker.Visit(tree.GetRoot());
            classWalker.GetClass();
        }
    }
}
