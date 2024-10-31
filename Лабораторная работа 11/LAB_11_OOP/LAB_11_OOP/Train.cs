using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace LAB_11_OOP
{
    public class Seats
    {
        private int all;
        public int All
        {
            get { return this.GetTheTotalNumberOfSeats(); }
            private set { all = value; }
        }
        int compartment;
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
        int reservedSeat;
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
        int luxury;
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
        private Seats()
        {
            all = 0;
            compartment = 0;
            reservedSeat = 0;
            luxury = 0;
        }
        public Seats(int com, int reserv, int lux)
        {
            SetTheTotalNumberOfSeats(ref com, ref reserv, ref lux, out all);
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
    public class Train
    {
        public readonly int id;
        const int theNumberOfDifferentTypesOfPlaces = 3;
        public static int numberOfObjects = 0;
        string destination;
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
        int trainNumber;
        public int TrainNumber
        {
            get { return trainNumber; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Номер поезда не может включать отрицательные числа");
                }
                trainNumber = value;
            }
        }
        TimeSpan departureTime;
        public TimeSpan DepartureTime
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
        public Seats numberOfSeats;

        public Train()
        {
            destination = "Минск";
            trainNumber = 1;
            departureTime = new TimeSpan(1, 0, 0);
            numberOfSeats = new Seats(10, 10, 5);
            id = GetHashCode();
            numberOfObjects++;
        }

        public Train(string dest, int num, TimeSpan time, Seats seat)
        {
            destination = dest;
            trainNumber = num;
            departureTime = time;
            numberOfSeats = seat;
            id = GetHashCode();
            numberOfObjects++;
        }

        public Train(string dest = "Минск", int num = 1)
        {
            destination = dest;
            trainNumber = num;
            departureTime = new TimeSpan(1, 0, 0);
            numberOfSeats = new Seats(10, 10, 5);
            id = GetHashCode();
            numberOfObjects++;
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
}
