namespace PictureFromLatexFormula
{
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
