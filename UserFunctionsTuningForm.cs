using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using System.Windows.Media.Media3D;

namespace PictureFromLatexFormula
{
    public partial class UserFunctionsTuningForm : Form
    {
        public readonly string Data;

        public UserFunctionsTuningForm()
        {
            InitializeComponent();
            Data = string.Empty;
        }

        private Button current = null;

        public void Build(string userFunctions)
        {
            flpUserFunctions.Controls.Clear();

            foreach (var line in userFunctions.Split('\n'))
            {
                var vals = line.Split('\t');
                var item = new UserFunction();
                item.Build(line);
                var btn = new Button
                {
                    Tag = item.OffsetPosition,
                    Width = 20,
                    AutoSize = true,
                    FlatStyle = FlatStyle.Flat,
                    TabStop = false,
                };
                try
                {
                    btn.Image = FormulaHelper.GetImage(item.CaptionFormula);
                }
                catch
                {
                    btn.Text = item.CaptionFormula;
                    btn.ForeColor = Color.Red;
                }
                btn.Click += (s, e) =>
                {
                    current = (Button)s;
                    tboxInsertFormula.Text = item.InsertFormula;
                    tboxInsertFormula.Enabled = true;
                    tboxCaptionFormula.Text = item.CaptionFormula;
                    tboxCaptionFormula.Enabled = true;
                    nudOffsetPosition.Value = item.OffsetPosition;
                    nudOffsetPosition.Enabled = true;
                    try
                    {
                        pboxButtonImage.Image = FormulaHelper.GetImage(item.CaptionFormula);
                        btnApply.Enabled = true;
                    }
                    catch
                    {
                        pboxButtonImage.Image = pboxButtonImage.ErrorImage;
                        btnApply.Enabled = false;
                    }
                };
                flpUserFunctions.Controls.Add(btn);
            }
        }

        private void tboxCaptionFormula_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var captionFormula = tboxCaptionFormula.Text;
                pboxButtonImage.Image = FormulaHelper.GetImage(captionFormula);
                btnApply.Enabled = true;
            }
            catch
            {
                pboxButtonImage.Image = pboxButtonImage.ErrorImage;
                btnApply.Enabled = false;
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (current == null) return;
            var captionFormula = tboxCaptionFormula.Text;
            try
            {
                current.Image = FormulaHelper.GetImage(captionFormula);
                current.Text = string.Empty;
                ForeColor = SystemColors.ControlText;
            }
            catch
            {
                current.Image = null;
                current.Text = captionFormula;
                ForeColor = Color.Red;
            }
        }
    }
}
