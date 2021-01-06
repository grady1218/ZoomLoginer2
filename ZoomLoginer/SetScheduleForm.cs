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
                Size = new Size(475,300),
                Location = new Point(50, 150),
                BackColor = Color.FromArgb(60, 60, 60)
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

    }

}
