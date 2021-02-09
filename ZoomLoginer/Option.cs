using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoomLoginer
{
    class Option : BaseForm
    {
        private System.Windows.Forms.Label osirase;
        private System.Windows.Forms.TextBox textBox1;

        public Option()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.osirase = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // osirase
            // 
            this.osirase.AutoSize = true;
            this.osirase.Font = new System.Drawing.Font("メイリオ", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.osirase.ForeColor = System.Drawing.Color.White;
            this.osirase.Location = new System.Drawing.Point(210, 55);
            this.osirase.Name = "osirase";
            this.osirase.Size = new System.Drawing.Size(313, 30);
            this.osirase.TabIndex = 0;
            this.osirase.Text = "分前にお知らせするようにします";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox1.Location = new System.Drawing.Point(104, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Text = EventProcessor.PreTime.ToString();
            this.textBox1.Size = new System.Drawing.Size(100, 43);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Option
            // 
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.osirase);
            this.Name = "Option";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int num)) EventProcessor.PreTime = num;
            else
            {
                Console.WriteLine("失敗してるよ！");
                EventProcessor.PreTime = 5;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            System.IO.File.WriteAllLines($"./data/option.zl",new string[]{EventProcessor.PreTime.ToString()});
            EventProcessor.Load();
            base.OnClosed(e);
        }
    }
}
