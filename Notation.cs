namespace PictureFromLatexFormula
{
    public class Notation
    {
        public Notation(string category, string formula)
        {
            Category = category;
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

        public string Category { get; private set; }
        public string Formula { get; private set; }
        public Image Picture { get; private set; }
        public bool ErrorInFormula { get; private set; }
    }
}
