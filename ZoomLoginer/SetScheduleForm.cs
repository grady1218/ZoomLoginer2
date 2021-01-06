using System.Windows.Forms;
using System.Drawing;

namespace ZoomLoginer
{
    class SetScheduleForm : BaseForm
    {
        public string WeekDay { get; set; }

        SelectEvent SelectEvent;
        public SetScheduleForm(string day)
        {

            WeekDay = day;

            SelectEvent = new SelectEvent()
            {
                Size = new Size(475,325),
                Location = new Point(50, 125),
            };

            Button button = new Button
            {
                Size = new Size(150, 50),
                Location = new Point(400, 475),
                BackColor = Color.FromArgb(80, 80, 80),

                Text = "確定",
                ForeColor = Color.White
            };

            button.Click += (object sender, System.EventArgs e) =>
            {
                SelectEvent.Save(WeekDay);
                Close();
            };

            SelectEvent.Load(WeekDay);
            Controls.Add(SelectEvent);
            Controls.Add(button);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawString($"編集中 : {WeekDay}曜日", new Font("メイリオ", 30), Brushes.White, new Point(20, 50));
        }

    }

}
