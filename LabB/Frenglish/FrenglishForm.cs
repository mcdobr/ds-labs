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
        private static int language = 0;
        private System.Timers.Timer timer;
        private ResourceManager resManager = new ResourceManager("Languages.Strings", System.Reflection.Assembly.LoadFrom("Languages.dll"));
        public FrenglishForm()
        {
            InitializeComponent();

            timer = new System.Timers.Timer();
            timer.Interval = 2000;
            timer.Enabled = true;
            timer.Elapsed += changeToRandomLanguage;
        }

        private void hiButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(CultureInfo.CurrentUICulture.ToString());
            string name = nameBox.Text;
            MessageBox.Show(string.Format(resManager.GetString("hiName"), name));
        }

        private void changeToRandomLanguage(Object source, System.Timers.ElapsedEventArgs e)
        {
            language = (language + 1) % languageCombobox.Items.Count;

            string cultureStr = languageCombobox.GetItemText(languageCombobox.Items[language]);

            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(cultureStr);
            //nameLabel.BeginInvoke((MethodInvoker)delegate () { this.Text = resManager.GetString("name"); });
            //nameLabel.Invoke((MethodInvoker)(() => this.Text = resManager.GetString("hiButtonText")));
            //this.nameLabel.Text = resManager.GetString("name");
            this.nameLabel.Invoke((MethodInvoker)delegate
           {
               this.nameLabel.Text = resManager.GetString("name", Thread.CurrentThread.CurrentUICulture);
           });
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cultureStr = languageCombobox.GetItemText(languageCombobox.SelectedItem);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(cultureStr);
        }
    }
}
