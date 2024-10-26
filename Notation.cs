namespace PictureFromLatexFormula
{
    public class Notation
    {
        public Notation(string category, string formula, string pasted = "", int offset = 0)
        {
            Category = category;
            Formula = formula;
            Pasted = string.IsNullOrWhiteSpace(pasted) ? formula : pasted;
            Offset = offset;
            try
            {
                Picture = FormulaHelper.GetImage(formula);
                ErrorInFormulaText = string.Empty;
                ErrorInFormula = false;
            }
            catch (Exception ex)
            {
                ErrorInFormulaText = $"in formula: {formula} error: {ex.Message}";
                Picture = null;
                ErrorInFormula = true;
            }
        }

        public string Category { get; private set; }
        public string Formula { get; private set; }
        public Image? Picture { get; private set; }
        public bool ErrorInFormula { get; private set; }
        public string ErrorInFormulaText { get; private set; }

        public string Pasted { get; private set; }
        public int Offset { get; private set; }
    }
}
