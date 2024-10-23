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
            lboxNotation.Items.Clear();
            lboxNotation.Items.Add(new Notation(@"\sqrt{\frac{a}{b}}"));
            lboxNotation.Items.Add(new Notation(@"\sum_{i=1}^{10} t_i"));
            lboxNotation.Items.Add(new Notation(@"\int_0^\infty e^{-x}\,\mathrm{d}x"));
            lboxNotation.Items.Add(new Notation(@"\int_a^b"));
            lboxNotation.Items.Add(new Notation(@"( a ), [ b ], \{ c \}, | d |, \| e \|, \langle f \rangle, \lfloor g \rfloor,\lceil h \rceil, \ulcorner i \urcorner,/ j \backslash"));
            lboxNotation.Items.Add(new Notation(@"*"));
            lboxNotation.Items.Add(new Notation(@"*"));
            lboxNotation.Items.Add(new Notation(@"*"));
            lboxNotation.Items.Add(new Notation(@"*"));
            lboxNotation.Items.Add(new Notation(@"*"));
            lboxNotation.Items.Add(new Notation(@"*"));
            lboxNotation.Items.Add(new Notation(@"*"));
            lboxNotation.Items.Add(new Notation(@"*"));
            lboxNotation.Items.Add(new Notation(@"*"));
            lboxNotation.Items.Add(new Notation(@"*"));
        }

        private void lboxNotation_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = ((Notation)lboxNotation.Items[e.Index]).Picture.Height + 10;
        }

        private void lboxNotation_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            var width = lboxNotation.ClientRectangle.Width;
            var item = (Notation)lboxNotation.Items[e.Index];
            e.DrawBackground();
            var rText = e.Bounds;
            rText.Width = width / 2;
            using (var sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Center;
                var foreColor = SystemBrushes.ControlText;
                if (e.State.HasFlag(DrawItemState.Selected))
                    foreColor = SystemBrushes.HighlightText;
                e.Graphics.DrawString(item.Formula, lboxNotation.Font, foreColor, rText, sf);
            }
            e.Graphics.DrawRectangle(SystemPens.Highlight, rText);
            var rPict = e.Bounds;
            rPict.Width = width / 2;
            rPict.Offset(width / 2, 0);
            e.Graphics.FillRectangle(Brushes.White, rPict);
            rPict.Offset(0, 5);
            if (item.Picture.Width < width / 2) rPict.Offset((width / 2 - item.Picture.Width) / 2, 0);
            e.Graphics.DrawImageUnscaled(item.Picture, rPict);
            rPict = e.Bounds;
            rPict.Width = width / 2 - 1;
            rPict.Offset(width / 2, 0);
            e.Graphics.DrawRectangle(SystemPens.Highlight, rPict);
        }
    }

    public class Notation
    {
        public Notation(string formula)
        {
            Formula = formula;
            Picture = MainForm.GetImage(formula);
        }

        public string Formula { get; private set; }
        public Image Picture { get; private set; }
    }
}
