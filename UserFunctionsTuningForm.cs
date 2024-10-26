namespace PictureFromLatexFormula
{
    public partial class UserFunctionsTuningForm : Form
    {
        public string Data { get; private set; }

        public UserFunctionsTuningForm()
        {
            InitializeComponent();
            Data = string.Empty;
            ((Control)nudOffset).TextChanged += tboxFormula_TextChanged;
        }

        private Button? current = null;
        private bool busy = false;

        public void Build(string userFunctions)
        {
            flpUserFunctions.Controls.Clear();
            foreach (var line in userFunctions.Split('\n'))
            {
                var vals = line.Split('\t');
                var item = new UserFunction();
                item.Build(line);
                var btn = new Button
                {
                    Text = item.Formula,
                    Tag = item.Offset,
                    Width = 20,
                    AutoSize = true,
                    FlatStyle = FlatStyle.Flat,
                    TabStop = false,
                };
                btn.Click += (s, e) =>
                {
                    busy = true;

                    current = (Button?)s;
                    var formula = (current?.Text) ?? string.Empty;
                    tboxFormula.Text = formula;
                    tboxFormula.Enabled = true;
                    nudOffset.Value = int.TryParse($"{current?.Tag}", out int offset) ? offset : 0;
                    nudOffset.Maximum = formula.Length;
                    nudOffset.Enabled = true;

                    BuildOffsetExample(formula, offset);

                    busy = false;
                };
                flpUserFunctions.Controls.Add(btn);
            }
        }

        private void BuildOffsetExample(string? formula, int offset)
        {
            flpExample.Controls.Clear();
            flpExample.Controls.Add(new Label { Text = formula?.Substring(0, formula.Length - offset), AutoSize = true, Margin = new Padding(0, 5, 0, 0) });
            flpExample.Controls.Add(new Label { Text = "|", AutoSize = true, Margin = new Padding(0, 5, 0, 0), BackColor = SystemColors.Info });
            if (offset > 0)
                flpExample.Controls.Add(new Label { Text = formula?.Substring(formula.Length - offset), AutoSize = true, Margin = new Padding(0, 5, 0, 0) });
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (current == null) return;
            current.Text = tboxFormula.Text;
            current.Tag = (int)nudOffset.Value;
            btnApply.Enabled = false;

            busy = true;

            tboxFormula.Text = string.Empty;
            nudOffset.Value = 0;

            busy = false;

            tboxFormula.Enabled = false;
            nudOffset.Enabled = false;
            BuildData();
        }

        private void tboxFormula_TextChanged(object sender, EventArgs e)
        {
            if (busy) return;

            if (sender == tboxFormula)
                nudOffset.Maximum = tboxFormula.TextLength;
            if (sender == nudOffset)
                BuildOffsetExample(tboxFormula.Text, (int)nudOffset.Value);

            btnApply.Enabled = true;
        }

        private void BuildData()
        {
            List<string> list = new(); 
            foreach (var btn in flpUserFunctions.Controls.OfType<Button>())
            {
                var item = new UserFunction(btn.Text, btn.Text, int.TryParse($"{btn.Tag}", out int pos) ? pos : 0);
                list.Add(item.ToString());
            }
            Data = string.Join("\n", list.ToArray());
        }
    }
}
