using System;
using System.Collections.Generic;
using System.IO;

namespace ZoomLoginer
{
     static class EventProcessor
    {

        public static string[] eDays = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        public static string[] days = { "月", "火", "水", "木", "金", "土", "日" };
        public static string Today;
        public static string JapaneseToday;
        public static int PreTime = 5;

        public static List<DateTime> Times = new List<DateTime>();
        public static List<string> URLs = new List<string>();
        public static List<string> EventNames = new List<string>();

        enum DisassembleMode
        {
            NormalEvent,
            SpecialEvent,
            FreeEvent
        }

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
                Times = new List<DateTime>();
                URLs = new List<string>();
                EventNames = new List<string>();

                //  なんだここ　無駄やんけ
                /*
                Disassembly(File.ReadAllLines($"./data/{JapaneseToday}.zl"), DisassembleMode.NormalEvent);
                Disassembly(File.ReadAllLines($"./data/event.zl"), DisassembleMode.SpecialEvent);
                Disassembly(File.ReadAllLines($"./data/free.zl"), DisassembleMode.FreeEvent);
                */


                OptionSettings(File.ReadAllLines($"./data/option.zl"));
                NormalEventProcess(File.ReadAllLines($"./data/{JapaneseToday}.zl"));
                SpecialEventProcess(File.ReadAllLines($"./data/event.zl"));
                FreeEventProcess(File.ReadAllLines($"./data/free.zl"));



            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("ファイルが開けませんでした\nイベントの再登録をしてください。", "File Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
            }
        }
        
        static void Disassembly(string[] data, DisassembleMode mode)
        {

            switch (mode)
            {
                case DisassembleMode.NormalEvent:
                    NormalEventProcess(data);
                    break;

                case DisassembleMode.SpecialEvent:
                    SpecialEventProcess(data);
                    break;

                case DisassembleMode.FreeEvent:
                    FreeEventProcess(data);
                    break;

                default:
                    break;
            }
            
        }
        static void NormalEventProcess(string[] data)
        {
            var Today = DateTime.Today;
            foreach (var infos in data)
            {
                var info = infos.Split(',');
                if (info.Length == 4)
                {
                    try
                    {
                        var dayInfo = info[2].Split(':');
                        if (dayInfo.Length == 2)
                        {
                            Times.Add(new DateTime(Today.Year, Today.Month, Today.Day, int.Parse(dayInfo[0]), int.Parse(dayInfo[1]), 0));
                            EventNames.Add(info[0]);
                            URLs.Add(info[1]);
                        }
                        else if (dayInfo.Length == 3)
                        {
                            Times.Add(new DateTime(Today.Year, Today.Month, Today.Day, int.Parse(dayInfo[0]), int.Parse(dayInfo[1]), int.Parse(dayInfo[2])));
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
        static void SpecialEventProcess(string[] data)
        {
            var Today = DateTime.Today;
            foreach (var infos in data)
            {
                var info = infos.Split(',');
                if (info.Length == 5)
                {
                    
                    if (!(DateTime.Today.ToString("MM/dd") == info[0] || DateTime.Today.ToString("MM月dd日") == info[0])) continue;  //  曜日が違っていたらcontinueする

                    try
                    {
                        var dayInfo = info[3].Split(':');
                        if (dayInfo.Length == 2)
                        {
                            Times.Add(new DateTime(Today.Year, Today.Month, Today.Day, int.Parse(dayInfo[0]), int.Parse(dayInfo[1]), 0));
                            EventNames.Add(info[1]);
                            URLs.Add(info[2]);
                        }
                        else if (dayInfo.Length == 3)
                        {
                            Times.Add(new DateTime(Today.Year, Today.Month, Today.Day, int.Parse(dayInfo[0]), int.Parse(dayInfo[1]), int.Parse(dayInfo[2])));
                            EventNames.Add(info[1]);
                            URLs.Add(info[2]);
                        }
                    }
                    catch
                    {
                        return;
                    }
                }
            }
        }
        static void FreeEventProcess(string[] data)
        {
            foreach (var infos in data)
            {
                var info = infos.Split(',');
                if (info.Length == 3)
                {

                    if (!(DateTime.Today.ToString("MM/dd") == info[0] || DateTime.Today.ToString("MM月dd日") == info[0])) continue;  //  曜日が違っていたらcontinueする

                    try
                    {
                        for(int i = 0; i < EventNames.Count; i++)
                        {
                            if(EventNames[i] == info[1])
                            {
                                URLs.RemoveAt(i);
                                Times.RemoveAt(i);
                                EventNames.RemoveAt(i);
                                i -= 1;
                            }
                        }
                    }
                    catch
                    {
                        return;
                    }
                }
            }
        }
        static void OptionSettings(string[] data)
        {
            PreTime = int.Parse(data[0]);
        }
     }
}
