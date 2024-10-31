using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using LAB_10_OOP;

namespace Lab_10_OOP
{
    public class Program
    {
        public static void Main()
        {
            string[] month = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            Console.WriteLine("Введите длину строки");
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine("Месяцы с введенной длиной строки");
            IEnumerable<string> first = month.Where(n => n.Length == k).Select(n => n);
            foreach (string s in first) { 
                Console.WriteLine(s);
            }

            Console.WriteLine("\nЛетние и зимние месяцы");
            IEnumerable<string> SummerOrWinter = month.Where(n => n is ("January" or "December" or "February" or "June" or "July" or "August")).Select(n => n);
            foreach (string s in SummerOrWinter)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("\nМесяцы в алфавитном порядке");
            IEnumerable<string> Order = month.OrderBy(n => n).Select(n => n);
            foreach (string s in Order)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("\nМесяцы, у которых есть буква u и длина не меньше 4");
            IEnumerable<string> newMonth = month.Where(n => n.IndexOf('u') != -1 && n.Length >= 4).Select(n => n);
            foreach (string s in newMonth)
            {
                Console.WriteLine(s);
            }
            /////////////////////////////////////////////////////////////////////////////////////////

            List<Train> trains = new List<Train>();
            trains.Add(new Train("Горки", 2, new TimeSpan(12, 20, 00), new Seats(15, 10, 5)));
            trains.Add(new Train("Горки", 5, new TimeSpan(17, 50, 00), new Seats(15, 10, 5)));
            trains.Add(new Train("Москва", 10, new TimeSpan(8, 20, 00), new Seats(25, 20, 7)));
            trains.Add(new Train("Орша", 6, new TimeSpan(13, 30, 00), new Seats(10, 7, 5)));
            trains.Add(new Train("Минск", 20, new TimeSpan(12, 30, 00), new Seats(20, 10, 5)));
            trains.Add(new Train("Смоленск", 8, new TimeSpan(20, 50, 00), new Seats(10, 10, 5)));
            trains.Add(new Train("Литва", 14, new TimeSpan(15, 20, 00), new Seats(29, 20, 7)));
            trains.Add(new Train("Минск", 12, new TimeSpan(19, 28, 00), new Seats(56, 7, 5)));
            trains.Add(new Train("Минск", 24, new TimeSpan(15, 45, 00), new Seats(29, 20, 7)));
            trains.Add(new Train("Минск", 22, new TimeSpan(19, 50, 00), new Seats(56, 7, 5)));

            Console.WriteLine("\nПоезда, у которых пункт назначения Минск\n");
            IEnumerable<Train> trains1 = trains.Where(n => n.Destination == "Минск");
            foreach (Train s in trains1)
            {
                Train.WriteInformationAboutClass(s);
            }

            Console.WriteLine("\nПоезда, у которых пункт назначения Минск и они отправляются после 16:00\n");
            IEnumerable<Train> trains2 = trains.Where(n => n.Destination == "Минск" && n.DepartureTime > new TimeSpan(16, 00, 00));
            foreach (Train s in trains2)
            {
                Train.WriteInformationAboutClass(s);
            }

            Console.WriteLine("\nПоезда, у которых самое большое число мест\n");
            IEnumerable<Train> trains3 = trains.Where(n => n.numberOfSeats.All == trains.Max(s => s.numberOfSeats.All));
            foreach (Train s in trains3)
            {
                Train.WriteInformationAboutClass(s);
            }

            Console.WriteLine("\nПоезда, последние 5 по времени отправления\n");
            IEnumerable<Train> trains4 = trains.OrderBy(n => n.DepartureTime).TakeLast(5);
            foreach (Train s in trains4)
            {
                Train.WriteInformationAboutClass(s);
            }

            Console.WriteLine("\nПоезда, по пункту назначения в алфавитном порядке\n");
            IEnumerable<Train> trains5 = trains.OrderBy(n => n.Destination);
            foreach (Train s in trains5)
            {
                Train.WriteInformationAboutClass(s);
            }

            ////////////////////////////////////////////////////////////////

            Console.WriteLine("\nСобственный запрос с 5 операторами\n");
            IEnumerable<Train> trains6 = trains.Where(n => n.Destination == "Минск").OrderBy(n => n.TrainNumber).Skip(2).Select(n => n).ToList();
            foreach (Train s in trains6)
            {
                Train.WriteInformationAboutClass(s);
            }

            //////////////////////////////////////////////////////////////

            List<int> counts = new List<int>()
            {
                5, 6, 7, 8, 9
            };

            List<string> strings = new List<string>()
            {
                "first", "second", "third"
            };

            var usejoin = counts.Join(strings, count => count, string1 => string1.Length, (count, string1) => new { string2 = string1, length = count });
            foreach (var s in usejoin)
            {
                Console.WriteLine($"{s.string2} {s.length}");
            }

        }
    }
}