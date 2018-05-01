using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TreeViewPlay
{
    public partial class TreeViewer : Form
    {
        private static readonly string ROOT_PROJECT_FOLDER = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        private const string XML_SEPARATOR = "|";


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
                    xmlToTreeView(xRoot, tRoot);
                }
            }

        }

        private void xmlToTreeView(XElement xElement, TreeNode tElement)
        {
            foreach (var xChild in xElement.Elements())
            {
                TreeNode tChild = new TreeNode(stringifyXTag(xChild));
                tElement.Nodes.Add(tChild);

                xmlToTreeView(xChild, tChild);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {

                //xDoc.Add
                TreeNode tRoot = treeView.Nodes[0];
                string[] parts = tRoot.Text.Split(XML_SEPARATOR.ToCharArray());


                XElement xRoot = new XElement(parts[0]);
                treeViewToXML(xRoot, tRoot.Nodes);


                XDocument xDoc = new XDocument(xRoot);
                xDoc.Save(saveDialog.FileName);
            }
        }

        private XElement treeViewToXML(XElement current, TreeNodeCollection tnc)
        {
            XElement xElem = null;
            foreach (TreeNode tElem in tnc)
            {
                string[] nodes = tElem.Text.Split(XML_SEPARATOR.ToCharArray());
                if (tElem.Nodes.Count == 0)
                {
                    // Create the node and set the value
                    xElem = new XElement(nodes[0]);
                    xElem.Value = nodes[nodes.Length - 1];

                    // Add the attributes
                    for (int i = 1; i < nodes.Length - 1; ++i)
                        xElem.Add(new XAttribute(getAttributeFromString(nodes[i])));

                    // Append it to the parent node
                    current.Add(xElem);
                }
                else
                {
                    // Create the node and add the attributes
                    XElement child = new XElement(nodes[0]);
                    for (int i = 1; i < nodes.Length - 1; ++i)
                        child.Add(new XAttribute(getAttributeFromString(nodes[i])));

                    // Add child elements
                    child = treeViewToXML(child, tElem.Nodes);

                    // Add it to the current
                    current.Add(child);
                }
            }
            return current;
        }

        private XAttribute getAttributeFromString(string src)
        {
            string[] parts = src.Split('=');
            return new XAttribute(parts[0], parts[1].Trim('"'));
        }

        /*
        private XElement treeElementToXML(TreeNode tElem)
        {

        }*/

        private string stringifyXTag(XElement xElement)
        {
            if (xElement.HasElements)
                return xElement.Name + XML_SEPARATOR + string.Join(XML_SEPARATOR, xElement.Attributes());
            else
                return xElement.Name + XML_SEPARATOR + string.Join(XML_SEPARATOR, xElement.Attributes()) + xElement.Value;
        }

        private void treeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeNode root = e.Node;
            foreach (TreeNode child in root.Nodes)
            {
                child.Checked = root.Checked;
            }
        }
    }
}
