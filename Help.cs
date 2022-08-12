using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#pragma warning disable IDE1006

namespace FieldCalibration
{
    public partial class Help : Form
    {
        string HelpStr = "";
        public Help(ref string _HelpStr)
        {
            InitializeComponent();
            HelpStr = _HelpStr;
            textBox1.Text = _HelpStr;
        }

        public void ShowHelp(object sender, EventArgs e)
        {
            textBox1.Text = HelpStr;
            Application.DoEvents();
            textBox1.Text += " ";
            this.Show();
        }

        public void Fclose(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Help_Load(object sender, EventArgs e)
        {

        }
    }
}
