using Frenglish.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frenglish
{
    public partial class FrenglishForm : Form
    {
        private ResourceManager resManager = new ResourceManager("Languages.Strings", System.Reflection.Assembly.LoadFrom("Languages.dll"));
        public FrenglishForm()
        {
            InitializeComponent();
        }

        private void hiButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(CultureInfo.CurrentUICulture.ToString());
            string name = nameBox.Text;
            MessageBox.Show(string.Format(resManager.GetString("hiName"), name));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cultureStr = languageCombobox.GetItemText(languageCombobox.SelectedItem);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(cultureStr);
        }
    }
}
