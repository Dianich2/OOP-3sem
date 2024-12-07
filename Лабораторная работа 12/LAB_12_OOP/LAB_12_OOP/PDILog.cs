using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LAB_12_OOP
{
    internal static class PDILog
    {
        public static void WriteInformationAboutLog()
        {
            string path = Path.GetFullPath("PDIlog.txt");
            using (StreamWriter wr = new StreamWriter(path, true, Encoding.Default))
            {
                wr.WriteLine($"Файл log: {Path.GetFileName(path)}");
                wr.WriteLine($"Путь к файлу: {path}");
                wr.WriteLine($"Время записи: {DateTime.Now}");
            }
        }

        public static void WriteInformationFromOtherMethods(string inf)
        {
            string path = Path.GetFullPath("PDIlog.txt");
            using (StreamWriter wr = new StreamWriter(path, true, Encoding.Default))
            {
                wr.WriteLine($"Запись: {DateTime.Now}\n{inf}-----");
            }
        }

        public static string ReadFromLog()
        {
            string path = Path.GetFullPath("PDIlog.txt");
            using (StreamReader rd = new StreamReader(path))
            {
                return rd.ReadToEnd();
            }
        }

        public static string SearchInformationInLogByDate(DateTime date)
        {
            string path = Path.GetFullPath("PDIlog.txt");
            using (StreamReader rd = new StreamReader(path))
            {
                string inf = rd.ReadToEnd();
                string[] infMas = inf.Split('\n');
                List<string> result = new List<string>();
                for(int i = 0; i < infMas.Length; i++)
                {
                    if (infMas[i].Contains(date.ToString()))
                    {
                        while (!infMas[i].Contains("-----")){
                            result.Add(infMas[i]);
                            i++;
                        }
                    }
                }
                return string.Join('\n', result);
            }
        }

        public static string SearchInformationInLogForPeriod(DateTime date1, DateTime date2)
        {
            string path = Path.GetFullPath("PDIlog.txt");
            using (StreamReader rd = new StreamReader(path))
            {
                string inf = rd.ReadToEnd();
                string[] infMas = inf.Split('\n');
                List<string> result = new List<string>();
                for (int i = 0; i < infMas.Length; i++)
                {
                    if (infMas[i].Contains("Запись: "))
                    {
                        string[] j = infMas[i].Split(' ');
                        DateTime d = DateTime.Parse(j[1] + ' ' + j[2]);
                        if (date1 <= d && date2 >= d)
                        {
                            while (!infMas[i].Contains("-----"))
                            {
                                result.Add(infMas[i]);
                                i++;
                            }
                        }
                    }
                }
                return string.Join('\n', result);
            }
        }

        public static string SearchInformationInLogByKeyWord(string keyword)
        {
            string path = Path.GetFullPath("PDIlog.txt");
            using (StreamReader rd = new StreamReader(path))
            {
                string inf = rd.ReadToEnd();
                string[] infMas = inf.Split('\n');
                List<string> result = new List<string>();
                for (int i = 0; i < infMas.Length; i++)
                {
                    if (infMas[i].Contains(keyword))
                    {
                        while (!infMas[i].Contains("-----"))
                        {
                            result.Add(infMas[i]);
                            i++;
                        }
                    }
                }
                return string.Join('\n', result);
            }
        }

        public static int Count()
        {
            string path = Path.GetFullPath("PDIlog.txt");
            using (StreamReader rd = new StreamReader(path))
            {
                string inf = rd.ReadToEnd();
                string[] infMas = inf.Split('\n');
                return infMas.Count();
            }
        }

        public static void DeleteInformationFromLog()
        {
            string path = Path.GetFullPath("PDIlog.txt");
            DateTime date1 = DateTime.Now;
            DateTime date2 = date1.AddHours(-1);
            List<string> result = new List<string>();
            using (StreamReader rd = new StreamReader(path))
            {
                string inf = rd.ReadToEnd();
                string[] infMas = inf.Split('\n');
                for (int i = 0; i < infMas.Length; i++)
                {
                    if (infMas[i].Contains("Запись: "))
                    {
                        string[] j = infMas[i].Split(' ');
                        DateTime d = DateTime.Parse(j[1] + ' ' + j[2]);
                        if (date1 <= d && date2 >= d)
                        {
                            while (!infMas[i].Contains("-----"))
                            {
                                result.Add(infMas[i]);
                                i++;
                            }
                        }
                    }
                }
            }
            using (StreamWriter wr = new StreamWriter(path, false, Encoding.Default))
            {
                wr.WriteLine(string.Join('\n', result));
            }
        }
    }
}
