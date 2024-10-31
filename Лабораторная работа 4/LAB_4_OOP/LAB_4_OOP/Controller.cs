using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LAB_4_OOP.Classes;
using static LAB_4_OOP.Classes.Transport;
using System.Text.Json;

namespace LAB_4_OOP
{
    internal class Controller
    {
        public void SortTransport(Agency agency)
        {
            for(int i = 0; i < agency.agencies.Count - 1; i++)
            {
                for(int j = 0; j < agency.agencies.Count - 1 - i; j++)
                {
                    if (agency.agencies[j].engine.EngineVolume > agency.agencies[j + 1].engine.EngineVolume)
                    {
                        Transport buf = agency.agencies[j];
                        agency.agencies[j] = agency.agencies[j + 1];
                        agency.agencies[j + 1] = buf;
                    }
                }
            }
        }

        public void Search(Agency agency, int start, int end)
        {
            bool t = false;
            for(int i = 0; i < agency.agencies.Count; i++)
            {
                if (agency.agencies[i].Velocity >= start && agency.agencies[i].Velocity <= end)
                {
                    Console.WriteLine(agency.agencies[i].ToString());
                    t = true;
                }
            }
            if (!t)
            {
                Console.WriteLine("Подходящих транспортных средств нет\n");
            }
        }

        public Agency ReturnCollectionFromFile(string filepath) {
            Agency agency = new Agency();
            if (!File.Exists(filepath))
            {
                Console.WriteLine("Файл не найден.");
                return agency;
            }

            using (StreamReader reader = new StreamReader(filepath))
            {
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    var words = line.Split(',');
                    if(words.Length == 6 && double.TryParse(words[0], out double price) && double.TryParse(words[1], out double velocity) &&
                    double.TryParse(words[3], out double enginepower) && double.TryParse(words[4], out double enginevolume) &&
                    double.TryParse(words[5], out double compression))
                    {
                        var transport = new Transport(velocity, words[2], price, new Engine(enginepower, enginevolume, compression));
                        agency.agencies.Add(transport);
                    }
                    else
                    {
                        Console.WriteLine("Ошибка в формате");
                        break;
                    }
                }
            }
            return agency;
        }
        public Agency ReturnCollectionFromJsonFile(string filePath)
        {
            Agency agency = new Agency();
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не найден.");
                return agency;
            }

            string json = File.ReadAllText(filePath);
            agency.agencies = JsonSerializer.Deserialize<List<Transport>>(json);

            return agency ?? new Agency();
        }
    }
}
