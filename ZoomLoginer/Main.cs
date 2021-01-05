using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ZoomLoginer
{
    class Main : BaseForm
    {
        string[] buttonNames = { "スケジュール", "イベント", "休み", "オプション", "閉じる" };
        Form[] forms =
        {
            new Schedule(),
        };
        public Main()
        {
            for(int i = 0; i < buttonNames.Length; i++)
            {
                GenerateButton(buttonNames[i],new Point(350,i * 50 + (i + 1) * 50));
            }
        }

        private void GenerateButton(string buttonName, Point location)
        {
            Button btn = new Button
            {
                Text = buttonName,
                ForeColor = Color.White,
                Font = new Font("メイリオ",12),
                Size = new Size(200, 60),
                Location = location,
            };

            btn.Click += Btn_Click;

            Controls.Add(btn);
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            OpenForm(btn.Text);
        }

        private void OpenForm(string formName)
        {
            for (int i = 0; i < buttonNames.Length; i++)
            {
                if (buttonNames[i] == formName)
                {
                    forms[i].Show();
                    return;
                }
            }

            MessageBox.Show("バグ発生！");
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
}
