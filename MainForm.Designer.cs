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
            label2 = new Label();
            nudScale = new NumericUpDown();
            label3 = new Label();
            cboxSystemFontName = new ComboBox();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictboxFormula).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudScale).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(labFormulaPicture, 0, 3);
            tableLayoutPanel1.Controls.Add(tboxLatex, 0, 1);
            tableLayoutPanel1.Controls.Add(panel1, 0, 4);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(800, 450);
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
            labFormulaPicture.Location = new Point(3, 79);
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
            tboxLatex.Name = "tboxLatex";
            tboxLatex.Size = new Size(794, 23);
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
            panel1.Location = new Point(3, 97);
            panel1.Name = "panel1";
            panel1.Size = new Size(794, 350);
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
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(nudScale);
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Controls.Add(cboxSystemFontName);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(3, 47);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(794, 29);
            flowLayoutPanel1.TabIndex = 3;
            flowLayoutPanel1.WrapContents = false;
            // 
            // label2
            // 
            label2.Location = new Point(3, 2);
            label2.Margin = new Padding(3, 2, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(65, 23);
            label2.TabIndex = 0;
            label2.Text = "Масштаб:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nudScale
            // 
            nudScale.Enabled = false;
            nudScale.Location = new Point(74, 3);
            nudScale.Name = "nudScale";
            nudScale.Size = new Size(44, 23);
            nudScale.TabIndex = 1;
            nudScale.Value = new decimal(new int[] { 20, 0, 0, 0 });
            nudScale.ValueChanged += nudScale_ValueChanged;
            // 
            // label3
            // 
            label3.Location = new Point(124, 2);
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
            cboxSystemFontName.Location = new Point(283, 3);
            cboxSystemFontName.Name = "cboxSystemFontName";
            cboxSystemFontName.Size = new Size(161, 23);
            cboxSystemFontName.TabIndex = 2;
            cboxSystemFontName.SelectionChangeCommitted += cboxSystemFontName_SelectionChangeCommitted;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
            ((System.ComponentModel.ISupportInitialize)nudScale).EndInit();
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
        private Label label2;
        private NumericUpDown nudScale;
        private Label label3;
        private ComboBox cboxSystemFontName;
    }
}
