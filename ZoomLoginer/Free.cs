using System.Drawing;
using System.Windows.Forms;

namespace ZoomLoginer
{
    class Free : BaseForm
    {
        SelectEvent SelectEvent;

        public Free()
        {

            SelectEvent = new SelectEvent()
            {
                Size = new Size(475, 325),
                Location = new Point(50, 125),
                ColumnCount = 2,
            };

            SelectEvent.Columns[0].HeaderText = "日にち";
            SelectEvent.Columns[1].HeaderText = "イベント名";


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
                    SelectEvent.Save("free");
                    Close();
                };

            SelectEvent.Load("free");
            Controls.Add(SelectEvent);
            Controls.Add(button);
        }
    }
}
