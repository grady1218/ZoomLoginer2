﻿using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace ZoomLoginer
{
    class SelectEvent : DataGridView
    {
        string[] data;
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

        public void Load(string FileName)
        {
            try
            {
                data = File.ReadAllLines($"./data/{FileName}.zl");
                SetData();
            }
            catch
            {
                //  MessageBox.Show("ファイルを読み込めませんでした");
            }
        }

        void SetData()
        {
            foreach(var i in data)
            {
                var info = i.Split(',');
                if(info.Length == ColumnCount + 1) Rows.Add(info);
            }
        }

        public void Save(string fileName)
        {
            List<string> dList = new List<string>();
            for(int i = 0; i < Rows.Count - 1; i++)
            {
                string str = "";
                for(int j = 0; j < ColumnCount; j++) str += (string)Rows[i].Cells[j].Value + ",";
                dList.Add(str);
            }

            File.WriteAllLines($"./data/{fileName}.zl",dList.ToArray());

            EventProcessor.Load();
        }

    }
}
