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
            tboxLatex.Text = @"ax^2+bx+c=0;\text{ ���������� ���������}";
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
                    pboxFormula.Image = GetImage(tboxLatex.Text, scale, tscbSystemFontName.Text);
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
            tboxLatex.TextChanged -= tboxLatex_TextChanged;
            tboxLatex.Text = string.Empty;
            labFormulaPicture.ForeColor = SystemColors.ControlText;
            labFormulaPicture.Text = "�������� �������:";
            pboxFormula.Image = null;
            tboxLatex.TextChanged += tboxLatex_TextChanged;
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
            var category = "��������� �������";
            var notes = new List<Notation>()
            {
                new(category, @"\alpha"),
                new(category, @"\beta"),
                new(category, @"\gamma"),
                new(category, @"\delta"),
                new(category, @"\epsilon"),
                new(category, @"\zeta"),
                new(category, @"\eta"),
                new(category, @"\theta"),
                new(category, @"\iota"),
                new(category, @"\kappa"),
                new(category, @"\lambda"),
                new(category, @"\mu"),
                new(category, @"\nu"),
                new(category, @"\xi"),
                new(category, @"\omicron"),
                new(category, @"\pi"),
                new(category, @"\rho"),
                new(category, @"\sigma"),
                new(category, @"\tau"),
                new(category, @"\upsilon"),
                new(category, @"\phi"),
                new(category, @"\chi"),
                new(category, @"\psi"),
                new(category, @"\omega"),
 //               new(@"\frac{�C}{2}"),
 //               new(@"\sqrt{\frac{a}{b}}"),
 //               new(@"\sum_{i=1}^{10} t_i"),
 //               new(@"\int_0^\infty e^{-x}\,\mathrm{d}x"),
 //               new(@"\int_a^b"),
 //               new(@"(a),[b],\{c\},|d|,\|e\|"),
 //               new(@"\langle f \rangle,\lfloor g \rfloor,\lceil h \rceil"),
 //               new(@"\ulcorner i \urcorner,/ j \backslash"),
 //               new(@"\left(\frac{x^2}{y^3}\right)"),
 //               new(@"k_{n+1} = n^2 + k_n^2 - k_{n-1}"),
 //               new(@"A_{m,n} = 
 //\begin{pmatrix}
 // a_{1,1} & a_{1,2} & \cdots & a_{1,n} \\
 // a_{2,1} & a_{2,2} & \cdots & a_{2,n} \\
 // \cdots  &         &        &         \\
 // a_{m,1} & a_{m,2} & \cdots & a_{m,n} \\
 //\end{pmatrix}"),
            };
            var row = 0;
            tlpNotes.ColumnCount = 1;
            tlpNotes.ColumnStyles.Clear();
            tlpNotes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            //tlpNotes.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpNotes.RowCount = notes.Count;
            tlpNotes.RowStyles.Clear();
            foreach (var note in notes)
                tlpNotes.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            foreach (var noteCategory in notes.GroupBy(note => note.Category))
            {
                var labCategoryName = new Label() { Text = noteCategory.Key, AutoSize = true };
                tlpNotes.Controls.Add(labCategoryName, 0, row++);
                var flp = new FlowLayoutPanel() { AutoSize = true, Dock = DockStyle.Fill };
                tlpNotes.Controls.Add(flp, 0, row++);
                var height = noteCategory.Where(note => !note.ErrorInFormula).Max(note => note.Picture.Height);
                foreach (var note in noteCategory)
                {
                    if (note.ErrorInFormula)
                    {
                        var pic = note.Picture;
                        flp.Controls.Add(
                            new Label
                            {
                                Image = pic,
                                Width = pic.Width,
                                Height = pic.Height,
                                TextAlign = ContentAlignment.MiddleCenter,
                            });
                    }
                    else
                    {
                        var pic = note.Picture;
                        var btn = new Button
                        {
                            Tag = note.Formula,
                            Image = pic,
                            Width = pic.Width + 5,
                            Height = height + 5, //pic.Height + 5,
                            FlatStyle = FlatStyle.Flat,
                        };
                        btn.Click += (s, e) => { tboxLatex.SelectedText = $"{btn.Tag}"; };
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
    }
}
