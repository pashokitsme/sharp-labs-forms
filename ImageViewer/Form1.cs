using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace image
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ShowImage(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                canvas.Load(openFileDialog1.FileName);
        }

        private void ClearImage(object sender, EventArgs e) => canvas.Image = null;

        private void SelectBackground(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                canvas.BackColor = colorDialog1.Color;
        }

        private void OnClose(object sender, EventArgs e) => Close();

        private void OnStretchSwitched(object sender, EventArgs e) => canvas.SizeMode = isStretchEnabled.Checked ? PictureBoxSizeMode.StretchImage : PictureBoxSizeMode.Normal;
    }
}
