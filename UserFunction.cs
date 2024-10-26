namespace PictureFromLatexFormula
{
    public class UserFunction
    {
        public UserFunction() 
        {
            Formula = string.Empty;
            Offset = 0;
        }

        public UserFunction(string captionFormula, string insertFormula, int offsetPosition)
        {
            Formula = insertFormula;
            Offset = offsetPosition;
        }

        public string Formula {  get; set; }
        public int Offset { get; set; }

        public override string ToString()
        {
            return $"{Formula}\t{Offset}";
        }

        public void Build(string source)
        {
            var vals = source.Split('\t');
            if (vals.Length == 2 )
            {
                Formula = vals[0];
                if (int.TryParse(vals[1], out int value))
                    Offset = value;
                else
                    Offset = 0;
            }
        }

    }
}
