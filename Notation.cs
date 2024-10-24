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
                ErrorInFormula = false;
            }
            catch (Exception ex)
            {
                Picture = MainForm.GetImage($@"\text{{in formula: {formula} error: {ex.Message}}}", 14);
                ErrorInFormula = true;
            }
        }

        public string Formula { get; private set; }
        public Image Picture { get; private set; }
        public bool ErrorInFormula { get; private set; }
    }
}
