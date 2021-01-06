using System;
using System.Collections.Generic;
using System.IO;

namespace ZoomLoginer
{
     static class EventProcessor
    {

        public static string[] eDays = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Sutrday", "Sunday" };
        public static string[] days = { "月", "火", "水", "木", "金", "土", "日" };
        public static string Today;
        public static string JapaneseToday;

        public static List<DateTime> Times = new List<DateTime>();
        public static List<string> URLs = new List<string>();
        public static List<string> EventNames = new List<string>();
        public static void GetToday()
        {
            for (int i = 0; i < eDays.Length; i++)
            {
                if (DateTime.Today.DayOfWeek.ToString() == eDays[i])
                {
                    Today = eDays[i];
                    JapaneseToday = days[i];
                }
            }
        }
        public static void Load()
        {
            try
            {
                Disassembly(File.ReadAllLines($"./data/{JapaneseToday}.zl"));
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("ファイルが開けませんでした\nイベントの再登録をしてください。", "File Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
            }
        }
        
        static void Disassembly(string[] data)
        {
            var Today = DateTime.Today;
            foreach (var infos in data)
            {
                var info = infos.Split(',');
                if(info.Length == 4)
                {
                    try
                    {
                        var dayInfo = info[2].Split(':');
                        if(dayInfo.Length == 2)
                        {
                            Times.Add(new DateTime(Today.Year,Today.Month,Today.Day,int.Parse(dayInfo[0]),int.Parse(dayInfo[1]),0));
                            EventNames.Add(info[0]);
                            URLs.Add(info[1]);
                        }
                        else if(dayInfo.Length == 3)
                        {
                            Times.Add(new DateTime(Today.Year,Today.Month,Today.Day,int.Parse(dayInfo[0]),int.Parse(dayInfo[1]), int.Parse(dayInfo[2])));
                            EventNames.Add(info[0]);
                            URLs.Add(info[1]);
                        }
                    }
                    catch
                    {
                        return;
                    }
                }
            }
        }
     }
}
