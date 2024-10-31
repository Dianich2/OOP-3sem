using LAB_8_OOP;
using System;
using System.Collections.Generic;
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
using static LAB_8_OOP.User;

namespace Lab_8_OOP
{
    public class Program
    {
        public static void Main()
        {
            UpgradeUser upgradeUser = (User u, string n, string s, string p) =>
            {
                u.Name = n;
                u.Surname = s;
                u.Password = p;
            };
            UpgradeUser upgradeUser2 = (User u, string n, string s, string p) =>
            {
                u.Name = n + "2";
                u.Surname = s + "2";
                u.Password = p;
            };
            UserWork userWork = () =>
            {
                Console.WriteLine("User work from new delegate method");
            };
            UserWork userWork2 = () =>
            {
                Console.WriteLine("User work from new delegate method2");
            };
            User user = new User();
            user.upgrade += upgradeUser;
            user.PrintInformation();
            user.Upgrade("Вася", "Сидоров", "1111");
            user.PrintInformation();
            user.work += userWork;
            user.Work();

            User user2 = new User();
            user2.upgrade += upgradeUser2;
            user2.PrintInformation();
            user2.Upgrade("Саша", "Иванов", "1313");
            user2.PrintInformation();
            user2.work += userWork2;
            user2.Work();



            Console.WriteLine();



            static void deleteDot(string s)
            {
                s = s.Replace(".", "");
                Console.WriteLine(s);
            }

            static void ChangeToUpper(string s)
            {
                s = s.ToUpper();
                Console.WriteLine(s);
            }

            Action<string> deldot = deleteDot;

            deldot("Проверка. удаления... точек.....!!!");

            Action<string> toUpper = ChangeToUpper;

            toUpper("Замена всех букв на заглавные");


            static bool havePunctuationMarks(string s)
            {
                if(s.IndexOf('.') != -1 || s.IndexOf(',') != -1|| s.IndexOf('?') != -1 || s.IndexOf('!') != -1)
                {
                    return true;
                }
                return false;
            }

            Predicate<string> havePM = havePunctuationMarks;
            Console.WriteLine($"В строке есть знаки препинания? - {havePM("Тут есть . знаки,,,, препинания")}");
            Console.WriteLine($"В строке есть знаки препинания? - {havePM("Тут нет знаков препинания")}");

            static string removeUnnecessarySpace(string s)
            {
                while(s.Contains("  "))
                {
                    s = s.Replace("  ", " ");
                }
                return s;
            }


            Func<string, string> func = removeUnnecessarySpace;
            func += removeUnnecessarySpace;
            Console.WriteLine(func("Удаление    лишних      пробелов    !"));


            static bool haveNumbers(string s)
            {
                return s.Any(char.IsDigit);
            }


            Predicate<string> predicate = haveNumbers;
            Console.WriteLine($"В строке есть цифры? - {predicate("6789")}");
            Console.WriteLine($"В строке есть цифры? - {predicate("Нет")}");
        }
    }
}