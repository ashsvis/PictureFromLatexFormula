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
            label4 = new Label();
            tboxFormula = new TextBox();
            nudOffset = new NumericUpDown();
            flowLayoutPanel2 = new FlowLayoutPanel();
            btnOk = new Button();
            btnCancel = new Button();
            btnApply = new Button();
            btnDelete = new Button();
            labExample = new Label();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudOffset).BeginInit();
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
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Controls.Add(label4, 0, 1);
            tableLayoutPanel2.Controls.Add(tboxFormula, 1, 0);
            tableLayoutPanel2.Controls.Add(nudOffset, 1, 1);
            tableLayoutPanel2.Controls.Add(flowLayoutPanel2, 1, 3);
            tableLayoutPanel2.Controls.Add(btnApply, 1, 2);
            tableLayoutPanel2.Controls.Add(btnDelete, 0, 3);
            tableLayoutPanel2.Controls.Add(labExample, 2, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(267, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
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
            label1.Size = new Size(162, 29);
            label1.TabIndex = 0;
            label1.Text = "Определение функции:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(3, 29);
            label4.Name = "label4";
            label4.Size = new Size(162, 29);
            label4.TabIndex = 0;
            label4.Text = "Сместить курсор вправо на:";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tboxFormula
            // 
            tboxFormula.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.SetColumnSpan(tboxFormula, 2);
            tboxFormula.Enabled = false;
            tboxFormula.Location = new Point(171, 3);
            tboxFormula.Name = "tboxFormula";
            tboxFormula.Size = new Size(232, 23);
            tboxFormula.TabIndex = 1;
            tboxFormula.TextChanged += tboxFormula_TextChanged;
            // 
            // nudOffset
            // 
            nudOffset.Enabled = false;
            nudOffset.Location = new Point(171, 32);
            nudOffset.Name = "nudOffset";
            nudOffset.Size = new Size(64, 23);
            nudOffset.TabIndex = 2;
            nudOffset.ValueChanged += tboxFormula_TextChanged;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            flowLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.SetColumnSpan(flowLayoutPanel2, 2);
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
            tableLayoutPanel2.SetColumnSpan(btnApply, 2);
            btnApply.Enabled = false;
            btnApply.Location = new Point(316, 61);
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
            // labExample
            // 
            labExample.AutoSize = true;
            labExample.Dock = DockStyle.Fill;
            labExample.Location = new Point(241, 29);
            labExample.Name = "labExample";
            labExample.Size = new Size(162, 29);
            labExample.TabIndex = 5;
            labExample.Text = "...";
            labExample.TextAlign = ContentAlignment.MiddleLeft;
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
            ((System.ComponentModel.ISupportInitialize)nudOffset).EndInit();
            flowLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flpUserFunctions;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label1;
        private Label label4;
        private TextBox tboxFormula;
        private NumericUpDown nudOffset;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button btnOk;
        private Button btnCancel;
        private Button btnApply;
        private Button btnDelete;
        private Label labExample;
    }
}