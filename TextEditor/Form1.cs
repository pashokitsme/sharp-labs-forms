using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TextEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Open(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
                string path = openFileDialog1.FileName;
                try
                {
                    var writer = new StreamReader(path,
                    Encoding.Default);
                    Editor.Text = writer.ReadToEnd();
                    writer.Close();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Ошибка чтения файла" +
                    exc.ToString(), "Текстовый редактор", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                Text = "Открываем " + Path.GetFileName(path);
                openFileDialog1.FileName = string.Empty;
                Editor.SelectionStart = Editor.TextLength;
            }
        }

        private void Save(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveFileDialog1.InitialDirectory =
                Environment.CurrentDirectory;
                string path = saveFileDialog1.FileName;
                try
                {
                    var writer = new StreamWriter(path, false, Encoding.Default);
                    writer.WriteLine(Editor.Text);
                    writer.Close();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Ошибка доступа к файлу" +
                    exc.ToString(), "Текстовый редактор", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                Text = "Сохраняем " + Path.GetFileName(path);
                Editor.Modified = false;
            }
        }

        private void ShowFontSelector(object sender, EventArgs e)
        {
            fontDialog1.Font = Editor.Font;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
                if (!Editor.Font.Equals(fontDialog1.Font))
                {
                    Font f = Editor.Font;
                    Editor.Font = fontDialog1.Font;
                    f.Dispose();
                }
        }

        private void AlignRight(object sender, EventArgs e) => Editor.TextAlign = HorizontalAlignment.Right;

        private void AlignCenter(object sender, EventArgs e) => Editor.TextAlign = HorizontalAlignment.Center;

        private void AlignLeft(object sender, EventArgs e) => Editor.TextAlign = HorizontalAlignment.Left;

        private void Bold(object sender, EventArgs e)
        {
            BoldCheckbox.Checked = !BoldCheckbox.Checked;
            var fs = BoldCheckbox.Checked ? (Editor.Font.Style | FontStyle.Bold) : (Editor.Font.Style & ~FontStyle.Bold);
            Editor.Font = new Font(Editor.Font, fs);
        }

        private void Italic(object sender, EventArgs e)
        {
            ItalicCheckbox.Checked = !ItalicCheckbox.Checked;
            var fs = ItalicCheckbox.Checked ? (Editor.Font.Style | FontStyle.Italic) : (Editor.Font.Style & ~FontStyle.Italic);
            var f = new Font(Editor.Font, fs);
            Editor.Font = f;
        }

        private void Underline(object sender, EventArgs e)
        {
            UnderlineCheckbox.Checked = !UnderlineCheckbox.Checked;
            var fs = UnderlineCheckbox.Checked ? (Editor.Font.Style | FontStyle.Underline) : (Editor.Font.Style & ~FontStyle.Underline);
            Editor.Font = new Font(Editor.Font, fs);
        }

        private void ChangeFontColor(object sender, EventArgs e)
        {
            colorDialog1.Color = Editor.ForeColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                Editor.ForeColor = colorDialog1.Color;
        }

        private void ChangeBackgroundColor(object sender, EventArgs e)
        {
            colorDialog1.Color = Editor.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                Editor.BackColor = colorDialog1.Color;
        }

        private void Undo(object sender, EventArgs e) => Editor.Undo();

        private void Cut(object sender, EventArgs e) => Editor.Cut();

        private void Copy(object sender, EventArgs e) => Editor.Copy();

        private void Paste(object sender, EventArgs e) => Editor.Paste();

        private void DeleteSelected(object sender, EventArgs e) => Editor.SelectedText = "";

        private void SelectAll(object sender, EventArgs e) => Editor.SelectAll();

        private void CreateNew(object sender, EventArgs e)
        {
            Editor.Clear();
            Text = "Новый документ";
        }

        private void OnTextValueChanged(object sender, EventArgs e) => toolStripStatusLabel3.Text = "Количество набранных символов = " + Editor.TextLength.ToString();

        private void OnTick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = IsKeyLocked(Keys.CapsLock) ? "Нажата Caps Lock" : "";
            toolStripStatusLabel2.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
