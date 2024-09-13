using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Lab_2_OOP
{
    public class Program
    {
        public class Seats
        {
            private int all; // общие
            public int All
            {
                get { return this.GetTheTotalNumberOfSeats(); }
                private set { all = value; }
            }
            int compartment; // купе
            public int Compartment
            {
                get { return compartment; }
                set
                {
                    if (value < 0)
                    {
                        Console.WriteLine("Количество мест не может быть меньше нуля");
                    }
                    compartment = value;
                }
            }
            int reservedSeat; // плацкарт
            public int ReservedSeat
            {
                get { return reservedSeat; }
                set
                {
                    if (value < 0)
                    {
                        Console.WriteLine("Количество мест не может быть меньше нуля");
                    }
                    reservedSeat = value;
                }
            }
            int luxury; // люкс
            public int Luxury
            {
                get { return luxury; }
                set
                {
                    if (value < 0)
                    {
                        Console.WriteLine("Количество мест не может быть меньше нуля");
                    }
                    luxury = value;
                }
            }
            private Seats() // закрытый конструктор
            {
                all = 0;
                compartment = 0;
                reservedSeat = 0;
                luxury = 0;
            }
            public Seats(int com, int reserv, int lux)
            {
                SetTheTotalNumberOfSeats(ref com, ref reserv, ref lux,out all);
                compartment = com;
                reservedSeat = reserv;
                luxury = lux;
            }

            public int GetTheTotalNumberOfSeats()
            {
                return all;
            }
            public void SetTheTotalNumberOfSeats(ref int com, ref int reserv, ref int lux, out int al)
            {
                al = com + reserv + lux;
            }
        }
        public partial class Train // из-за partial мы можем разбить определение класса на несколько файлов
        {
            public readonly int id; // поле только для чтения
            const int theNumberOfDifferentTypesOfPlaces = 3;
            public static int numberOfObjects = 0;
            string destination; // пункт назначения
            public string Destination
            {
                get { return destination; }
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        Console.WriteLine("Пункт назначения не может быть пустой строкой");
                    }
                    destination = value;
                }
            }
            int trainNumber; // номер поезда
            public int TrainNumber // метод-аксессор для номера поезда
            {
                get { return trainNumber; }
                set { if (value < 0) { 
                        Console.WriteLine("Номер поезда не может включать отрицательные числа");
                    }
                    trainNumber = value;
                }
            }
            TimeSpan departureTime; // время отправления
            public TimeSpan DepartureTime // метод-аксессор для времени отправления
            {
                get { return departureTime; }
                set
                {
                    if (value.Hours < 0 || value.Hours > 23 || value.Minutes < 0 || value.Minutes > 59 || value.Seconds > 60 || value.Seconds < 0)
                    {
                        Console.WriteLine("Некорректное время");
                    }
                    departureTime = value;
                }
            }
            Seats numberOfSeats;
            
            public Train() // конструктор по умолчанию
            {
                destination = "Минск";
                trainNumber = 1;
                departureTime = new TimeSpan(1,0,0);
                numberOfSeats = new Seats(10, 10, 5);
                id = GetHashCode();
                numberOfObjects++;
            }

            public Train(string dest, int num, TimeSpan time, Seats seat) // конструктор с параметрами
            {
                destination = dest;
                trainNumber = num;
                departureTime = time;
                numberOfSeats = seat;
                id = GetHashCode();
                numberOfObjects++;
            }

            public Train(string dest = "Минск", int num = 1) // конструктор с параметрами по умолчанию
            {
                destination = dest;
                trainNumber = num;
                departureTime = new TimeSpan(1, 0, 0);
                numberOfSeats = new Seats(10, 10, 5);
                id = GetHashCode();
                numberOfObjects++;
            }

            static Train() // статический конструктор
            {
                Console.WriteLine("Это статический конструктор");
            }

            public void WriteTheTotalNumberOfSeats()
            {
                Console.WriteLine("Общее количество мест в поезде с номером {1} = {0}", numberOfSeats.GetTheTotalNumberOfSeats(), this.id);
            }

            public static void WriteInformationAboutClass(Train train)
            {
                Console.WriteLine("Информация о текущем объекте класса Train:\n");
                Console.WriteLine($"ID: {train.id}");
                Console.WriteLine($"Номер поезда: {train.trainNumber}");
                Console.WriteLine($"Пункт назначения: {train.destination}");
                Console.WriteLine($"Время отправления: {train.departureTime.ToString()}");
                train.WriteTheTotalNumberOfSeats();
                Console.WriteLine($"Количество мест купе {train.numberOfSeats.Compartment}");
                Console.WriteLine($"Количество мест плацкарт {train.numberOfSeats.ReservedSeat}");
                Console.WriteLine($"Количество мест люкс {train.numberOfSeats.Luxury}");
                Console.WriteLine();
            }

            public override bool Equals(object? obj)
            {
                return obj is Train train && train.id == id 
                    && train.trainNumber == trainNumber 
                    && train.destination == destination 
                    && train.departureTime == departureTime 
                    && train.numberOfSeats == numberOfSeats;
            }

            public override int GetHashCode()
            {
                return Math.Abs(trainNumber.GetHashCode() + destination.GetHashCode());
            }

            public override string ToString()
            {
                return ($" ID = {id}\n TrainNumber = {trainNumber}\n Destination = {destination}\n ");
            }
        }
        public static void Main()
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            Train train1 = new Train();
            Train.WriteInformationAboutClass(train1);
            Console.WriteLine("Тип объекта train1 {0}", train1.GetType());

            Train train2 = new Train("Горки", 2, new TimeSpan(2, 20, 22), new Seats(10, 5, 2));
            train2.WriteTheTotalNumberOfSeats();
            Train.WriteInformationAboutClass(train2);

            Train train3 = new Train("Орша");
            Train.WriteInformationAboutClass(train3);

            Console.WriteLine(train1 == train2);
            Console.WriteLine("Поезд с ID {0} отправляется в {1}", train3.id, train3.DepartureTime);

            Train[] trains = new Train[] {
                new Train("Горки", 2, new TimeSpan(12, 20, 00), new Seats(15, 10, 5)),
                new Train("Горки", 5, new TimeSpan(17, 50, 00), new Seats(15, 10, 5)),
                new Train("Москва", 10, new TimeSpan(8, 20, 00), new Seats(25, 20, 7)),
                new Train("Орша", 6, new TimeSpan(13, 30, 00), new Seats(10, 7, 5)),
            };
            Console.WriteLine("Введите пункт назначения");
            string? currentdest = Console.ReadLine();
            Console.WriteLine("Информация о подходящих Вам поездах\n");
            bool f = false;
            for(int i = 0; i < trains.Length; i++)
            {
                if (trains[i].Destination == currentdest)
                {
                    Train.WriteInformationAboutClass(trains[i]);
                    f = true;
                }
            }
            if (!f) {
                Console.WriteLine("По Вашему запросу ничего не найдено");
            }

            f = false;
            Console.WriteLine("Введите пункт назначения");
            currentdest = Console.ReadLine();
            Console.WriteLine("Введите время, после которого Вам удобно отравиться, чтобы получить информацию о подходящих поездах");

            TimeSpan t = new TimeSpan();
            string? buf = Console.ReadLine();
            if (TimeSpan.TryParse(buf, out t))
            {
                t = TimeSpan.Parse(buf);
            }
            else
            {
                throw new InvalidCastException();
            }

            for (int i = 0; i < trains.Length; i++)
            {
                if (trains[i].Destination == currentdest && trains[i].DepartureTime > t)
                {
                    Train.WriteInformationAboutClass(trains[i]);
                    f = true;
                }
            }

            if (!f)
            {
                Console.WriteLine("По Вашему запросу ничего не найдено");
            }

            var anonymous = new
            {
                Destination = "Горки",
                TrainNumber = 20,
                DepartureTime = TimeSpan.Parse("14:45:00"),
                seat = new Seats(10, 5, 5)
            };
            Console.WriteLine(anonymous.GetType());
            Console.WriteLine(Train.numberOfObjects);
        }
    }
}