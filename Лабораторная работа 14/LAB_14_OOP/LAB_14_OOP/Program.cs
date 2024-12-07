using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Linq;
using System.Threading;
using System.Diagnostics.Tracing;

namespace Lab_14_OOP
{
    public class Program
    {
        static object locker = new();
        static AutoResetEvent oddEvent = new AutoResetEvent(false);
        static AutoResetEvent evenEvent = new AutoResetEvent(true);
        public static void Main()
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes) {
                Console.WriteLine($"ID процесса - {process.Id}");
                Console.WriteLine($"Имя процесса - {process.ProcessName}");
                try
                {
                    Console.WriteLine($"Приоритет процесса - {process.PriorityClass}");
                    Console.WriteLine($"Время запуска - {process.StartTime}");
                    Console.WriteLine($"Сколько всего времени запущен - {DateTime.Now - process.StartTime}");
                }
                catch (Exception ex) {
                    Console.WriteLine("Часть информации не может быть выведена, т.к. отказано в доступе");
                }
                Console.WriteLine($"Объем памяти, который выделен для данного процесса - {process.PagedMemorySize64}");
                Console.WriteLine($"Объем виртуальной памяти, который выделен для данного процесса - {process.VirtualMemorySize64}");
                Console.WriteLine($"Текущее состояние - {process.Responding}\n\n");
            }


            AppDomain curDomain = AppDomain.CurrentDomain;
            Console.WriteLine($"Имя домена - {curDomain.FriendlyName}");
            Console.WriteLine($"Базовый путь - {curDomain.BaseDirectory}");
            Console.WriteLine($"ID - {curDomain.Id}");
            Console.WriteLine($"Версия - {curDomain.SetupInformation.TargetFrameworkName}\n");
            Console.WriteLine("Сборки домена\n");
            foreach(var assem in curDomain.GetAssemblies())
            {
                Console.WriteLine($"{assem.FullName}\n");
            }


            //AppDomain newDomain = AppDomain.CreateDomain("NewDomain");
            //Assembly myassem = newDomain.Load("LAB_14_OOP.dll");
            //AppDomain.Unload(newDomain);


            static bool IsPrime(int num)
            {
                if (num <= 1)
                    return false;

                for (int i = 2; i <= Math.Sqrt(num); i++)
                {
                    if (num % i == 0)
                        return false; 
                }

                return true;
            }

            static void printNumbers()
            {
                int n = int.Parse(Console.ReadLine());
                using (StreamWriter wr = new StreamWriter("PrimeNumbers.txt", false))
                {
                    for (int i = 2; i <= n; i++)
                    {
                        if (IsPrime(i))
                        {
                            Console.Write($"{i} ");
                            wr.Write($"{i} ");
                            Thread.Sleep(100);
                        }
                    }
                }
                Console.WriteLine();
            }

            static void printOddNumbers(object? n)
            {
                int? n1 = (int)n;
                lock (locker)
                {
                    using (StreamWriter wr = new StreamWriter("OddAndEvenNumbers.txt", true))
                    {
                        for (int i = 0; i <= n1; i++)
                        {
                            if (i % 2 != 0)
                            {
                                Console.Write($"{i} ");
                                wr.Write($"{i} ");
                                Thread.Sleep(200);
                            }
                        }
                    }
                }
            }
            static void printEvenNumbers(object? n)
            {
                int? n1 = (int)n;
                lock (locker)
                {
                    using (StreamWriter wr = new StreamWriter("OddAndEvenNumbers.txt", true))
                    {
                        for (int i = 0; i <= n1; i++)
                        {
                            if (i % 2 == 0)
                            {
                                Console.Write($"{i} ");
                                wr.Write($"{i} ");
                                Thread.Sleep(500);
                            }
                        }
                    }
                }
            }

            static void printOddNumbers2(object? n)
            {
                evenEvent.Set();
                int n1 = (int)n;
                for (int i = 1; i <= n1; i += 2) 
                    {
                    oddEvent.WaitOne();
                    using (StreamWriter wr = new StreamWriter("OddAndEvenNumbers2.txt", true))
                    {
                        Console.Write($"{i} ");
                        wr.Write($"{i} ");
                        Thread.Sleep(500); 
                    }
                    evenEvent.Set();
                }
            }

            static void printEvenNumbers2(object? n)
            {

                int n1 = (int)n;
                for (int i = 0; i <= n1; i += 2) 
                    {
                    evenEvent.WaitOne();
                    using (StreamWriter wr = new StreamWriter("OddAndEvenNumbers2.txt", true))
                    {
                        Console.Write($"{i} ");
                        wr.Write($"{i} ");
                        Thread.Sleep(500); 
                    }
                    oddEvent.Set();
                }
            }

            Thread thread = new Thread(printNumbers);
            thread.Start();
            Console.WriteLine("Информация о текущем потоке\n");
            Console.WriteLine($"Имя потока - {thread.Name}");
            Console.WriteLine($"ID - {thread.ManagedThreadId}");
            Console.WriteLine($"Контекст - {thread.ExecutionContext}");
            Console.WriteLine($"Приоритет - {thread.Priority}");
            Console.WriteLine($"Статус - {thread.ThreadState}");
            thread.Join(); //приостановка основного потока


            int n = int.Parse(Console.ReadLine());
            Thread oddNumber = new Thread(new ParameterizedThreadStart(printOddNumbers));
            Thread evenNumber = new Thread(new ParameterizedThreadStart(printEvenNumbers));
            evenNumber.Priority = ThreadPriority.Highest;
            evenNumber.Start(n);
            oddNumber.Start(n);
            evenNumber.Join();
            oddNumber.Join();

            Thread oddNumber2 = new Thread(new ParameterizedThreadStart(printOddNumbers2));
            Thread evenNumber2 = new Thread(new ParameterizedThreadStart(printEvenNumbers2));
            evenNumber2.Start(n);
            oddNumber2.Start(n);

            static void saytime(object obj)
            {
                    Console.WriteLine($"Прошла секунда");
                    Thread.Sleep(1000);
            }

            Timer timer = new Timer(new TimerCallback(saytime), 0, 0, 1000);
            Console.ReadLine();
        }
    }
}