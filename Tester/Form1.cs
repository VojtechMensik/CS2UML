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
            FileSystem fileSystem = new FileSystem();
            var syntaxTree = CSharpSyntaxTree.ParseText(fileSystem.GetFile());
            var root = syntaxTree.GetRoot();
            MessageBox.Show(root.ToFullString());
            UtilSyntaxtRewriter utilSyntaxtRewriter = new UtilSyntaxtRewriter();
            utilSyntaxtRewriter.GrabClass(root);

            foreach (var node in utilSyntaxtRewriter.List)
            {
                //MessageBox.Show(node.ToString());
            }

            //MessageBox.Show(root.ToString());
            var mscorlib = MetadataReference.CreateFromFile(typeof(object).Assembly.Location);
            var compilation = CSharpCompilation.Create("myAssemly",
                new[] { syntaxTree }, new[] { mscorlib });
            var methodSyntax = utilSyntaxtRewriter.List[0].DescendantNodes().OfType<MethodDeclarationSyntax>().First();
            var semanticModel = compilation.GetSemanticModel(syntaxTree);
            var methodSymbol = semanticModel.GetDeclaredSymbol(methodSyntax);
            var smth = semanticModel.GetSymbolInfo(utilSyntaxtRewriter.List[0]);

            MessageBox.Show(utilSyntaxtRewriter.List[0].ToString());
            var returnType = methodSymbol.ReturnType;
            MessageBox.Show(smth.Symbol.ToString());
            //foreach (var item in smth)
            //{
            //    MessageBox.Show(item.ToString());
            //}
            /*
            MessageBox.Show(returnType.SpecialType.ToString());

            if(returnType.SpecialType == SpecialType.System_Int32)
            {
                MessageBox.Show("yes");
                
            }
            */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //XmlSerializer serializer = new XmlSerializer(typeof(Mxfile));
            OpenFileDialog openFileDialog = new OpenFileDialog();
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Mxfile mxFile = (Mxfile)serializer.Deserialize(openFileDialog.OpenFile());

                //mxFile.Agent.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)           
        {
            /*FormatItem[] formatItems = { new FormatItem("{+v+}", "", ""), new FormatItem("{+v+}", "", "") };
            UmlValidator.ValidateFormatItems(formatItems, "", "");
            foreach (var item in formatItems)
            {
                listBox1.Items.Add(item.Validate());
            }
            listBox1.Items.Add("/////////");
            FormatItem[] formatItems1 = {new FormatItem("{+i-}","",""), new FormatItem("{-o-}", "", ""),
                                        new FormatItem("{-v-}","",""),new FormatItem("{-l-}","","")};
            List<string> list = new List<string>();
            listBox1.Items.Add(UmlValidator.ProcessFormatItems(formatItems1, list, "testss", out bool loop));
            listBox1.Items.AddRange(list.ToArray());
            listBox1.Items.Add(loop);*/
            UmlDiagramToolsLib.Attribute attribute;
            UmlValidator.Validate("name", "type", "a:int", out attribute, out UmlDiagramToolsLib.Message[] no);
            
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
