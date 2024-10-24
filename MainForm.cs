using System.ComponentModel;
using System.Drawing.Text;
using WpfMath;
using WpfMath.Parsers;

namespace PictureFromLatexFormula
{
    public partial class MainForm : Form
    {
        readonly InstalledFontCollection installedFontCollection = new();
        readonly BackgroundWorker worker = new();

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
            tableLayoutPanel1.Enabled = true;
        }

        private static bool CheckFontName(string name)
        {
            var parser = WpfTeXFormulaParser.Instance;
            try
            {
                var formula = parser.Parse(@"\text{����}");
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
                labFormulaPicture.Text = "�������� �������:";
                if (tboxLatex.TextLength > 0 &&
                    double.TryParse(tscbScale.Text, out double scale) &&
                    !string.IsNullOrWhiteSpace(tscbSystemFontName.Text))
                {
                    var formula = tboxLatex.Text;
                    pboxFormula.Image = GetImage(formula, scale, tscbSystemFontName.Text);
                }
                UpdateControlsEnabled();
            }
            catch (Exception ex)
            {
                pboxFormula.Image = null;
                labFormulaPicture.ForeColor = Color.Red;
                labFormulaPicture.Text = "������: " + ex.Message;
                UpdateControlsEnabled();
            }
        }

        /// <summary>
        /// ������� �������� �� ���� �� ������� � ������� latex
        /// </summary>
        /// <param name="latex">�������</param>
        /// <returns>���������� ��������</returns>
        public static Image GetImage(string latex, double scale = 20.0, string systemFontName = "Times New Roman")
        {
            var parser = WpfTeXFormulaParser.Instance;
            var formula = parser.Parse(latex);
            var pngBytes = formula.RenderToPng(scale, 0.0, 0.0, systemFontName);
            using (var stream = new MemoryStream(pngBytes))
            {
                return Image.FromStream(stream);
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
        }

        private void tsbClearFormula_Click(object sender, EventArgs e)
        {
#pragma warning disable CS8622 // ������������ �������� NULL ��� ��������� ����� � ���� ��������� �� ������������� �������� ������� ������������� (��������, ��-�� ��������� ������������ �������� NULL).
            tboxLatex.TextChanged -= tboxLatex_TextChanged;
#pragma warning restore CS8622 // ������������ �������� NULL ��� ��������� ����� � ���� ��������� �� ������������� �������� ������� ������������� (��������, ��-�� ��������� ������������ �������� NULL).
            tboxLatex.Text = string.Empty;
            labFormulaPicture.ForeColor = SystemColors.ControlText;
            labFormulaPicture.Text = "�������� �������:";
            pboxFormula.Image = null;
#pragma warning disable CS8622 // ������������ �������� NULL ��� ��������� ����� � ���� ��������� �� ������������� �������� ������� ������������� (��������, ��-�� ��������� ������������ �������� NULL).
            tboxLatex.TextChanged += tboxLatex_TextChanged;
#pragma warning restore CS8622 // ������������ �������� NULL ��� ��������� ����� � ���� ��������� �� ������������� �������� ������� ������������� (��������, ��-�� ��������� ������������ �������� NULL).
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

                #region �������������� �������

                new("�������������� �������", @"x_{a}"),                // ������ ������
                new("�������������� �������", @"x^{b}"),                // ������� ������
                new("�������������� �������", @"{ _a ^b}x"),            // ������� �����
                new("�������������� �������", @"\sqrt{}"),              // ���������� ������
                new("�������������� �������", @"\sqrt[3]{}"),           // ���������� ������
                new("�������������� �������", @"\frac{a}{b+c}"),        // �������: � ������ ������� ���������, �� ������ ������� �����������
                //new("�������������� �������", @"\longrightarrow"),    // ������� ������� ����� �������
                new("���� � ���������", @"\sum_{i=1}^{\infty} f_i"),    // ������� ���� �����
                new("���� � ���������", @"\prod"),                      // ������� ���� ������������
                new("���� � ���������", @"\lim_{x\to\infty}"),          // ������
                new("���� � ���������", @"\int_{a}^{b}x^2 dx"),         // ��������
                
                #endregion
                
                #region �������� ��������
                
                new("�������� ��������", @"\pm"),
                new("�������� ��������", @"\mp"),
                new("�������� ��������", @"\times"),
                new("�������� ��������", @"\div"),
                new("�������� ��������", @"\ast"),
                new("�������� ��������", @"\star"),
                new("�������� ��������", @"\dagger"),
                new("�������� ��������", @"\ddagger"),
                new("�������� ��������", @"\cap"),
                new("�������� ��������", @"\cup"),
                new("�������� ��������", @"\uplus"),
                new("�������� ��������", @"\sqcap"),
                new("�������� ��������", @"\sqcup"),
                new("�������� ��������", @"\vee"),
                new("�������� ��������", @"\wedge"),
                new("�������� ��������", @"\cdot"),
                new("�������� ��������", @"\diamond"),
                new("�������� ��������", @"\bigtriangleup"),
                new("�������� ��������", @"\bigtriangledown"),
                new("�������� ��������", @"\triangleleft"),
                new("�������� ��������", @"\triangleright"),
                new("�������� ��������", @"\bigcirc"),
                new("�������� ��������", @"\bullet"),
                new("�������� ��������", @"\wr"),
                new("�������� ��������", @"\oplus"),
                new("�������� ��������", @"\ominus"),
                new("�������� ��������", @"\otimes"),
                new("�������� ��������", @"\oslash"),
                new("�������� ��������", @"\odot"),
                new("�������� ��������", @"\circ"),
                new("�������� ��������", @"\setminus"),
                new("�������� ��������", @"\amalg"),
                new("�������� ��������", @"\ldots"),            // ����������
                new("�������� ��������", @"\sim"),              // ������
                
                #endregion

                #region �����������

                new("�����������", @"|"),
                new("�����������", @"\|"),
                new("�����������", @"("),
                new("�����������", @")"),
                new("�����������", @"\{"),
                new("�����������", @"\}"),
                new("�����������", @"\lceil"),
                new("�����������", @"\rceil"),
                new("�����������", @"\ulcorner"),
                new("�����������", @"\urcorner"),
                new("�����������", @"/"),
                new("�����������", @"\backslash"),
                new("�����������", @"["),
                new("�����������", @"]"),
                new("�����������", @"\langle"),
                new("�����������", @"\rangle"),
                new("�����������", @"\lfloor"),
                new("�����������", @"\rfloor"),
                new("�����������", @"\llcorner"),
                new("�����������", @"\lrcorner"),
                
                #endregion

                #region ��������� ���������

                new("��������� ���������", @"="),               // �����
                new("��������� ���������", @"\neq"),            // �� �����
                new("��������� ���������", @"<"),               // ������ ���
                //new("��������� ���������", @"\nless"),        // �� ������ ���
                new("��������� ���������", @"\leq"),            // ������ ��� �����
                new("��������� ���������", @"\leqslant"),       // ������ ��� �����
                //new("��������� ���������", @"\nleq"),         // �� ������ � �� �����
                //new("��������� ���������", @"\nleqslant"),    // �� ������ � �� �����
                new("��������� ���������", @"\prec"),           // ������������
                //new("��������� ���������", @"\nprec"),        // �� ������������
                new("��������� ���������", @"\preceq"),         // ������������ ��� ���������
                //new("��������� ���������", @"\npreceq"),      // �� ������������ � �� ���������
                new("��������� ���������", @"\ll"),             // 
                new("��������� ���������", @"\lll"),            // 
                new("��������� ���������", @"\subset"),         // ������� ������������
                new("��������� ���������", @"\not\subset"),     // �� �������� ������� �������������
                new("��������� ���������", @"\subseteq"),       // ��������� ������������
                //new("��������� ���������", @"\nsubseteq"),    // �� ������� �������������
                new("��������� ���������", @"\sqsubset"),       // 
                new("��������� ���������", @"\sqsubseteq"),     //
                new("��������� ���������", @">"),               // ������ ���
                //new("��������� ���������", @"\ngtr"),         // �� ������ ���
                new("��������� ���������", @"\geq"),            // ������ ��� �����
                new("��������� ���������", @"\geqslant"),       // ������ ��� �����
                //new("��������� ���������", @"\ngeq"),         // �� ������ � �� �����
                //new("��������� ���������", @"\ngeqslant"),    // is neither greater than nor equal to
                new("��������� ���������", @"\succ"),           // ������� ��
                //new("��������� ���������", @"\nsucc"),        // �� ������� ��
                new("��������� ���������", @"\succeq"),         // ������� �� ��� ���������
                //new("��������� ���������", @"\nsucceq"),      // �� ������� �� � �� ���������
                new("��������� ���������", @"\gg"),             // 
                new("��������� ���������", @"\ggg"),            // 
                new("��������� ���������", @"\supset"),         // ������� ������������
                new("��������� ���������", @"\not\supset"),     // �� �������� ������� �������������
                new("��������� ���������", @"\supseteq"),       // ��������� ������������
                //new("��������� ���������", @"\nsupseteq"),    // �� �������� �������������
                new("��������� ���������", @"\sqsupset"),       // 
                new("��������� ���������", @"\sqsupseteq"),     // 

                new("��������� ���������", @"\parallel"),       // �����������
                //new("��������� ���������", @"\nparallel"),    // �� �����������
                new("��������� ���������", @"\asymp"),          // ���������������
                new("��������� ���������", @"\bowtie"),         // 
                new("��������� ���������", @"\vdash"),          // 
                new("��������� ���������", @"\dashv"),          // 
                new("��������� ���������", @"\in"),             // �������� ������
                new("��������� ���������", @"\ni"),             // �������� ����
                new("��������� ���������", @"\smile"),          // 
                new("��������� ���������", @"\frown"),          // 
                new("��������� ���������", @"\models"),         // 
                //new("��������� ���������", @"\notin"),        // �� ���������� �
                new("��������� ���������", @"\perp"),           // ���������������
                new("��������� ���������", @"\mid"),            // ������� ��
                new("��������� ���������", @"\sphericalangle"),
                new("��������� ���������", @"\measuredangle"),
                new("��������� ���������", @"\therefore"),
                new("��������� ���������", @"\because"),

                #endregion

                #region ����� ���������� �������
                
                new("����� �/��� ���������� �������", @"\exists"),
                //new("����� �/��� ���������� �������", @"\nexists"),
                new("����� �/��� ���������� �������", @"\forall"),
                new("����� �/��� ���������� �������", @"\neg"),
                new("����� �/��� ���������� �������", @"\subset"),
                new("����� �/��� ���������� �������", @"\supset"),
                new("����� �/��� ���������� �������", @"\in"),
                //new("����� �/��� ���������� �������", @"\notin"),
                new("����� �/��� ���������� �������", @"\ni"),
                new("����� �/��� ���������� �������", @"\land"),
                new("����� �/��� ���������� �������", @"\lor"),
                new("����� �/��� ���������� �������", @"\angle"),
                new("����� �/��� ���������� �������", @"\to"),
                new("����� �/��� ���������� �������", @"\gets"),
                //new("����� �/��� ���������� �������", @"\mapsto"),
                //new("����� �/��� ���������� �������", @"\implies"),
                //new("����� �/��� ���������� �������", @"\impliedby"),
                new("����� �/��� ���������� �������", @"\leftrightarrow"),
                new("����� �/��� ���������� �������", @"\top"),
                new("����� �/��� ���������� �������", @"\bot"),
                new("����� �/��� ���������� �������", @"\emptyset"),
                //new("����� �/��� ���������� �������", @"\varnothing"),
                new("����� �/��� ���������� �������", @"\rightleftharpoons"),

                #endregion

                #region ��������� �������

                new("��������� �������", @"\alpha"),
                new("��������� �������", @"\beta"),
                new("��������� �������", @"\gamma"),
                new("��������� �������", @"\delta"),
                new("��������� �������", @"\epsilon"),
                new("��������� �������", @"\zeta"),
                new("��������� �������", @"\eta"),
                new("��������� �������", @"\theta"),
                new("��������� �������", @"\iota"),
                new("��������� �������", @"\kappa"),
                new("��������� �������", @"\lambda"),
                new("��������� �������", @"\mu"),
                new("��������� �������", @"\nu"),
                new("��������� �������", @"\xi"),
                new("��������� �������", @"\omicron"),
                new("��������� �������", @"\pi"),
                new("��������� �������", @"\rho"),
                new("��������� �������", @"\sigma"),
                new("��������� �������", @"\tau"),
                new("��������� �������", @"\upsilon"),
                new("��������� �������", @"\phi"),
                new("��������� �������", @"\chi"),
                new("��������� �������", @"\psi"),
                new("��������� �������", @"\omega"),
                //new("��������� �������", @"\Alpha"),
                //new("��������� �������", @"\Beta"),
                new("��������� �������", @"\Gamma"),
                new("��������� �������", @"\Delta"),
                //new("��������� �������", @"\Epsilon"),
                //new("��������� �������", @"\Zeta"),
                //new("��������� �������", @"\Eta"),
                new("��������� �������", @"\Theta"),
                //new("��������� �������", @"\Iota"),
                //new("��������� �������", @"\Kappa"),
                new("��������� �������", @"\Lambda"),
                //new("��������� �������", @"\Mu"),
                //new("��������� �������", @"\NU"),
                new("��������� �������", @"\Xi"),
                //new("��������� �������", @"\Omicron"),
                new("��������� �������", @"\Pi"),
                //new("��������� �������", @"\Rho"),
                new("��������� �������", @"\Sigma"),
                //new("��������� �������", @"\Tau"),
                new("��������� �������", @"\Upsilon"),
                new("��������� �������", @"\Phi"),
                //new("��������� �������", @"\Chi"),
                new("��������� �������", @"\Psi"),
                new("��������� �������", @"\Omega"),
                
                #endregion

                 #region �������

                new("�������", @"a^{\prime}"),
                new("�������", @"\hat{a}"),
                new("�������", @"\grave{a}"),
                new("�������", @"\dot{a}"),
                new("�������", @"\not{a}"),
                new("�������", @"a''"),
                new("�������", @"\bar{a}"),
                new("�������", @"\acute{a}"),
                new("�������", @"\ddot{a}"),
                //new("�������", @"\mathring{a}"),
                new("�������", @"a'''"),
                new("�������", @"a''''"),
                new("�������", @"\overline{aaa}"),
                new("�������", @"\check{a}"),
                new("�������", @"\breve{a}"),
                new("�������", @"\vec{a}"),
                new("�������", @"\tilde{a}"),
                new("�������", @"\underline{a}"),
                new("�������", @"\widehat{AAA}"),
                new("�������", @"\widetilde{AAA}"),
                //new("�������", @"\stackrel\frown{AAA}"),
                
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
#pragma warning disable CS8602 // ������������� ��������� ������ ������.
                var width = noteCategory.Where(note => !note.ErrorInFormula).Max(note => note.Picture.Width);
#pragma warning restore CS8602 // ������������� ��������� ������ ������.
#pragma warning disable CS8602 // ������������� ��������� ������ ������.
                var height = noteCategory.Where(note => !note.ErrorInFormula).Max(note => note.Picture.Height);
#pragma warning restore CS8602 // ������������� ��������� ������ ������.
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
                            Tag = note.Formula,
                            Image = pic,
                            Width = width + 5,
                            Height = height + 5,
                            FlatStyle = FlatStyle.Flat,
                        };
                        btn.Click += (s, e) =>
                        {
                            tboxLatex.SelectedText = $"{btn.Tag}";
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
            var frm = new UserFunctionsTuningForm();
            frm.Build(Properties.Settings.Default.UserFunctions);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.UserFunctions = frm.Data;
                Properties.Settings.Default.Save();
                LoadUserFunctions();
            }
            //foreach (var btn in flpUserFunctions.Controls.OfType<Button>())
            //{
            //    var item = new UserFunction(btn.Text, btn.Text, int.TryParse($"{btn.Tag}", out int pos) ? pos : 0);
            //    list.Add(item.ToString());
            //}
            //Properties.Settings.Default.UserFunctions = string.Join("\n", list.ToArray());
            //Properties.Settings.Default.Save();
        }

        private void LoadUserFunctions()
        {
            for (var i = flpUserFunctions.Controls.Count - 1; i > 1; i--)
                flpUserFunctions.Controls.RemoveAt(i);
            foreach (var line in Properties.Settings.Default.UserFunctions.Split('\n'))
            {
                var vals = line.Split('\t');
                var item = new UserFunction();
                item.Build(line);
                var btn = new Button 
                { 
                    Text = item.CaptionFormula, 
                    Tag = item.OffsetPosition, 
                    AutoSize = true, 
                    FlatStyle = FlatStyle.Flat 
                };
                btn.Click += btnInsertFunction_Click;
                flpUserFunctions.Controls.Add(btn);
            }
        }
    }
}
