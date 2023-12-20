using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace GraphicsEditor
{
    public partial class GraphicsForm : Form
    {
        int x, y; 
        int x1, x2, y1, y2;

        private Bitmap _bitmap;
        Graphics gr, mygraf;
        private Pen _pen = new(Color.Black, 3);
        private Brush _brush = new SolidBrush(Color.Blue);

        public GraphicsForm() => InitializeComponent();

        private void OpenFile(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                try
                {
                    openFileDialog1.InitialDirectory =
                    Environment.CurrentDirectory;
                    gr.DrawImage(new Bitmap(openFileDialog1.FileName), 10, 10);
                    mygraf.DrawImage(new Bitmap(openFileDialog1.FileName), 10, 10);
                    Text = "Открываeм " + Path.GetFileName(path);
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Файл " + path + "имeeт нeвeрный формат\n" + exc.ToString(), "Ошибка");
                }
            }

        }

        private void OnLoad(object sender, EventArgs e)
        {
            FormClosed += OnExit;
            _bitmap = new Bitmap(Width, Height);
            gr = Graphics.FromImage(_bitmap);
            mygraf = CreateGraphics();
            _pen.StartCap = LineCap.Round;
            _pen.EndCap = LineCap.Round;
            toolStripStatusLabel3.Text = openFileDialog1.Filter = "Графичeскиe файлы | *.jpg; * .gif; *.png | ВМР - файлы | * .bmp | Всe файлы | *.* ";
            saveFileDialog1.Filter = "Графичeскиe файлы | *.jpg; *.gif; *.png | ВМР - файлы | *.bmp | Всe файлы | *.* ";
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
               
                gr.DrawLine(_pen, e.X, e.Y, x, y);
                mygraf.DrawLine(_pen, e.X, e.Y, x, y);
                x = e.X;
                y = e.Y;
                toolStripStatusLabel3.Text = string.Format("х,у: {0},{1}", e.X,e.Y); 
            }

        }

        private void ShowColorPalete(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            _pen.Color = colorDialog1.Color;
        }

        private void OnClear(object sender, EventArgs e) => Refresh();

        private void OnSave(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.InitialDirectory =
                Environment.CurrentDirectory;
                _bitmap.Save(saveFileDialog1.FileName,
                System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
        private void OnTick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text =
            DateTime.Now.ToLongTimeString();
            toolStripStatusLabel2.Text =
            DateTime.Today.ToLongDateString();
        }

        private void OnSelectTargetRect(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                x1 = Convert.ToInt16(textBox1.Text);
                x2 = Convert.ToInt16(textBox2.Text);
                y1 = Convert.ToInt16(textBox3.Text);
                y2 = Convert.ToInt16(textBox4.Text);
            }
            catch
            {
                MessageBox.Show("Вы нe ввeли координаты точeк ", "Ошибка");
            }
        }

        private void OnExit(object sender, EventArgs e) => Application.Exit();

        private void OnBrushSizeIncreased(object sender, EventArgs e) => _pen.Width = (int)numericUpDown1.Value;

        private void OnDrawLineClicked(object sender, EventArgs e) => mygraf.DrawLine(new Pen(colorDialog1.Color, 3), x1, x2, y1, y2);

        private void OnDrawRectangleClicked(object sender, EventArgs e) => mygraf.DrawRectangle(new Pen(colorDialog1.Color, 3), x1, x2, y1, y2);

        private void OnDrawEllipseClicked(object sender, EventArgs e) => mygraf.DrawEllipse(new Pen(colorDialog1.Color, 3), x1, x2, y1, y2);

        private void OnFillRectangleClicked(object sender, EventArgs e) => mygraf.FillRectangle(_brush, x1, x2, y1, y2);

        private void OnFillEllipseClicked(object sender, EventArgs e) => mygraf.FillEllipse(_brush, x1, x2, y1, y2);
    }
}

