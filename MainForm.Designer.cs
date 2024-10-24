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
            components = new System.ComponentModel.Container();
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
            tsbMoreFontSize = new ToolStripButton();
            tsbLessFontSize = new ToolStripButton();
            toolStripLabel2 = new ToolStripLabel();
            tscbSystemFontName = new ToolStripComboBox();
            toolStripSeparator1 = new ToolStripSeparator();
            tsbCopyToClipboard = new ToolStripButton();
            tsbSave = new ToolStripButton();
            toolStrip2 = new ToolStrip();
            tsbClearFormula = new ToolStripButton();
            tsbLoadFormula = new ToolStripButton();
            tsbSaveFormula = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            tsbShowHideNotes = new ToolStripButton();
            flowLayoutPanel1 = new FlowLayoutPanel();
            labFunctions = new Label();
            btnAddFracFunction = new Button();
            btnAddTextFunction = new Button();
            btnAddSqrtFunction = new Button();
            btnAddSubIndexFunction = new Button();
            btnAddSupIndexFunction = new Button();
            btnAddSmallSpaceFunction = new Button();
            btnAddMediumSpaceFunction = new Button();
            btnAddLargeSpaceFunction = new Button();
            btnAddNegativeSpaceFunction = new Button();
            btnAddBigBracesFunction = new Button();
            btnSetRedColorFontFunction = new Button();
            saveFileDialog1 = new SaveFileDialog();
            timer1 = new System.Windows.Forms.Timer(components);
            saveFileDialog2 = new SaveFileDialog();
            openFileDialog2 = new OpenFileDialog();
            splitContainer1 = new SplitContainer();
            tlpNotes = new TableLayoutPanel();
            toolTip1 = new ToolTip(components);
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pboxFormula).BeginInit();
            toolStrip1.SuspendLayout();
            toolStrip2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(labFormulaPicture, 0, 4);
            tableLayoutPanel1.Controls.Add(tboxLatex, 0, 2);
            tableLayoutPanel1.Controls.Add(panel1, 0, 6);
            tableLayoutPanel1.Controls.Add(toolStrip1, 0, 5);
            tableLayoutPanel1.Controls.Add(toolStrip2, 0, 1);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(505, 509);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(255, 19);
            label1.TabIndex = 0;
            label1.Text = "Введите формулу в нотации LaTeX:";
            // 
            // labFormulaPicture
            // 
            labFormulaPicture.AutoSize = true;
            labFormulaPicture.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labFormulaPicture.Location = new Point(3, 218);
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
            tboxLatex.Size = new Size(499, 100);
            tboxLatex.TabIndex = 1;
            tboxLatex.Text = "Загрузка программы...";
            tboxLatex.TextChanged += tboxLatex_TextChanged;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(pboxFormula);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 265);
            panel1.Name = "panel1";
            panel1.Size = new Size(499, 241);
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
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, tscbScale, tsbMoreFontSize, tsbLessFontSize, toolStripLabel2, tscbSystemFontName, toolStripSeparator1, tsbCopyToClipboard, tsbSave });
            toolStrip1.Location = new Point(0, 237);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(505, 25);
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
            // tsbMoreFontSize
            // 
            tsbMoreFontSize.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbMoreFontSize.Enabled = false;
            tsbMoreFontSize.Image = Properties.Resources.Увеличить_размер_шрифта;
            tsbMoreFontSize.ImageTransparentColor = Color.White;
            tsbMoreFontSize.Name = "tsbMoreFontSize";
            tsbMoreFontSize.Size = new Size(23, 22);
            tsbMoreFontSize.Text = "увеличить масштаб";
            tsbMoreFontSize.Click += tsbMoreFontSize_Click;
            // 
            // tsbLessFontSize
            // 
            tsbLessFontSize.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbLessFontSize.Enabled = false;
            tsbLessFontSize.Image = Properties.Resources.Уменьшить_размер_шрифта;
            tsbLessFontSize.ImageTransparentColor = Color.White;
            tsbLessFontSize.Name = "tsbLessFontSize";
            tsbLessFontSize.Size = new Size(23, 22);
            tsbLessFontSize.Text = "уменьшить масштаб";
            tsbLessFontSize.Click += tsbLessFontSize_Click;
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(113, 22);
            toolStripLabel2.Text = "Шрифт для \\text{...}";
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
            toolStrip2.Items.AddRange(new ToolStripItem[] { tsbClearFormula, tsbLoadFormula, tsbSaveFormula, toolStripSeparator2, tsbShowHideNotes });
            toolStrip2.Location = new Point(0, 19);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(505, 25);
            toolStrip2.TabIndex = 5;
            toolStrip2.Text = "toolStrip2";
            // 
            // tsbClearFormula
            // 
            tsbClearFormula.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbClearFormula.Image = (Image)resources.GetObject("tsbClearFormula.Image");
            tsbClearFormula.ImageTransparentColor = Color.Magenta;
            tsbClearFormula.Name = "tsbClearFormula";
            tsbClearFormula.Size = new Size(23, 22);
            tsbClearFormula.Text = "&Очистить строку формул";
            tsbClearFormula.Click += tsbClearFormula_Click;
            // 
            // tsbLoadFormula
            // 
            tsbLoadFormula.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbLoadFormula.Image = (Image)resources.GetObject("tsbLoadFormula.Image");
            tsbLoadFormula.ImageTransparentColor = Color.Magenta;
            tsbLoadFormula.Name = "tsbLoadFormula";
            tsbLoadFormula.Size = new Size(23, 22);
            tsbLoadFormula.Text = "&Загрузить формулу из файла на диске...";
            tsbLoadFormula.Click += tsbLoadFormula_Click;
            // 
            // tsbSaveFormula
            // 
            tsbSaveFormula.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbSaveFormula.Enabled = false;
            tsbSaveFormula.Image = (Image)resources.GetObject("tsbSaveFormula.Image");
            tsbSaveFormula.ImageTransparentColor = Color.Magenta;
            tsbSaveFormula.Name = "tsbSaveFormula";
            tsbSaveFormula.Size = new Size(23, 22);
            tsbSaveFormula.Text = "&Сохранить текст формулы в файл на диске...";
            tsbSaveFormula.Click += tsbSaveFormula_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // tsbShowHideNotes
            // 
            tsbShowHideNotes.CheckOnClick = true;
            tsbShowHideNotes.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbShowHideNotes.Image = Properties.Resources.Обратить_диаграмму;
            tsbShowHideNotes.ImageTransparentColor = Color.White;
            tsbShowHideNotes.Name = "tsbShowHideNotes";
            tsbShowHideNotes.Size = new Size(23, 22);
            tsbShowHideNotes.Text = "Показать / спрятать панель примеров";
            tsbShowHideNotes.Click += tsbShowHideNotes_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(labFunctions);
            flowLayoutPanel1.Controls.Add(btnAddFracFunction);
            flowLayoutPanel1.Controls.Add(btnAddTextFunction);
            flowLayoutPanel1.Controls.Add(btnAddSqrtFunction);
            flowLayoutPanel1.Controls.Add(btnAddSubIndexFunction);
            flowLayoutPanel1.Controls.Add(btnAddSupIndexFunction);
            flowLayoutPanel1.Controls.Add(btnAddSmallSpaceFunction);
            flowLayoutPanel1.Controls.Add(btnAddMediumSpaceFunction);
            flowLayoutPanel1.Controls.Add(btnAddLargeSpaceFunction);
            flowLayoutPanel1.Controls.Add(btnAddNegativeSpaceFunction);
            flowLayoutPanel1.Controls.Add(btnAddBigBracesFunction);
            flowLayoutPanel1.Controls.Add(btnSetRedColorFontFunction);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(3, 153);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(499, 62);
            flowLayoutPanel1.TabIndex = 6;
            toolTip1.SetToolTip(flowLayoutPanel1, "увеличить масштаб");
            // 
            // labFunctions
            // 
            labFunctions.Cursor = Cursors.Hand;
            labFunctions.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point);
            labFunctions.Location = new Point(3, 0);
            labFunctions.Name = "labFunctions";
            labFunctions.Size = new Size(60, 31);
            labFunctions.TabIndex = 1;
            labFunctions.Text = "Функции:";
            labFunctions.TextAlign = ContentAlignment.MiddleLeft;
            labFunctions.Click += labFunctions_Click;
            // 
            // btnAddFracFunction
            // 
            btnAddFracFunction.AutoSize = true;
            btnAddFracFunction.Location = new Point(69, 3);
            btnAddFracFunction.Name = "btnAddFracFunction";
            btnAddFracFunction.Size = new Size(58, 25);
            btnAddFracFunction.TabIndex = 0;
            btnAddFracFunction.Tag = "3";
            btnAddFracFunction.Text = "\\frac{}{}";
            toolTip1.SetToolTip(btnAddFracFunction, "дробь");
            btnAddFracFunction.UseVisualStyleBackColor = true;
            btnAddFracFunction.Click += btnInsertFunction_Click;
            // 
            // btnAddTextFunction
            // 
            btnAddTextFunction.AutoSize = true;
            btnAddTextFunction.Location = new Point(133, 3);
            btnAddTextFunction.Name = "btnAddTextFunction";
            btnAddTextFunction.Size = new Size(50, 25);
            btnAddTextFunction.TabIndex = 0;
            btnAddTextFunction.Tag = "1";
            btnAddTextFunction.Text = "\\text{}";
            toolTip1.SetToolTip(btnAddTextFunction, "кирилический текст");
            btnAddTextFunction.UseVisualStyleBackColor = true;
            btnAddTextFunction.Click += btnInsertFunction_Click;
            // 
            // btnAddSqrtFunction
            // 
            btnAddSqrtFunction.AutoSize = true;
            btnAddSqrtFunction.Location = new Point(189, 3);
            btnAddSqrtFunction.Name = "btnAddSqrtFunction";
            btnAddSqrtFunction.Size = new Size(50, 25);
            btnAddSqrtFunction.TabIndex = 0;
            btnAddSqrtFunction.Tag = "1";
            btnAddSqrtFunction.Text = "\\sqrt{}";
            toolTip1.SetToolTip(btnAddSqrtFunction, "извлечение корня");
            btnAddSqrtFunction.UseVisualStyleBackColor = true;
            btnAddSqrtFunction.Click += btnInsertFunction_Click;
            // 
            // btnAddSubIndexFunction
            // 
            btnAddSubIndexFunction.AutoSize = true;
            btnAddSubIndexFunction.Location = new Point(245, 3);
            btnAddSubIndexFunction.Name = "btnAddSubIndexFunction";
            btnAddSubIndexFunction.Size = new Size(30, 25);
            btnAddSubIndexFunction.TabIndex = 0;
            btnAddSubIndexFunction.Tag = "1";
            btnAddSubIndexFunction.Text = "_{}";
            toolTip1.SetToolTip(btnAddSubIndexFunction, "нижний индекс");
            btnAddSubIndexFunction.UseVisualStyleBackColor = true;
            btnAddSubIndexFunction.Click += btnInsertFunction_Click;
            // 
            // btnAddSupIndexFunction
            // 
            btnAddSupIndexFunction.AutoSize = true;
            btnAddSupIndexFunction.Location = new Point(281, 3);
            btnAddSupIndexFunction.Name = "btnAddSupIndexFunction";
            btnAddSupIndexFunction.Size = new Size(33, 25);
            btnAddSupIndexFunction.TabIndex = 0;
            btnAddSupIndexFunction.Tag = "1";
            btnAddSupIndexFunction.Text = "^{}";
            toolTip1.SetToolTip(btnAddSupIndexFunction, "верхний индекс");
            btnAddSupIndexFunction.UseVisualStyleBackColor = true;
            btnAddSupIndexFunction.Click += btnInsertFunction_Click;
            // 
            // btnAddSmallSpaceFunction
            // 
            btnAddSmallSpaceFunction.AutoSize = true;
            btnAddSmallSpaceFunction.Location = new Point(320, 3);
            btnAddSmallSpaceFunction.Name = "btnAddSmallSpaceFunction";
            btnAddSmallSpaceFunction.Size = new Size(30, 25);
            btnAddSmallSpaceFunction.TabIndex = 0;
            btnAddSmallSpaceFunction.Tag = "";
            btnAddSmallSpaceFunction.Text = "\\,";
            toolTip1.SetToolTip(btnAddSmallSpaceFunction, "добавить 3/18 от пробела");
            btnAddSmallSpaceFunction.UseVisualStyleBackColor = true;
            btnAddSmallSpaceFunction.Click += btnInsertFunction_Click;
            // 
            // btnAddMediumSpaceFunction
            // 
            btnAddMediumSpaceFunction.AutoSize = true;
            btnAddMediumSpaceFunction.Location = new Point(356, 3);
            btnAddMediumSpaceFunction.Name = "btnAddMediumSpaceFunction";
            btnAddMediumSpaceFunction.Size = new Size(30, 25);
            btnAddMediumSpaceFunction.TabIndex = 0;
            btnAddMediumSpaceFunction.Tag = "";
            btnAddMediumSpaceFunction.Text = "\\:";
            toolTip1.SetToolTip(btnAddMediumSpaceFunction, "добавить 4/18 от пробела");
            btnAddMediumSpaceFunction.UseVisualStyleBackColor = true;
            btnAddMediumSpaceFunction.Click += btnInsertFunction_Click;
            // 
            // btnAddLargeSpaceFunction
            // 
            btnAddLargeSpaceFunction.AutoSize = true;
            btnAddLargeSpaceFunction.Location = new Point(392, 3);
            btnAddLargeSpaceFunction.Name = "btnAddLargeSpaceFunction";
            btnAddLargeSpaceFunction.Size = new Size(30, 25);
            btnAddLargeSpaceFunction.TabIndex = 0;
            btnAddLargeSpaceFunction.Tag = "";
            btnAddLargeSpaceFunction.Text = "\\;";
            toolTip1.SetToolTip(btnAddLargeSpaceFunction, "добавить 5/18 от пробела");
            btnAddLargeSpaceFunction.UseVisualStyleBackColor = true;
            btnAddLargeSpaceFunction.Click += btnInsertFunction_Click;
            // 
            // btnAddNegativeSpaceFunction
            // 
            btnAddNegativeSpaceFunction.AutoSize = true;
            btnAddNegativeSpaceFunction.Location = new Point(428, 3);
            btnAddNegativeSpaceFunction.Name = "btnAddNegativeSpaceFunction";
            btnAddNegativeSpaceFunction.Size = new Size(30, 25);
            btnAddNegativeSpaceFunction.TabIndex = 0;
            btnAddNegativeSpaceFunction.Tag = "";
            btnAddNegativeSpaceFunction.Text = "\\!";
            toolTip1.SetToolTip(btnAddNegativeSpaceFunction, "отнять 3/18 от пробела");
            btnAddNegativeSpaceFunction.UseVisualStyleBackColor = true;
            btnAddNegativeSpaceFunction.Click += btnInsertFunction_Click;
            // 
            // btnAddBigBracesFunction
            // 
            btnAddBigBracesFunction.AutoSize = true;
            btnAddBigBracesFunction.Location = new Point(3, 34);
            btnAddBigBracesFunction.Name = "btnAddBigBracesFunction";
            btnAddBigBracesFunction.Size = new Size(77, 25);
            btnAddBigBracesFunction.TabIndex = 0;
            btnAddBigBracesFunction.Tag = "7";
            btnAddBigBracesFunction.Text = "\\left(\\right)";
            toolTip1.SetToolTip(btnAddBigBracesFunction, "большие круглые скобки");
            btnAddBigBracesFunction.UseVisualStyleBackColor = true;
            btnAddBigBracesFunction.Click += btnInsertFunction_Click;
            // 
            // btnSetRedColorFontFunction
            // 
            btnSetRedColorFontFunction.AutoSize = true;
            btnSetRedColorFontFunction.Location = new Point(86, 34);
            btnSetRedColorFontFunction.Name = "btnSetRedColorFontFunction";
            btnSetRedColorFontFunction.Size = new Size(82, 25);
            btnSetRedColorFontFunction.TabIndex = 0;
            btnSetRedColorFontFunction.Tag = "1";
            btnSetRedColorFontFunction.Text = "{\\color{red}}";
            toolTip1.SetToolTip(btnSetRedColorFontFunction, "окрасить красным цветом");
            btnSetRedColorFontFunction.UseVisualStyleBackColor = true;
            btnSetRedColorFontFunction.Click += btnInsertFunction_Click;
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.DefaultExt = "png";
            saveFileDialog1.FileName = "formula.png";
            saveFileDialog1.Filter = "*.png|*.png";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // saveFileDialog2
            // 
            saveFileDialog2.DefaultExt = "ltx";
            saveFileDialog2.FileName = "formula.ltx";
            saveFileDialog2.Filter = "*.ltx|*.ltx";
            // 
            // openFileDialog2
            // 
            openFileDialog2.DefaultExt = "ltx";
            openFileDialog2.Filter = "*.ltx|*.ltx";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tlpNotes);
            splitContainer1.Size = new Size(938, 509);
            splitContainer1.SplitterDistance = 505;
            splitContainer1.TabIndex = 1;
            // 
            // tlpNotes
            // 
            tlpNotes.AutoScroll = true;
            tlpNotes.BackColor = SystemColors.Window;
            tlpNotes.ColumnCount = 1;
            tlpNotes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpNotes.Dock = DockStyle.Fill;
            tlpNotes.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            tlpNotes.Location = new Point(0, 0);
            tlpNotes.Name = "tlpNotes";
            tlpNotes.RowCount = 1;
            tlpNotes.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpNotes.Size = new Size(429, 509);
            tlpNotes.TabIndex = 7;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(938, 509);
            Controls.Add(splitContainer1);
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
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
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
        private ToolStrip toolStrip2;
        private ToolStripButton tsbClearFormula;
        private ToolStripButton tsbLoadFormula;
        private ToolStripButton tsbSaveFormula;
        private System.Windows.Forms.Timer timer1;
        private SaveFileDialog saveFileDialog2;
        private OpenFileDialog openFileDialog2;
        private SplitContainer splitContainer1;
        private TableLayoutPanel tlpNotes;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tsbShowHideNotes;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnAddFracFunction;
        private Button btnAddTextFunction;
        private Button btnAddSqrtFunction;
        private Button btnAddSubIndexFunction;
        private Button btnAddSupIndexFunction;
        private ToolTip toolTip1;
        private ToolStripButton tsbMoreFontSize;
        private ToolStripButton tsbLessFontSize;
        private Label labFunctions;
        private Button btnSetRedColorFontFunction;
        private Button btnAddSmallSpaceFunction;
        private Button btnAddMediumSpaceFunction;
        private Button btnAddLargeSpaceFunction;
        private Button btnAddNegativeSpaceFunction;
        private Button btnAddBigBracesFunction;
    }
}
