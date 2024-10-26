namespace PictureFromLatexFormula
{
    public partial class UserFunctionsTuningForm : Form
    {
        private readonly List<UserFunction> functions = new();

        public string Data { get; private set; }

        public UserFunctionsTuningForm()
        {
            InitializeComponent();
            Data = string.Empty;
#pragma warning disable CS8622 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует целевому объекту делегирования (возможно, из-за атрибутов допустимости значений NULL).
            ((Control)nudOffset).TextChanged += tboxFormula_TextChanged;
#pragma warning restore CS8622 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует целевому объекту делегирования (возможно, из-за атрибутов допустимости значений NULL).
        }

        private Button? current = null;
        private bool busy = false;

        public void Build(string userFunctions)
        {
            btnDelete.Enabled = false;
            flpUserFunctions.Controls.Clear();
            foreach (var line in userFunctions.Split('\n', StringSplitOptions.RemoveEmptyEntries))
            {
                var vals = line.Split('\t');
                var item = new UserFunction();
                item.Build(line);
                functions.Add(item);

                var btn = new Button
                {
                    Text = item.Formula,
                    Tag = item,
                    Width = 20,
                    AutoSize = true,
                    FlatStyle = FlatStyle.Flat,
                    TabStop = false,
                };
                btn.Click += Btn_Click;
                flpUserFunctions.Controls.Add(btn);
                flpUserFunctions.SetFlowBreak(btn, true);
            }
        }

        /// <summary>
        /// Выбор текущей кнопки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Click(object? sender, EventArgs e)
        {
            busy = true;

            if (current != null)
                current.FlatAppearance.BorderColor = SystemColors.ControlText;

            current = (Button?)sender;

            if (current != null)
                current.FlatAppearance.BorderColor = Color.Cyan;

            EnableEditors();
            btnDelete.Enabled = true;

            busy = false;
        }

        private void EnableEditors()
        {
            if (current?.Tag is UserFunction function)
            {
                var formula = function.Formula;
                tboxFormula.Text = formula;
                tboxFormula.Enabled = true;
                nudOffset.Maximum = formula.Length;
                nudOffset.Value = function.Offset;
                nudOffset.Enabled = true;

                BuildOffsetExample(formula, function.Offset);
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
            if (!flpUserFunctions.Controls.Cast<Button>().Any(btn => btn == current))
            {
                if (current?.Tag is UserFunction func)
                {
                    functions.Add(func);
                    flpUserFunctions.Controls.Add(current);
                    flpUserFunctions.SetFlowBreak(current, true);
                    current.Focus();
                }
            }

            if (current?.Tag is UserFunction function)
            {
                function.Formula = tboxFormula.Text;
                function.Offset = (int)nudOffset.Value;
                current.Text = function.Formula;
                current.Tag = function.Offset;
                current.Width = 20;
            }

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
            if (sender == nudOffset || sender == tboxFormula)
                BuildOffsetExample(tboxFormula.Text, (int)nudOffset.Value);

            btnApply.Enabled = true;
            btnAdd.Enabled = tboxFormula.TextLength > 0;
        }

        private void BuildData()
        {
            Data = string.Join("\n", functions);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!flpUserFunctions.Controls.Cast<Button>().Any(btn => btn.Text == tboxFormula.Text))
            {
                var btn = new Button
                {
                    Width = 20,
                    AutoSize = true,
                    FlatStyle = FlatStyle.Flat,
                    TabStop = false,
                    Tag = new UserFunction()
                };
                btn.Click += Btn_Click;
                current = btn;
                EnableEditors();
            }
            else
            {
                tboxFormula.Text = string.Empty;
                nudOffset.Value = 0;
                btnApply.Enabled = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (flpUserFunctions.Controls.Cast<Button>().Any(btn => btn.Text == tboxFormula.Text))
            {
                var btn = flpUserFunctions.Controls.Cast<Button>().FirstOrDefault(btn => btn == current);
                if (btn != null)
                {
                    flpUserFunctions.Controls.Remove(btn);
                    if (btn.Tag is UserFunction function)
                        functions.Remove(function);
                }
                BuildData();
                btnDelete.Enabled = false;
            }
        }
    }
}
