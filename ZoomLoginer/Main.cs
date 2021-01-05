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

        NotifyIcon NotifyIcon;

        public Main()
        {

            NotifyIcon = new NotifyIcon
            {
                Icon = new Icon("icon.ico"),
                Visible = true,
                Text = "ZoomLoginer"
            };

            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem toolStripItem = new ToolStripMenuItem()
            {
                Text = "&設定",
            };
            ToolStripMenuItem exit = new ToolStripMenuItem()
            {
                Text = "&終了",
            };

            toolStripItem.Click += (object sender, EventArgs e) =>
            {
                Show();
            };

            exit.Click += (object sender, EventArgs e) =>{
                Application.Exit();
            };

            contextMenuStrip.Items.Add(toolStripItem);
            contextMenuStrip.Items.Add(exit);
            NotifyIcon.ContextMenuStrip = contextMenuStrip;


            for(int i = 0; i < buttonNames.Length; i++)
            {
                GenerateButton(buttonNames[i],new Point(350,i * 50 + (i + 1) * 50));
            }

            foreach(var f in forms)
            {
                f.FormClosing += (object sender, FormClosingEventArgs e) =>
                {
                    f.Hide();
                    e.Cancel = true;
                };
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

            if(formName == "閉じる")
            {
                Hide();
                return;
            }

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
