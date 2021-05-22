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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;

        public Option()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.osirase = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // osirase
            // 
            this.osirase.AutoSize = true;
            this.osirase.Font = new System.Drawing.Font("メイリオ", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.osirase.ForeColor = System.Drawing.Color.White;
            this.osirase.Location = new System.Drawing.Point(230, 51);
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
            this.textBox1.Size = new System.Drawing.Size(100, 43);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "5";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(104, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 45);
            this.button1.TabIndex = 2;
            this.button1.Text = "参加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += (object sender, EventArgs e) => System.Diagnostics.Process.Start(EventProcessor.PreClassName);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("メイリオ", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(210, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(333, 30);
            this.label2.TabIndex = 4;
            this.label2.Text = "一つ前のミーティングに参加します";
            // 
            // Option
            // 
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
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
