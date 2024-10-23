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
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            labFormulaPicture = new Label();
            tboxLatex = new TextBox();
            panel1 = new Panel();
            pictboxFormula = new PictureBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label3 = new Label();
            cboxSystemFontName = new ComboBox();
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            tscbScale = new ToolStripComboBox();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictboxFormula).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(labFormulaPicture, 0, 4);
            tableLayoutPanel1.Controls.Add(tboxLatex, 0, 1);
            tableLayoutPanel1.Controls.Add(panel1, 0, 5);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 2);
            tableLayoutPanel1.Controls.Add(toolStrip1, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1119, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(197, 15);
            label1.TabIndex = 0;
            label1.Text = "Введите формулу в нотации LaTex:";
            // 
            // labFormulaPicture
            // 
            labFormulaPicture.AutoSize = true;
            labFormulaPicture.Location = new Point(3, 157);
            labFormulaPicture.Name = "labFormulaPicture";
            labFormulaPicture.Size = new Size(118, 15);
            labFormulaPicture.TabIndex = 0;
            labFormulaPicture.Text = "Картинка формулы:";
            // 
            // tboxLatex
            // 
            tboxLatex.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tboxLatex.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point);
            tboxLatex.Location = new Point(3, 18);
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
            panel1.BackColor = Color.WhiteSmoke;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(pictboxFormula);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 175);
            panel1.Name = "panel1";
            panel1.Size = new Size(1113, 272);
            panel1.TabIndex = 2;
            // 
            // pictboxFormula
            // 
            pictboxFormula.BackColor = SystemColors.Window;
            pictboxFormula.Location = new Point(0, 0);
            pictboxFormula.Name = "pictboxFormula";
            pictboxFormula.Size = new Size(1, 1);
            pictboxFormula.SizeMode = PictureBoxSizeMode.AutoSize;
            pictboxFormula.TabIndex = 0;
            pictboxFormula.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Controls.Add(cboxSystemFontName);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(3, 105);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1113, 29);
            flowLayoutPanel1.TabIndex = 3;
            flowLayoutPanel1.WrapContents = false;
            // 
            // label3
            // 
            label3.Location = new Point(3, 2);
            label3.Margin = new Padding(3, 2, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(153, 23);
            label3.TabIndex = 0;
            label3.Text = "Шрифт для функции \\text:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cboxSystemFontName
            // 
            cboxSystemFontName.DropDownStyle = ComboBoxStyle.DropDownList;
            cboxSystemFontName.Enabled = false;
            cboxSystemFontName.FormattingEnabled = true;
            cboxSystemFontName.Location = new Point(162, 3);
            cboxSystemFontName.Name = "cboxSystemFontName";
            cboxSystemFontName.Size = new Size(161, 23);
            cboxSystemFontName.TabIndex = 2;
            cboxSystemFontName.SelectionChangeCommitted += cboxSystemFontName_SelectionChangeCommitted;
            // 
            // toolStrip1
            // 
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, tscbScale });
            toolStrip1.Location = new Point(0, 137);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1119, 20);
            toolStrip1.TabIndex = 4;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(62, 17);
            toolStripLabel1.Text = "Масштаб:";
            // 
            // tscbScale
            // 
            tscbScale.DropDownStyle = ComboBoxStyle.DropDownList;
            tscbScale.Name = "tscbScale";
            tscbScale.Size = new Size(75, 20);
            tscbScale.SelectedIndexChanged += nudScale_ValueChanged;
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
            ((System.ComponentModel.ISupportInitialize)pictboxFormula).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label labFormulaPicture;
        private TextBox tboxLatex;
        private Panel panel1;
        private PictureBox pictboxFormula;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label3;
        private ComboBox cboxSystemFontName;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripComboBox tscbScale;
    }
}
