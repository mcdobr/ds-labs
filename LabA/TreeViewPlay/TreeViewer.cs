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
using System.Xml;
using System.Xml.Linq;

namespace TreeViewPlay
{
    public partial class TreeViewer : Form
    {
        private static readonly string ROOT_PROJECT_FOLDER = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

        public TreeViewer()
        {
            InitializeComponent();
        }
        
        private void openButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.InitialDirectory = ROOT_PROJECT_FOLDER;
            openDialog.Filter = "XML files|*.xml";
            openDialog.FilterIndex = 0;
            openDialog.DefaultExt = "xml";


            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                if (!string.Equals(Path.GetExtension(openDialog.FileName), ".xml",
                    StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    /* User has really selected an XML */
                    XDocument xDoc = XDocument.Load(openDialog.FileName);
                    XElement xRoot = xDoc.Root;

                    treeView.CheckBoxes = true;
                    treeView.Nodes.Clear();
                    TreeNode tRoot = new TreeNode(stringifyXTag(xRoot));

                    treeView.Nodes.Add(tRoot);
                    addTreeNode(xRoot, tRoot);
                }
            }

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                XDocument xDoc = new XDocument();
            }
        }

        private void addTreeNode(XElement xElement, TreeNode tElement)
        {
            foreach (var xChild in xElement.Elements())
            {
                TreeNode tChild = new TreeNode(stringifyXTag(xChild));
                tElement.Nodes.Add(tChild);

                addTreeNode(xChild, tChild); 
            }
        }

        private string stringifyXTag(XElement xElement)
        {
            if (xElement.HasElements)
                return xElement.Name + " " + string.Join(" ", xElement.Attributes());
            else
                return xElement.Name + " " + string.Join(" ", xElement.Attributes()) + xElement.Value;

        }

        private void treeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeNode root = e.Node;
            if (root.Nodes.Count > 0)
            {
                foreach (TreeNode child in root.Nodes)
                {
                    child.Checked = root.Checked;
                }
            }
        }
    }
}
