namespace PictureFromLatexFormula
{
    public class Notation
    {
        public Notation(string formula)
        {
            Formula = formula;
            try
            {
                Picture = MainForm.GetImage(formula);
            }
            catch (Exception ex)
            {
                Picture = MainForm.GetImage($@"\text{{in formula: {formula} error: {ex.Message}}}", 14);
            }
        }

        public string Formula { get; private set; }
        public Image? Picture { get; private set; }
    }
}
