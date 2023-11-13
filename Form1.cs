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
using Microsoft.CodeAnalysis.MSBuild;

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
                string projectPath = openFileDialog1.FileName;
                // Creating a build workspace.
                var workspace = MSBuildWorkspace.Create();

                // Opening the Hello World project.
                var project = workspace.OpenProjectAsync(projectPath).Result;

                // Getting the compilation.
                var compilation = project.GetCompilationAsync().Result;

                foreach (var tree in compilation.SyntaxTrees)
                {
                    Console.WriteLine(tree.FilePath);

                    var rootSyntaxNode = tree.GetRootAsync().Result;

                    foreach (var node in rootSyntaxNode.DescendantNodes())
                    {
                        Console.WriteLine($" *** {node.Kind()}");
                        Console.WriteLine($"     {node}");
                    }
                }
               
            }
            

           
        }
    }
}
