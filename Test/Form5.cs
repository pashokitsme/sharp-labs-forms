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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (GlobalVariables.GlobalValue)
            {
                case 1:
                    label2.Text = "Мало, всего то 1 правильный вопрос, be better";
                    break;
                case 2:
                    label2.Text = "Неплохо, но всего то 2 правильных вопроса";
                    break;
                case 3:
                    label2.Text = "Молодец, все вопросы правильные!";
                    break;
                default:
                    label2.Text = "Настолько все плохо, ни 1 правильного? be better bro!";
                    break;
            }
        }
    }
}
