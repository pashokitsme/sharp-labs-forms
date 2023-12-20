using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testik
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public static class GlobalVariables
        {
            public static int GlobalValue  { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                GlobalVariables.GlobalValue  += 1;
            }
            else
            {
                GlobalVariables.GlobalValue  = 0;
            }
            Close();
            Form3 Form3 = new Form3();
            Form3.Show();

        }
    }
}
