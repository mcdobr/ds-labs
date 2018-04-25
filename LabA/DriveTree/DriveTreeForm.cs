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
using System.Xml.Linq;

namespace DriveTree
{
    public partial class DriveTreeForm : Form
    {
        private string dir;
        public DriveTreeForm()
        {
            InitializeComponent();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog selectedDir = new FolderBrowserDialog();
            if (selectedDir.ShowDialog() == DialogResult.OK)
            {
                dir = selectedDir.SelectedPath;
                DirectoryInfo dirInfo = new DirectoryInfo(dir);


                XElement xmlInfo = GetDirXML(dirInfo);
                File.WriteAllText(dirInfo.Name + "Listing.xml", xmlInfo.ToString());
            }
        
        }

        private static XElement GetDirXML(DirectoryInfo dir)
        {
            XElement xmlInfo = new XElement("dir",
                new XAttribute("name", dir.Name));

            foreach (var file in dir.GetFiles())
            {
                xmlInfo.Add(new XElement("file",
                    new XAttribute("name", file.Name)));
            }

            // Recursively call on the subdirs
            foreach (var subDir in dir.GetDirectories())
            {
                xmlInfo.Add(GetDirXML(subDir));
            }
            return xmlInfo;
        }

    }
}
