using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ZoomLoginer
{
    class BaseForm : Form
    {
        public BaseForm()
        {
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = !MaximizeBox;
            MinimizeBox = !MinimizeBox;

            Icon = new Icon("icon.ico");
            Text = "ZoomLoginer";
            DoubleBuffered = true;
            
            BackColor = Color.FromArgb(28,28,28);
            Size = new Size(600, 600);
        }
    }
}
