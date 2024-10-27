using System.ComponentModel;
using System.Drawing.Text;
using System.Globalization;
using WpfMath;
using WpfMath.Parsers;

namespace PictureFromLatexFormula
{
    public partial class MainForm : Form
    {
        readonly InstalledFontCollection installedFontCollection = new();
        readonly BackgroundWorker worker = new();
        readonly string predefined = @"\frac{}{}	3
\text{}	1
\sqrt{}	1
_{}	1
^{}	1
\,	0
\:	0
\;	0
\!	0
\left(\right)	7
\color{red}{}	1
";

        public MainForm()
        {
            InitializeComponent();
            splitContainer1.Panel2Collapsed = true;
            tscbSystemFontName.Items.Add("Times New Roman");
            tscbSystemFontName.Text = "Times New Roman";
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }

        private void Worker_DoWork(object? sender, DoWorkEventArgs e)
        {
            var range = installedFontCollection.Families.Select(x => x.Name).Where(name => CheckFontName(name)).ToArray();
            e.Result = range;
        }

        private void Worker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            var range = e.Result as string[];
            tscbScale.Items.Clear();
            tscbScale.Items.AddRange(Enumerable.Range(1, 120).Select(x => x.ToString()).ToArray());
            tscbScale.Text = "20";
            tscbSystemFontName.Items.Clear();
            tscbSystemFontName.Items.AddRange(range);
            tscbSystemFontName.Text = "Times New Roman";
            FillNotations();
            LoadUserFunctions();
            tboxLatex.Text = "";
            splitContainer1.Panel2Collapsed = false;
            tableLayoutPanel1.Enabled = true;
            tboxLatex.Focus();
        }

        private static bool CheckFontName(string name)
        {
            var parser = WpfTeXFormulaParser.Instance;
            try
            {
                var formula = parser.Parse(@"\text{тест}");
                var pngBytes = formula.RenderToPng(20, 0.0, 0.0, name);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.Enabled = false;
            worker.RunWorkerAsync();
        }

        private void tboxLatex_TextChanged(object sender, EventArgs e)
        {
            GeneratePicture();
            UpdateControlsEnabled();
        }

        private void UpdateControlsEnabled()
        {
            var enabled = !string.IsNullOrWhiteSpace(tboxLatex.Text) && pboxFormula.Image != null;
            tscbScale.Enabled = enabled;

            tscbSystemFontName.Enabled = enabled;
            tsbMoreFontSize.Enabled = enabled && tscbScale.SelectedIndex < tscbScale.Items.Count - 1;
            tsbLessFontSize.Enabled = enabled && tscbScale.SelectedIndex > 0;

            tsbCopyToClipboard.Enabled = enabled;
            tsbSave.Enabled = enabled;

        }

        private void nudScale_ValueChanged(object sender, EventArgs e)
        {
            GeneratePicture();
        }

        private void cboxSystemFontName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GeneratePicture();
        }

        private void GeneratePicture()
        {
            try
            {
                labFormulaPicture.ForeColor = SystemColors.ControlText;
                labFormulaPicture.Text = "Картинка формулы:";
                if (tboxLatex.TextLength > 0 &&
                    double.TryParse(tscbScale.Text, out double scale) &&
                    !string.IsNullOrWhiteSpace(tscbSystemFontName.Text))
                {
                    var formula = tboxLatex.Text;
                    pboxFormula.Image = FormulaHelper.GetImage(formula, scale, tscbSystemFontName.Text);
                }
                UpdateControlsEnabled();
            }
            catch (Exception ex)
            {
                pboxFormula.Image = null;
                labFormulaPicture.ForeColor = Color.Red;
                labFormulaPicture.Text = "Ошибка: " + ex.Message;
                UpdateControlsEnabled();
            }
        }

        private void tsbCopyToClipboard_Click(object sender, EventArgs e)
        {
            var image = pboxFormula.Image;
            using (var bmp = new Bitmap(image.Width, image.Height))
            {
                using (var g = Graphics.FromImage(bmp))
                {
                    g.FillRectangle(Brushes.White, new Rectangle(0, 0, image.Width, image.Height));
                    g.DrawImageUnscaled(image, 0, 0);
                }
                Clipboard.SetImage(bmp);
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog(Owner) == DialogResult.OK)
            {
                pboxFormula.Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tsbSaveFormula.Enabled = tboxLatex.TextLength > 0;
            if (InputLanguage.CurrentInputLanguage.Culture.Name == "en-US")
            {
                tsbEN.Checked = true;
                tsbRU.Checked = false;
            }
            else if (InputLanguage.CurrentInputLanguage.Culture.Name == "ru-RU")
            {
                tsbRU.Checked = true;
                tsbEN.Checked = false;
            }
        }

        private void tsbClearFormula_Click(object sender, EventArgs e)
        {
#pragma warning disable CS8622 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует целевому объекту делегирования (возможно, из-за атрибутов допустимости значений NULL).
            tboxLatex.TextChanged -= tboxLatex_TextChanged;
#pragma warning restore CS8622 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует целевому объекту делегирования (возможно, из-за атрибутов допустимости значений NULL).
            tboxLatex.Text = string.Empty;
            labFormulaPicture.ForeColor = SystemColors.ControlText;
            labFormulaPicture.Text = "Картинка формулы:";
            pboxFormula.Image = null;
#pragma warning disable CS8622 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует целевому объекту делегирования (возможно, из-за атрибутов допустимости значений NULL).
            tboxLatex.TextChanged += tboxLatex_TextChanged;
#pragma warning restore CS8622 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует целевому объекту делегирования (возможно, из-за атрибутов допустимости значений NULL).
            UpdateControlsEnabled();
        }

        private void tsbSaveFormula_Click(object sender, EventArgs e)
        {
            if (saveFileDialog2.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog2.FileName, tboxLatex.Text);
            }
        }

        private void tsbLoadFormula_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog(this) == DialogResult.OK)
            {
                tboxLatex.Text = File.ReadAllText(openFileDialog2.FileName);
            }
        }

        private void FillNotations()
        {
            /*
            */
            var notes = new List<Notation>()
            {
                #region Латинский алфавит

                new("Латинский алфавит", @"a"),
                new("Латинский алфавит", @"b"),
                new("Латинский алфавит", @"c"),
                new("Латинский алфавит", @"d"),
                new("Латинский алфавит", @"e"),
                new("Латинский алфавит", @"f"),
                new("Латинский алфавит", @"g"),
                new("Латинский алфавит", @"h"),
                new("Латинский алфавит", @"i"),
                new("Латинский алфавит", @"j"),
                new("Латинский алфавит", @"k"),
                new("Латинский алфавит", @"l"),
                new("Латинский алфавит", @"m"),
                new("Латинский алфавит", @"n"),
                new("Латинский алфавит", @"o"),
                new("Латинский алфавит", @"p"),
                new("Латинский алфавит", @"q"),
                new("Латинский алфавит", @"r"),
                new("Латинский алфавит", @"s"),
                new("Латинский алфавит", @"t"),
                new("Латинский алфавит", @"u"),
                new("Латинский алфавит", @"v"),
                new("Латинский алфавит", @"x"),
                new("Латинский алфавит", @"y"),
                new("Латинский алфавит", @"z"),

                new("Латинский алфавит", @"A"),
                new("Латинский алфавит", @"B"),
                new("Латинский алфавит", @"C"),
                new("Латинский алфавит", @"D"),
                new("Латинский алфавит", @"E"),
                new("Латинский алфавит", @"F"),
                new("Латинский алфавит", @"G"),
                new("Латинский алфавит", @"H"),
                new("Латинский алфавит", @"I"),
                new("Латинский алфавит", @"J"),
                new("Латинский алфавит", @"K"),
                new("Латинский алфавит", @"L"),
                new("Латинский алфавит", @"M"),
                new("Латинский алфавит", @"N"),
                new("Латинский алфавит", @"O"),
                new("Латинский алфавит", @"P"),
                new("Латинский алфавит", @"Q"),
                new("Латинский алфавит", @"R"),
                new("Латинский алфавит", @"S"),
                new("Латинский алфавит", @"T"),
                new("Латинский алфавит", @"U"),
                new("Латинский алфавит", @"V"),
                new("Латинский алфавит", @"X"),
                new("Латинский алфавит", @"Y"),
                new("Латинский алфавит", @"Z"),

                #endregion

                #region Греческий алфавит

                new("Греческий алфавит", @"\alpha"),
                new("Греческий алфавит", @"\beta"),
                new("Греческий алфавит", @"\gamma"),
                new("Греческий алфавит", @"\delta"),
                new("Греческий алфавит", @"\epsilon"),
                new("Греческий алфавит", @"\zeta"),
                new("Греческий алфавит", @"\eta"),
                new("Греческий алфавит", @"\theta"),
                new("Греческий алфавит", @"\iota"),
                new("Греческий алфавит", @"\kappa"),
                new("Греческий алфавит", @"\lambda"),
                new("Греческий алфавит", @"\mu"),
                new("Греческий алфавит", @"\nu"),
                new("Греческий алфавит", @"\xi"),
                new("Греческий алфавит", @"\omicron"),
                new("Греческий алфавит", @"\pi"),
                new("Греческий алфавит", @"\rho"),
                new("Греческий алфавит", @"\sigma"),
                new("Греческий алфавит", @"\tau"),
                new("Греческий алфавит", @"\upsilon"),
                new("Греческий алфавит", @"\phi"),
                new("Греческий алфавит", @"\chi"),
                new("Греческий алфавит", @"\psi"),
                new("Греческий алфавит", @"\omega"),
                //new("Греческий алфавит", @"\Alpha"),
                //new("Греческий алфавит", @"\Beta"),
                new("Греческий алфавит", @"\Gamma"),
                new("Греческий алфавит", @"\Delta"),
                //new("Греческий алфавит", @"\Epsilon"),
                //new("Греческий алфавит", @"\Zeta"),
                //new("Греческий алфавит", @"\Eta"),
                new("Греческий алфавит", @"\Theta"),
                //new("Греческий алфавит", @"\Iota"),
                //new("Греческий алфавит", @"\Kappa"),
                new("Греческий алфавит", @"\Lambda"),
                //new("Греческий алфавит", @"\Mu"),
                //new("Греческий алфавит", @"\NU"),
                new("Греческий алфавит", @"\Xi"),
                //new("Греческий алфавит", @"\Omicron"),
                new("Греческий алфавит", @"\Pi"),
                //new("Греческий алфавит", @"\Rho"),
                new("Греческий алфавит", @"\Sigma"),
                //new("Греческий алфавит", @"\Tau"),
                new("Греческий алфавит", @"\Upsilon"),
                new("Греческий алфавит", @"\Phi"),
                //new("Греческий алфавит", @"\Chi"),
                new("Греческий алфавит", @"\Psi"),
                new("Греческий алфавит", @"\Omega"),
                
                #endregion

                #region Цифры

                new("Цифры", @"0"),
                new("Цифры", @"1"),
                new("Цифры", @"2"),
                new("Цифры", @"3"),
                new("Цифры", @"4"),
                new("Цифры", @"5"),
                new("Цифры", @"6"),
                new("Цифры", @"7"),
                new("Цифры", @"8"),
                new("Цифры", @"9"),

                #endregion


                #region Индексы

                new("Индексы", @"x_0", @"_0"),
                new("Индексы", @" _1", @"_1"),
                new("Индексы", @" _2", @"_2"),
                new("Индексы", @" _3", @"_3"),
                new("Индексы", @" _4", @"_4"),
                new("Индексы", @" _5", @"_5"),
                new("Индексы", @" _6", @"_6"),
                new("Индексы", @" _7", @"_7"),
                new("Индексы", @" _8", @"_8"),
                new("Индексы", @" _9", @"_9"),
                new("Индексы", @" _{01}", @"_{01}"),
                new("Индексы", @" _{02}", @"_{02}"),
                new("Индексы", @" _{03}", @"_{03}"),

                #endregion

                #region Степени

                new("Степени", @"x^0", @"^0"),
                new("Степени", @" ^1", @"^1"),
                new("Степени", @" ^2", @"^2"),
                new("Степени", @" ^3", @"^3"),
                new("Степени", @" ^4", @"^4"),
                new("Степени", @" ^5", @"^5"),
                new("Степени", @" ^6", @"^6"),
                new("Степени", @" ^7", @"^7"),
                new("Степени", @" ^8", @"^8"),
                new("Степени", @" ^9", @"^9"),
                new("Степени", @" ^*", @"^*"),

                #endregion


                #region Математические функции

                new("Математические функции", @"x_{a}"),                        // Нижний индекс
                new("Математические функции", @"x^{b}"),                        // Верхний индекс
                new("Математические функции", @"{ _a ^b}x"),                    // Индексы слева
                new("Математические функции", @"\sqrt{}", @"\sqrt{}", 1),       // Квадратный корень
                new("Математические функции", @"\sqrt[3]{}", @"\sqrt[3]{}", 1), // Кубический корень
                new("Математические функции", @"\frac{a}{b+c}", @"\frac{}{}", 3),   // Деление: в первых скобках числитель, во вторых скобках знаменатель
                //new("Математические функции", @"\longrightarrow"),    // Длинная стрелка слева направо
                
                #endregion

                #region Бинарные операции

                new("Бинарные операции", @"="),
                new("Бинарные операции", @"+"),
                new("Бинарные операции", @"-"),
                new("Бинарные операции", @"\times"),
                new("Бинарные операции", @"/"),
                new("Бинарные операции", @"\div"),
                new("Бинарные операции", @"\cdot"),
                new("Бинарные операции", @"\ast"),
                new("Бинарные операции", @"\pm"),
                new("Бинарные операции", @"\mp"),
                new("Бинарные операции", @"\star"),
                new("Бинарные операции", @"\dagger"),
                new("Бинарные операции", @"\ddagger"),
                new("Бинарные операции", @"\cap"),
                new("Бинарные операции", @"\cup"),
                new("Бинарные операции", @"\uplus"),
                new("Бинарные операции", @"\sqcap"),
                new("Бинарные операции", @"\sqcup"),
                new("Бинарные операции", @"\vee"),
                new("Бинарные операции", @"\wedge"),
                new("Бинарные операции", @"\diamond"),
                new("Бинарные операции", @"\bigtriangleup"),
                new("Бинарные операции", @"\bigtriangledown"),
                new("Бинарные операции", @"\triangleleft"),
                new("Бинарные операции", @"\triangleright"),
                new("Бинарные операции", @"\bigcirc"),
                new("Бинарные операции", @"\bullet"),
                new("Бинарные операции", @"\wr"),
                new("Бинарные операции", @"\oplus"),
                new("Бинарные операции", @"\ominus"),
                new("Бинарные операции", @"\otimes"),
                new("Бинарные операции", @"\oslash"),
                new("Бинарные операции", @"\odot"),
                new("Бинарные операции", @"\circ"),
                new("Бинарные операции", @"\setminus"),
                new("Бинарные операции", @"\amalg"),
                new("Бинарные операции", @"\ldots"),            // Многоточие
                new("Бинарные операции", @"\sim"),              // Тильда
                
                #endregion

                new("Ряды и интегралы", @"\sum_{i=1}^{\infty} f_i"),    // Большой знак суммы
                new("Ряды и интегралы", @"\prod"),                      // Большой знак произведения
                new("Ряды и интегралы", @"\lim_{x\to\infty}"),          // Предел
                new("Ряды и интегралы", @"\int_{a}^{b}x^2 dx"),         // Интеграл

                #region Разделители

                new("Разделители", @"|"),
                new("Разделители", @"\|"),
                new("Разделители", @"("),
                new("Разделители", @")"),
                new("Разделители", @"\{"),
                new("Разделители", @"\}"),
                new("Разделители", @"\lceil"),
                new("Разделители", @"\rceil"),
                new("Разделители", @"\ulcorner"),
                new("Разделители", @"\urcorner"),
                new("Разделители", @"/"),
                new("Разделители", @"\backslash"),
                new("Разделители", @"["),
                new("Разделители", @"]"),
                new("Разделители", @"\langle"),
                new("Разделители", @"\rangle"),
                new("Разделители", @"\lfloor"),
                new("Разделители", @"\rfloor"),
                new("Разделители", @"\llcorner"),
                new("Разделители", @"\lrcorner"),
                
                #endregion

                #region Операторы отношений

                new("Операторы отношений", @"="),               // Равно
                new("Операторы отношений", @"\neq"),            // Не равно
                new("Операторы отношений", @"<"),               // Меньше чем
                //new("Операторы отношений", @"\nless"),        // Не меньше чем
                new("Операторы отношений", @"\leq"),            // Меньше или равен
                new("Операторы отношений", @"\leqslant"),       // Меньше или равен
                //new("Операторы отношений", @"\nleq"),         // Не меньше и не равен
                //new("Операторы отношений", @"\nleqslant"),    // Не меньше и не равен
                new("Операторы отношений", @"\prec"),           // Предшествует
                //new("Операторы отношений", @"\nprec"),        // Не предшествует
                new("Операторы отношений", @"\preceq"),         // Предшествует или равняется
                //new("Операторы отношений", @"\npreceq"),      // Не предшествует и не равняется
                new("Операторы отношений", @"\ll"),             // 
                new("Операторы отношений", @"\lll"),            // 
                new("Операторы отношений", @"\subset"),         // Строгое подмножество
                new("Операторы отношений", @"\not\subset"),     // Не является строгим подмножеством
                new("Операторы отношений", @"\subseteq"),       // Нестрогое подмножество
                //new("Операторы отношений", @"\nsubseteq"),    // Не являетя подмножеством
                new("Операторы отношений", @"\sqsubset"),       // 
                new("Операторы отношений", @"\sqsubseteq"),     //
                new("Операторы отношений", @">"),               // Больше чем
                //new("Операторы отношений", @"\ngtr"),         // Не больше чем
                new("Операторы отношений", @"\geq"),            // Больше или равно
                new("Операторы отношений", @"\geqslant"),       // Больше или равно
                //new("Операторы отношений", @"\ngeq"),         // Не больше и не равно
                //new("Операторы отношений", @"\ngeqslant"),    // is neither greater than nor equal to
                new("Операторы отношений", @"\succ"),           // Следует за
                //new("Операторы отношений", @"\nsucc"),        // не следует за
                new("Операторы отношений", @"\succeq"),         // следует за или равняется
                //new("Операторы отношений", @"\nsucceq"),      // не следует за и не равняется
                new("Операторы отношений", @"\gg"),             // 
                new("Операторы отношений", @"\ggg"),            // 
                new("Операторы отношений", @"\supset"),         // Строгое надмножество
                new("Операторы отношений", @"\not\supset"),     // Не является строгим надмножеством
                new("Операторы отношений", @"\supseteq"),       // Нестрогое надмножество
                //new("Операторы отношений", @"\nsupseteq"),    // Не является надмножеством
                new("Операторы отношений", @"\sqsupset"),       // 
                new("Операторы отношений", @"\sqsupseteq"),     // 

                new("Операторы отношений", @"\parallel"),       // Параллельно
                //new("Операторы отношений", @"\nparallel"),    // Не параллельно
                new("Операторы отношений", @"\asymp"),          // Асимптотический
                new("Операторы отношений", @"\bowtie"),         // 
                new("Операторы отношений", @"\vdash"),          // 
                new("Операторы отношений", @"\dashv"),          // 
                new("Операторы отношений", @"\in"),             // Является членом
                new("Операторы отношений", @"\ni"),             // Содержит член
                new("Операторы отношений", @"\smile"),          // 
                new("Операторы отношений", @"\frown"),          // 
                new("Операторы отношений", @"\models"),         // 
                //new("Операторы отношений", @"\notin"),        // Не содержится в
                new("Операторы отношений", @"\perp"),           // Перпендикулярен
                new("Операторы отношений", @"\mid"),            // Делится на
                new("Операторы отношений", @"\sphericalangle"),
                new("Операторы отношений", @"\measuredangle"),
                new("Операторы отношений", @"\therefore"),
                new("Операторы отношений", @"\because"),

                #endregion

                #region Набор логических нотаций
                
                new("Набор и/или логических нотаций", @"\exists"),
                //new("Набор и/или логических нотаций", @"\nexists"),
                new("Набор и/или логических нотаций", @"\forall"),
                new("Набор и/или логических нотаций", @"\neg"),
                new("Набор и/или логических нотаций", @"\subset"),
                new("Набор и/или логических нотаций", @"\supset"),
                new("Набор и/или логических нотаций", @"\in"),
                //new("Набор и/или логических нотаций", @"\notin"),
                new("Набор и/или логических нотаций", @"\ni"),
                new("Набор и/или логических нотаций", @"\land"),
                new("Набор и/или логических нотаций", @"\lor"),
                new("Набор и/или логических нотаций", @"\angle"),
                new("Набор и/или логических нотаций", @"\to"),
                new("Набор и/или логических нотаций", @"\gets"),
                //new("Набор и/или логических нотаций", @"\mapsto"),
                //new("Набор и/или логических нотаций", @"\implies"),
                //new("Набор и/или логических нотаций", @"\impliedby"),
                new("Набор и/или логических нотаций", @"\leftrightarrow"),
                new("Набор и/или логических нотаций", @"\top"),
                new("Набор и/или логических нотаций", @"\bot"),
                new("Набор и/или логических нотаций", @"\emptyset"),
                //new("Набор и/или логических нотаций", @"\varnothing"),
                new("Набор и/или логических нотаций", @"\rightleftharpoons"),

                #endregion

                 #region Акценты

                new("Акценты", @"a^{\prime}"),
                new("Акценты", @"\hat{a}"),
                new("Акценты", @"\grave{a}"),
                new("Акценты", @"\dot{a}"),
                new("Акценты", @"\not{a}"),
                new("Акценты", @"a''"),
                new("Акценты", @"\bar{a}"),
                new("Акценты", @"\acute{a}"),
                new("Акценты", @"\ddot{a}"),
                //new("Акценты", @"\mathring{a}"),
                new("Акценты", @"a'''"),
                new("Акценты", @"a''''"),
                new("Акценты", @"\overline{aaa}"),
                new("Акценты", @"\check{a}"),
                new("Акценты", @"\breve{a}"),
                new("Акценты", @"\vec{a}"),
                new("Акценты", @"\tilde{a}"),
                new("Акценты", @"\underline{a}"),
                new("Акценты", @"\widehat{AAA}"),
                new("Акценты", @"\widetilde{AAA}"),
                //new("Акценты", @"\stackrel\frown{AAA}"),
                
                #endregion
               
           };
            var row = 0;
            tlpNotes.ColumnCount = 1;
            tlpNotes.ColumnStyles.Clear();
            tlpNotes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));

            tlpNotes.RowCount = notes.GroupBy(note => note.Category).Count() * 2;
            tlpNotes.RowStyles.Clear();
            foreach (var note in notes)
                tlpNotes.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            foreach (var noteCategory in notes.GroupBy(note => note.Category))
            {
                var labCategoryName = new Label() { Text = noteCategory.Key, AutoSize = true, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter };
                tlpNotes.Controls.Add(labCategoryName, 0, row++);
                var flp = new FlowLayoutPanel() { AutoSize = true, Dock = DockStyle.Fill };
                tlpNotes.Controls.Add(flp, 0, row++);
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
                var width = noteCategory.Any(note => !note.ErrorInFormula) ? noteCategory.Where(note => !note.ErrorInFormula).Max(note => note.Picture.Width) : 0;
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
                var height = noteCategory.Any(note => !note.ErrorInFormula) ? noteCategory.Where(note => !note.ErrorInFormula).Max(note => note.Picture.Height) : 0;
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
                foreach (var note in noteCategory)
                {
                    if (note.ErrorInFormula)
                    {
                        if (flp.Controls.Count > 0)
                            flp.SetFlowBreak(flp.Controls[flp.Controls.Count - 1], true);
                        var labError = new Label
                        {
                            AutoSize = true,
                            Text = note.ErrorInFormulaText,
                            TextAlign = ContentAlignment.TopLeft,
                        };
                        flp.Controls.Add(labError);
                        flp.SetFlowBreak(labError, true);
                    }
                    else
                    {
                        var pic = note.Picture;
                        var btn = new Button
                        {
                            Tag = note,
                            Image = pic,
                            Width = width + 5,
                            Height = height + 5,
                            FlatStyle = FlatStyle.Flat,
                            Cursor = Cursors.Hand,
                        };
                        btn.FlatAppearance.BorderColor = SystemColors.ButtonFace;
                        btn.Click += (s, e) =>
                        {
                            var note = (Notation)btn.Tag;
                            var start = tboxLatex.SelectionStart;
                            var value = note.Pasted;
                            tboxLatex.SelectedText = value;
                            tboxLatex.SelectionStart = start + value.Length - note.Offset;
                            tboxLatex.Focus();
                        };
                        flp.Controls.Add(btn);
                    }
                }
            }
        }

        private void tsbShowHideNotes_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = !tsbShowHideNotes.Checked;
        }

        private void btnInsertFunction_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            tboxLatex.SelectedText = btn.Text;
            if (int.TryParse($"{btn.Tag}", out int offset))
                tboxLatex.SelectionStart -= offset;
            tboxLatex.Focus();
            if (btn.Text == @"\text{}")
                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("ru-RU"));
        }

        private void tsbMoreFontSize_Click(object sender, EventArgs e)
        {
            tscbScale.SelectedIndex++;
        }

        private void tsbLessFontSize_Click(object sender, EventArgs e)
        {
            tscbScale.SelectedIndex--;
        }

        private void labFunctions_Click(object sender, EventArgs e)
        {
            ManageUserFunctions();
        }

        private void ManageUserFunctions()
        {
            var functions = Properties.Settings.Default.UserFunctions;
            if (string.IsNullOrEmpty(functions))
                functions = predefined;
            var frm = new UserFunctionsTuningForm();
            frm.Build(functions);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.UserFunctions = frm.Data;
                Properties.Settings.Default.Save();
                LoadUserFunctions();
            }
        }

        private void LoadUserFunctions()
        {
            for (var i = flpUserFunctions.Controls.Count - 1; i > 0; i--)
            {
#pragma warning disable CS8622 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует целевому объекту делегирования (возможно, из-за атрибутов допустимости значений NULL).
                flpUserFunctions.Controls[i].Click -= btnInsertFunction_Click;
#pragma warning restore CS8622 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует целевому объекту делегирования (возможно, из-за атрибутов допустимости значений NULL).
                flpUserFunctions.Controls.RemoveAt(i);
            }
            var functions = Properties.Settings.Default.UserFunctions;
            if (string.IsNullOrEmpty(functions))
                functions = predefined;
            foreach (var line in functions.Split('\n', StringSplitOptions.RemoveEmptyEntries))
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
                    FlatStyle = FlatStyle.Flat
                };
#pragma warning disable CS8622 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует целевому объекту делегирования (возможно, из-за атрибутов допустимости значений NULL).
                btn.Click += btnInsertFunction_Click;
#pragma warning restore CS8622 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует целевому объекту делегирования (возможно, из-за атрибутов допустимости значений NULL).
                flpUserFunctions.Controls.Add(btn);
            }
        }

        private void tboxLatex_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-US"));
        }

        private void tsbEN_Click(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-US"));
        }

        private void tsbRU_Click(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("ru-RU"));
        }
    }
}
