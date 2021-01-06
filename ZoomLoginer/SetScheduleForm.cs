using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZoomLoginer
{
    class SetScheduleForm : BaseForm
    {
        PaintEventArgs paintEventArgs;
        public string WeekDay { get; set; }

        SelectEvent SelectEvent;
        public SetScheduleForm()
        {
            SelectEvent = new SelectEvent()
            {
                Size = new System.Drawing.Size(475,300),
                Location = new System.Drawing.Point(50, 150),
                BackColor = System.Drawing.Color.FromArgb(60, 60, 60)
            };

            Controls.Add(SelectEvent);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            paintEventArgs = e;
        }
    }

}
