using WpfMath;
using WpfMath.Parsers;

namespace PictureFromLatexFormula
{
    public static class FormulaHelper
    {

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
    }
}
