namespace PictureFromLatexFormula
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            labFormulaPicture = new Label();
            tboxLatex = new TextBox();
            panel1 = new Panel();
            pboxFormula = new PictureBox();
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            tscbScale = new ToolStripComboBox();
            toolStripLabel2 = new ToolStripLabel();
            tscbSystemFontName = new ToolStripComboBox();
            toolStripSeparator1 = new ToolStripSeparator();
            tsbCopyToClipboard = new ToolStripButton();
            tsbSave = new ToolStripButton();
            toolStrip2 = new ToolStrip();
            создатьToolStripButton = new ToolStripButton();
            открытьToolStripButton = new ToolStripButton();
            сохранитьToolStripButton = new ToolStripButton();
            toolStripSeparator = new ToolStripSeparator();
            копироватьToolStripButton = new ToolStripButton();
            вставитьToolStripButton = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            справкаToolStripButton = new ToolStripButton();
            saveFileDialog1 = new SaveFileDialog();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pboxFormula).BeginInit();
            toolStrip1.SuspendLayout();
            toolStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(labFormulaPicture, 0, 3);
            tableLayoutPanel1.Controls.Add(tboxLatex, 0, 2);
            tableLayoutPanel1.Controls.Add(panel1, 0, 5);
            tableLayoutPanel1.Controls.Add(toolStrip1, 0, 4);
            tableLayoutPanel1.Controls.Add(toolStrip2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1119, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(254, 19);
            label1.TabIndex = 0;
            label1.Text = "Введите формулу в нотации LaTex:";
            // 
            // labFormulaPicture
            // 
            labFormulaPicture.AutoSize = true;
            labFormulaPicture.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labFormulaPicture.Location = new Point(3, 131);
            labFormulaPicture.Name = "labFormulaPicture";
            labFormulaPicture.Size = new Size(149, 19);
            labFormulaPicture.TabIndex = 0;
            labFormulaPicture.Text = "Картинка формулы:";
            // 
            // tboxLatex
            // 
            tboxLatex.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tboxLatex.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point);
            tboxLatex.Location = new Point(3, 47);
            tboxLatex.Multiline = true;
            tboxLatex.Name = "tboxLatex";
            tboxLatex.ScrollBars = ScrollBars.Vertical;
            tboxLatex.Size = new Size(1113, 81);
            tboxLatex.TabIndex = 1;
            tboxLatex.TextChanged += tboxLatex_TextChanged;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(pboxFormula);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 178);
            panel1.Name = "panel1";
            panel1.Size = new Size(1113, 269);
            panel1.TabIndex = 2;
            // 
            // pboxFormula
            // 
            pboxFormula.BackColor = Color.White;
            pboxFormula.Location = new Point(0, 0);
            pboxFormula.Name = "pboxFormula";
            pboxFormula.Size = new Size(1, 1);
            pboxFormula.SizeMode = PictureBoxSizeMode.AutoSize;
            pboxFormula.TabIndex = 0;
            pboxFormula.TabStop = false;
            // 
            // toolStrip1
            // 
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, tscbScale, toolStripLabel2, tscbSystemFontName, toolStripSeparator1, tsbCopyToClipboard, tsbSave });
            toolStrip1.Location = new Point(0, 150);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1119, 25);
            toolStrip1.TabIndex = 4;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(62, 22);
            toolStripLabel1.Text = "Масштаб:";
            // 
            // tscbScale
            // 
            tscbScale.DropDownStyle = ComboBoxStyle.DropDownList;
            tscbScale.Name = "tscbScale";
            tscbScale.Size = new Size(75, 25);
            tscbScale.SelectedIndexChanged += nudScale_ValueChanged;
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(107, 22);
            toolStripLabel2.Text = "Шрифт для \\text:{}";
            // 
            // tscbSystemFontName
            // 
            tscbSystemFontName.DropDownStyle = ComboBoxStyle.DropDownList;
            tscbSystemFontName.Name = "tscbSystemFontName";
            tscbSystemFontName.Size = new Size(140, 25);
            tscbSystemFontName.SelectedIndexChanged += cboxSystemFontName_SelectionChangeCommitted;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // tsbCopyToClipboard
            // 
            tsbCopyToClipboard.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbCopyToClipboard.Enabled = false;
            tsbCopyToClipboard.Image = (Image)resources.GetObject("tsbCopyToClipboard.Image");
            tsbCopyToClipboard.ImageTransparentColor = Color.Magenta;
            tsbCopyToClipboard.Name = "tsbCopyToClipboard";
            tsbCopyToClipboard.Size = new Size(23, 22);
            tsbCopyToClipboard.Text = "&Копировать картинку в буфер обмена";
            tsbCopyToClipboard.Click += tsbCopyToClipboard_Click;
            // 
            // tsbSave
            // 
            tsbSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbSave.Enabled = false;
            tsbSave.Image = (Image)resources.GetObject("tsbSave.Image");
            tsbSave.ImageTransparentColor = Color.Magenta;
            tsbSave.Name = "tsbSave";
            tsbSave.Size = new Size(23, 22);
            tsbSave.Text = "&Сохранить картинку в файл на диске...";
            tsbSave.Click += tsbSave_Click;
            // 
            // toolStrip2
            // 
            toolStrip2.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip2.Items.AddRange(new ToolStripItem[] { создатьToolStripButton, открытьToolStripButton, сохранитьToolStripButton, toolStripSeparator, копироватьToolStripButton, вставитьToolStripButton, toolStripSeparator2, справкаToolStripButton });
            toolStrip2.Location = new Point(0, 19);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(1119, 25);
            toolStrip2.TabIndex = 5;
            toolStrip2.Text = "toolStrip2";
            // 
            // создатьToolStripButton
            // 
            создатьToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            создатьToolStripButton.Image = (Image)resources.GetObject("создатьToolStripButton.Image");
            создатьToolStripButton.ImageTransparentColor = Color.Magenta;
            создатьToolStripButton.Name = "создатьToolStripButton";
            создатьToolStripButton.Size = new Size(23, 22);
            создатьToolStripButton.Text = "&Очистить строку формул";
            // 
            // открытьToolStripButton
            // 
            открытьToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            открытьToolStripButton.Image = (Image)resources.GetObject("открытьToolStripButton.Image");
            открытьToolStripButton.ImageTransparentColor = Color.Magenta;
            открытьToolStripButton.Name = "открытьToolStripButton";
            открытьToolStripButton.Size = new Size(23, 22);
            открытьToolStripButton.Text = "&Загрузить формулу из файла на диске...";
            // 
            // сохранитьToolStripButton
            // 
            сохранитьToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            сохранитьToolStripButton.Enabled = false;
            сохранитьToolStripButton.Image = (Image)resources.GetObject("сохранитьToolStripButton.Image");
            сохранитьToolStripButton.ImageTransparentColor = Color.Magenta;
            сохранитьToolStripButton.Name = "сохранитьToolStripButton";
            сохранитьToolStripButton.Size = new Size(23, 22);
            сохранитьToolStripButton.Text = "&Сохранить текст формулы в файл на диске...";
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new Size(6, 25);
            // 
            // копироватьToolStripButton
            // 
            копироватьToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            копироватьToolStripButton.Enabled = false;
            копироватьToolStripButton.Image = (Image)resources.GetObject("копироватьToolStripButton.Image");
            копироватьToolStripButton.ImageTransparentColor = Color.Magenta;
            копироватьToolStripButton.Name = "копироватьToolStripButton";
            копироватьToolStripButton.Size = new Size(23, 22);
            копироватьToolStripButton.Text = "&Копировать текст формулы в буфер обмена";
            // 
            // вставитьToolStripButton
            // 
            вставитьToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            вставитьToolStripButton.Enabled = false;
            вставитьToolStripButton.Image = (Image)resources.GetObject("вставитьToolStripButton.Image");
            вставитьToolStripButton.ImageTransparentColor = Color.Magenta;
            вставитьToolStripButton.Name = "вставитьToolStripButton";
            вставитьToolStripButton.Size = new Size(23, 22);
            вставитьToolStripButton.Text = "&Вставить текст формулы из буфера обмена";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // справкаToolStripButton
            // 
            справкаToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            справкаToolStripButton.Image = (Image)resources.GetObject("справкаToolStripButton.Image");
            справкаToolStripButton.ImageTransparentColor = Color.Magenta;
            справкаToolStripButton.Name = "справкаToolStripButton";
            справкаToolStripButton.Size = new Size(23, 22);
            справкаToolStripButton.Text = "С&правка";
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.DefaultExt = "png";
            saveFileDialog1.FileName = "formula.png";
            saveFileDialog1.Filter = "*.png|*.png";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1119, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Получить формулу в виде картинки";
            Load += MainForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pboxFormula).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label labFormulaPicture;
        private TextBox tboxLatex;
        private Panel panel1;
        private PictureBox pboxFormula;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripComboBox tscbScale;
        private ToolStripLabel toolStripLabel2;
        private ToolStripComboBox tscbSystemFontName;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tsbCopyToClipboard;
        private ToolStripButton tsbSave;
        private SaveFileDialog saveFileDialog1;
        private ToolStripButton сохранитьToolStripButton1;
        private ToolStrip toolStrip2;
        private ToolStripButton создатьToolStripButton;
        private ToolStripButton открытьToolStripButton;
        private ToolStripButton сохранитьToolStripButton;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripButton копироватьToolStripButton;
        private ToolStripButton вставитьToolStripButton;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton справкаToolStripButton;
    }
}
