using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TreeViewPlay
{
    public partial class TreeViewer : Form
    {
        public TreeViewer()
        {
            InitializeComponent();
        }

        private void TreeViewer_Load(object sender, EventArgs e)
        {
            TreeNode root;
            XmlDocument xmlDoc = new XmlDocument();
        }
    }
}
