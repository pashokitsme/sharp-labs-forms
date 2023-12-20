using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace GraphicsEditor
{
    public partial class Form2 : Form
    {
        int x, y;
        Graphics gr, mygraf;

        private Bitmap _bitmap;
        private Pen _pen = new Pen(Color.Black, 3);
        private Brush _brush = new SolidBrush(Color.Blue);

        public Form2()
        {
            InitializeComponent();
        }

        private void OnHideClick(object sender, EventArgs ev)
        {
            Hide();
            new GraphicsForm().Show();
        }

        private void OnLoad(object sender, EventArgs ev)
        {
            _bitmap = new Bitmap(Width, Height);
            gr = Graphics.FromImage(_bitmap);
            mygraf = CreateGraphics();
            _pen.StartCap = LineCap.Round;
            _pen.EndCap = LineCap.Round;
        }

        private void OnMouseDown(object sender, MouseEventArgs ev)
        {
            x = ev.X;
            y = ev.Y;
        }

        private void OnMouseMove(object sender, MouseEventArgs ev)
        {
            if (ev.Button == MouseButtons.Left)
            {
                gr.DrawLine(_pen, ev.X, ev.Y, x, y);
                mygraf.DrawLine(_pen, ev.X, ev.Y, x, y);
                x = ev.X;
                y = ev.Y;
            }
        }
    }
}
