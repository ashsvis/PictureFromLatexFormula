namespace PictureFromLatexFormula
{
    partial class UserFunctionsTuningForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            flpUserFunctions = new FlowLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            tboxInsertFormula = new TextBox();
            nudOffsetPosition = new NumericUpDown();
            tboxCaptionFormula = new TextBox();
            label3 = new Label();
            pboxButtonImage = new PictureBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            btnOk = new Button();
            btnCancel = new Button();
            btnApply = new Button();
            btnDelete = new Button();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudOffsetPosition).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pboxButtonImage).BeginInit();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 264F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(flpUserFunctions, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(676, 303);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // flpUserFunctions
            // 
            flpUserFunctions.AutoScroll = true;
            flpUserFunctions.BorderStyle = BorderStyle.FixedSingle;
            flpUserFunctions.Dock = DockStyle.Fill;
            flpUserFunctions.Location = new Point(3, 3);
            flpUserFunctions.Name = "flpUserFunctions";
            flpUserFunctions.Size = new Size(258, 297);
            flpUserFunctions.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Controls.Add(label2, 0, 2);
            tableLayoutPanel2.Controls.Add(label4, 0, 1);
            tableLayoutPanel2.Controls.Add(tboxInsertFormula, 1, 0);
            tableLayoutPanel2.Controls.Add(nudOffsetPosition, 1, 1);
            tableLayoutPanel2.Controls.Add(tboxCaptionFormula, 1, 2);
            tableLayoutPanel2.Controls.Add(label3, 0, 3);
            tableLayoutPanel2.Controls.Add(pboxButtonImage, 1, 3);
            tableLayoutPanel2.Controls.Add(flowLayoutPanel2, 1, 5);
            tableLayoutPanel2.Controls.Add(btnApply, 1, 4);
            tableLayoutPanel2.Controls.Add(btnDelete, 0, 5);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(267, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 6;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.Size = new Size(406, 297);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(117, 29);
            label1.TabIndex = 0;
            label1.Text = "Текст функции:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 59);
            label2.Name = "label2";
            label2.Size = new Size(117, 29);
            label2.TabIndex = 0;
            label2.Text = "Текст кнопки:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(3, 29);
            label4.Name = "label4";
            label4.Size = new Size(117, 30);
            label4.TabIndex = 0;
            label4.Text = "Смещение позиции\r\nвставки:";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tboxInsertFormula
            // 
            tboxInsertFormula.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tboxInsertFormula.Enabled = false;
            tboxInsertFormula.Location = new Point(126, 3);
            tboxInsertFormula.Name = "tboxInsertFormula";
            tboxInsertFormula.Size = new Size(277, 23);
            tboxInsertFormula.TabIndex = 1;
            // 
            // nudOffsetPosition
            // 
            nudOffsetPosition.Enabled = false;
            nudOffsetPosition.Location = new Point(126, 32);
            nudOffsetPosition.Name = "nudOffsetPosition";
            nudOffsetPosition.Size = new Size(64, 23);
            nudOffsetPosition.TabIndex = 2;
            // 
            // tboxCaptionFormula
            // 
            tboxCaptionFormula.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tboxCaptionFormula.Enabled = false;
            tboxCaptionFormula.Location = new Point(126, 62);
            tboxCaptionFormula.Name = "tboxCaptionFormula";
            tboxCaptionFormula.Size = new Size(277, 23);
            tboxCaptionFormula.TabIndex = 1;
            tboxCaptionFormula.TextChanged += tboxCaptionFormula_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3, 88);
            label3.Name = "label3";
            label3.Size = new Size(117, 31);
            label3.TabIndex = 0;
            label3.Text = "Картинка кнопки:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pboxButtonImage
            // 
            pboxButtonImage.BorderStyle = BorderStyle.FixedSingle;
            pboxButtonImage.Location = new Point(126, 91);
            pboxButtonImage.Name = "pboxButtonImage";
            pboxButtonImage.Size = new Size(23, 25);
            pboxButtonImage.SizeMode = PictureBoxSizeMode.AutoSize;
            pboxButtonImage.TabIndex = 3;
            pboxButtonImage.TabStop = false;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.Controls.Add(btnOk);
            flowLayoutPanel2.Controls.Add(btnCancel);
            flowLayoutPanel2.Location = new Point(241, 265);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(162, 29);
            flowLayoutPanel2.TabIndex = 4;
            // 
            // btnOk
            // 
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(3, 3);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 0;
            btnOk.Text = "ОК";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(84, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            btnApply.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnApply.Enabled = false;
            btnApply.Location = new Point(316, 122);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(87, 23);
            btnApply.TabIndex = 0;
            btnApply.Text = "Применить";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Left;
            btnDelete.Enabled = false;
            btnDelete.Location = new Point(3, 268);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(117, 23);
            btnDelete.TabIndex = 0;
            btnDelete.Text = "Удалить кнопку";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // UserFunctionsTuningForm
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(676, 303);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UserFunctionsTuningForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Настройка пользовательских функций";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudOffsetPosition).EndInit();
            ((System.ComponentModel.ISupportInitialize)pboxButtonImage).EndInit();
            flowLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flpUserFunctions;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label1;
        private Label label2;
        private Label label4;
        private TextBox tboxInsertFormula;
        private NumericUpDown nudOffsetPosition;
        private TextBox tboxCaptionFormula;
        private Label label3;
        private PictureBox pboxButtonImage;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button btnOk;
        private Button btnCancel;
        private Button btnApply;
        private Button btnDelete;
    }
}