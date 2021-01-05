using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ZoomLoginer
{
    class Schedule : BaseForm
    {
        string[] eDays = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Sutrday", "Sunday"};
        string[] days = { "月", "火", "水", "木", "金", "土", "日" };

        SetScheduleForm setForm = new SetScheduleForm();

        public Schedule()
        {
            for (int i = 0; i < days.Length; i++)
            {
                GenerateButton(days[i], new Point(350, i * 70 + 40));
            }
        }

        private void GenerateButton(string buttonName, Point location)
        {
            Button btn = new Button
            {
                Text = buttonName,
                ForeColor = Color.White,
                Font = new Font("メイリオ", 12),
                Size = new Size(200, 60),
                Location = location,
            };

            btn.Click += Btn_Click; ;

            Controls.Add(btn);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            for(int i = 0; i < eDays.Length; i++)
            {
                if(DateTime.Today.DayOfWeek.ToString() == eDays[i])
                {
                    e.Graphics.DrawString($"Today : {days[i]}曜日",new Font("メイリオ", 30), Brushes.White, new Point(20, 50));
                }

            }
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            setForm.WeekDay = btn.Text;
            setForm.Show();
        }
    }
}
