namespace PictureFromLatexFormula
{
    public class UserFunction
    {
        public UserFunction() 
        {
            CaptionFormula = string.Empty;
            InsertFormula = string.Empty;
            OffsetPosition = 0;
        }

        public UserFunction(string captionFormula, string insertFormula, int offsetPosition)
        {
            CaptionFormula = captionFormula;
            InsertFormula = insertFormula;
            OffsetPosition = offsetPosition;
        }

        public string CaptionFormula { get; set; }
        public string InsertFormula {  get; set; }
        public int OffsetPosition { get; set; }

        public override string ToString()
        {
            return $"{CaptionFormula}\t{InsertFormula}\t{OffsetPosition}";
        }

        public void Build(string source)
        {
            var vals = source.Split('\t');
            if (vals.Length == 3 )
            {
                CaptionFormula = vals[0];
                InsertFormula = vals[1];
                if (int.TryParse(vals[2], out int value))
                    OffsetPosition = value;
                else
                    OffsetPosition = 0;
            }
        }

    }
}
