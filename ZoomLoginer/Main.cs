﻿using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;

namespace ZoomLoginer
{
    class Main : BaseForm
    {
        string[] buttonNames = { "スケジュール", "イベント", "休み", "オプション", "閉じる" };
        Form[] forms;

        NotifyIcon NotifyIcon;

        public Main()
        {
            EventProcessor.GetToday();
            EventProcessor.Load();

            forms = new Form[4];

            AddTask();//  タスクトレイに追加する

            for(int i = 0; i < buttonNames.Length; i++)
            {
                GenerateButton(buttonNames[i],new Point(350,i * 50 + (i + 1) * 50));
            }

            Timer timer = new Timer()
            {
                Interval = 1000,
                Enabled = true
            };

            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //  Console.WriteLine(DateTime.Now);
            EventProcessor.GetToday();
            for (var i = 0; i < EventProcessor.Times.Count; i++ )
            {
                //  Console.WriteLine(EventProcessor.Times[i]);
                if (DateTime.Now.ToLongTimeString() == EventProcessor.Times[i].AddMinutes(-5).ToLongTimeString())
                {
                    NotifyIcon.ShowBalloonTip(5000, "お知らせ", $"{EventProcessor.EventNames[i]}の五分前になりました。", ToolTipIcon.Info);
                }

                if(DateTime.Now.ToLongTimeString() == EventProcessor.Times[i].ToLongTimeString())
                {
                    try
                    {
                        Process.Start(EventProcessor.URLs[i]);
                    }
                    catch
                    {
                        MessageBox.Show("URLが開けませんでした", "URL Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void AddTask()
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

            exit.Click += (object sender, EventArgs e) => {
                Close();
            };

            contextMenuStrip.Items.Add(toolStripItem);
            contextMenuStrip.Items.Add(exit);
            NotifyIcon.ContextMenuStrip = contextMenuStrip;

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

            switch (formName)
            {
                case "スケジュール":
                    forms[0] = new Schedule();
                    forms[0].Show();                  
                    break;
                case "イベント":
                    forms[1] = new Event();
                    forms[1].Show();
                    break;
                case "休み":
                    forms[2] = new Free();
                    forms[2].Show();
                    break;
                case "オプション":
                    forms[3] = new BaseForm();
                    forms[3].Show();
                    break;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
}
