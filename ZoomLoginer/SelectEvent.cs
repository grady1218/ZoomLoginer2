using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ZoomLoginer
{
    class SelectEvent : DataGridView
    {
        public SelectEvent()
        {
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            AllowUserToResizeColumns = false;
            AllowUserToResizeRows = false;

            ColumnCount = 3;
            
            Columns[0].HeaderText = "イベント名";
            Columns[1].HeaderText = "URL";
            Columns[2].HeaderText = "時間";

        }

    }
}
