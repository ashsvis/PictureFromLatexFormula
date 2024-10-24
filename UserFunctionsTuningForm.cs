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

        public void Build(string userFunctions)
        {
            flpButtons.Controls.Clear();



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
