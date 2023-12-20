using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static testik.Form2;

namespace testik
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox4.Checked && checkBox5.Checked)
            {
                GlobalVariables.GlobalValue += 1;
            }

            this.Close();
            Form5 Form5 = new Form5();
            Form5.Show();
        }
    }
}
