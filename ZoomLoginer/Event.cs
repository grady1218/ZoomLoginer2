
using System.Drawing;
using System.Windows.Forms;

namespace ZoomLoginer
{
    class Event : BaseForm
    {
        SelectEvent SelectEvent;
        public Event()
        {
            SelectEvent = new SelectEvent()
            {
                Size = new Size(475, 325),
                Location = new Point(50, 125),
                ColumnCount = 4,
            };

            SelectEvent.Columns[0].HeaderText = "日にち";
            SelectEvent.Columns[1].HeaderText = "イベント名";
            SelectEvent.Columns[2].HeaderText = "URL";
            SelectEvent.Columns[3].HeaderText = "時間";


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
                SelectEvent.Save("event");
                Close();
            };

            SelectEvent.Load("event");
            Controls.Add(SelectEvent);
            Controls.Add(button);
        }
    }
}
