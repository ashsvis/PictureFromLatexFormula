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
            cboxSystemFontName.Items.AddRange(installedFontCollection.Families.Select(x => x.Name).Where(name => CheckFontName(name)).ToArray());
            cboxSystemFontName.Text = "Segoe UI";
            tscbScale.Items.AddRange(Enumerable.Range(1, 120).Select(x => x.ToString()).ToArray());
            tscbScale.Text = "20";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tboxLatex.Text = @"ax^2+bx+c=0; D=b^2-4ac;D>0,\text{ два корня: }x_{1,2}=\frac{-b+\sqrt{D}}{2a};D=0,\text{ один корень: }x_1=\frac{-b}{2a};D<0,\text{корней нет}";
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
            tscbScale.Enabled = !string.IsNullOrWhiteSpace(tboxLatex.Text);
            cboxSystemFontName.Enabled = !string.IsNullOrWhiteSpace(tboxLatex.Text);
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
                labFormulaPicture.Text = "Картинка формулы:";
                pictboxFormula.Image = GetImage(tboxLatex.Text, double.Parse(tscbScale.Text), cboxSystemFontName.Text);
            }
            catch (Exception ex)
            {
                pictboxFormula.Image = null;
                labFormulaPicture.Text = "Ошибка: " + ex.Message;
            }
        }

        /// <summary>
        /// Создаем картинку на лету из формулы в нотации latex
        /// </summary>
        /// <param name="latex">Формула</param>
        /// <returns>Возвращаем картинку</returns>
        private Image GetImage(string latex, double scale, string systemFontName)
        {
            var parser = WpfTeXFormulaParser.Instance;
            var formula = parser.Parse(latex);
            var pngBytes = formula.RenderToPng(scale, 0.0, 0.0, systemFontName);
            using (var stream = new MemoryStream(pngBytes))
            {
                return Image.FromStream(stream);
            }
        }
    }
}
