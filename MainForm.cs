using System.Drawing.Text;
using System.IO;
using WpfMath;
using WpfMath.Parsers;

namespace PictureFromLatexFormula
{
    public partial class MainForm : Form
    {
        InstalledFontCollection installedFontCollection = new();

        public MainForm()
        {
            InitializeComponent();
            tscbSystemFontName.Items.AddRange(installedFontCollection.Families.Select(x => x.Name).Where(name => CheckFontName(name)).ToArray());
            tscbSystemFontName.Text = "Times New Roman";
            tscbScale.Items.AddRange(Enumerable.Range(1, 120).Select(x => x.ToString()).ToArray());
            tscbScale.Text = "20";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FillNotations();
            //tboxLatex.Text = @"ax^2+bx+c=0; D=b^2-4ac;D>0,\text{ два корня: }x_{1,2}=\frac{-b+\sqrt{D}}{2a};D=0,\text{ один корень: }x_1=\frac{-b}{2a};D<0,\text{корней нет}";
            tboxLatex.Text = @"ax^2+bx+c=0;\text{ квадратное уравнение}";
        }

        private bool CheckFontName(string name)
        {
            var parser = WpfTeXFormulaParser.Instance;
            try
            {
                var formula = parser.Parse(@"\text{тест}");
                var pngBytes = formula.RenderToPng(20, 0.0, 0.0, name);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void tboxLatex_TextChanged(object sender, EventArgs e)
        {
            GeneratePicture();
            UpdateControlsEnabled();
        }

        private void UpdateControlsEnabled()
        {
            var enabled = !string.IsNullOrWhiteSpace(tboxLatex.Text) && pboxFormula.Image != null;
            tscbScale.Enabled = enabled;
            tscbSystemFontName.Enabled = enabled;
            tsbCopyToClipboard.Enabled = enabled;
            tsbSave.Enabled = enabled;
        }

        private void nudScale_ValueChanged(object sender, EventArgs e)
        {
            GeneratePicture();
        }

        private void cboxSystemFontName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GeneratePicture();
        }

        private void GeneratePicture()
        {
            try
            {
                labFormulaPicture.ForeColor = SystemColors.ControlText;
                labFormulaPicture.Text = "Картинка формулы:";
                pboxFormula.Image = GetImage(tboxLatex.Text, double.Parse(tscbScale.Text), tscbSystemFontName.Text);
                UpdateControlsEnabled();
            }
            catch (Exception ex)
            {
                pboxFormula.Image = null;
                labFormulaPicture.ForeColor = Color.Red;
                labFormulaPicture.Text = "Ошибка: " + ex.Message;
                UpdateControlsEnabled();
            }
        }

        /// <summary>
        /// Создаем картинку на лету из формулы в нотации latex
        /// </summary>
        /// <param name="latex">Формула</param>
        /// <returns>Возвращаем картинку</returns>
        public static Image GetImage(string latex, double scale = 20.0, string systemFontName = "Times New Roman")
        {
            var parser = WpfTeXFormulaParser.Instance;
            var formula = parser.Parse(latex);
            var pngBytes = formula.RenderToPng(scale, 0.0, 0.0, systemFontName);
            using (var stream = new MemoryStream(pngBytes))
            {
                return Image.FromStream(stream);
            }
        }

        private void tsbCopyToClipboard_Click(object sender, EventArgs e)
        {
            var image = pboxFormula.Image;
            using (var bmp = new Bitmap(image.Width, image.Height))
            {
                using (var g = Graphics.FromImage(bmp))
                {
                    g.FillRectangle(Brushes.White, new Rectangle(0, 0, image.Width, image.Height));
                    g.DrawImageUnscaled(image, 0, 0);
                }
                Clipboard.SetImage(bmp);
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog(Owner) == DialogResult.OK)
            {
                pboxFormula.Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tsbSaveFormula.Enabled = tboxLatex.TextLength > 0;
        }

        private void tsbClearFormula_Click(object sender, EventArgs e)
        {
            tboxLatex.TextChanged -= tboxLatex_TextChanged;
            tboxLatex.Text = string.Empty;
            labFormulaPicture.ForeColor = SystemColors.ControlText;
            labFormulaPicture.Text = "Картинка формулы:";
            pboxFormula.Image = null;
            tboxLatex.TextChanged += tboxLatex_TextChanged;
            UpdateControlsEnabled();
        }

        private void tsbSaveFormula_Click(object sender, EventArgs e)
        {
            if (saveFileDialog2.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog2.FileName, tboxLatex.Text);
            }
        }

        private void tsbLoadFormula_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog(this) == DialogResult.OK)
            {
                tboxLatex.Text = File.ReadAllText(openFileDialog2.FileName);
            }
        }

        private void FillNotations()
        {
            var notes = new List<Notation>()
            {
                new(@"\sqrt{\frac{a}{b}}"),
                new(@"\sum_{i=1}^{10} t_i"),
                new(@"\int_0^\infty e^{-x}\,\mathrm{d}x"),
                new(@"\int_a^b"),
                new(@"(a),[b],\{c\},|d|,\|e\|"),
                new(@"\langle f \rangle,\lfloor g \rfloor,\lceil h \rceil"),
                new(@"\ulcorner i \urcorner,/ j \backslash"),
                new(@"\left(\frac{x^2}{y^3}\right)"),
                new(@"k_{n+1} = n^2 + k_n^2 - k_{n-1}"),
                new(@"A_{m,n} = 
 \begin{pmatrix}
  a_{1,1} & a_{1,2} & \cdots & a_{1,n} \\
  a_{2,1} & a_{2,2} & \cdots & a_{2,n} \\
  \cdots  &         &        &         \\
  a_{m,1} & a_{m,2} & \cdots & a_{m,n} \\
 \end{pmatrix}"),
            };
            var row = 0;
            tlpNotes.ColumnCount = 2;
            tlpNotes.ColumnStyles.Clear();
            tlpNotes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            tlpNotes.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpNotes.RowCount = notes.Count;
            tlpNotes.RowStyles.Clear();
            foreach (var note in notes)
                tlpNotes.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            foreach (var note in notes)
            {
                tlpNotes.Controls.Add(new Label() { Text = note.Formula, AutoSize = true }, 0, row);
                var pic = note.Picture;
                tlpNotes.Controls.Add(new Label() { Image = pic, Width = pic.Width, Height = pic.Height }, 1, row);

                row++;
            }
        }
    }
}
