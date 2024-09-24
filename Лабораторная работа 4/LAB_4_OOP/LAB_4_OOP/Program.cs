using LAB_4_OOP;
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
using static LAB_4_OOP.Classes;

namespace Lab_4_OOP
{
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            ITransport itransport = new Car();
            itransport.Start();
            itransport.Stop();
            Transport transport = new Transport();
            transport.Start();
            transport.Stop();

            Car car = new Car("Black", 4500, "Toyota", new Transport.Engine(), 150, "car");
            car.Start();
            car.Stop(); 
            car.OutInformationAboutCar();
            Console.WriteLine(car.GetType());
            Console.WriteLine(car.GetHashCode());
            Console.WriteLine();

            Train train = new Train("2", "Minsk", 10, 200, 150, "train");
            train.Stop();
            train.Start();
            train.OutInformationAboutTrain();
            Console.WriteLine(train.GetType());
            Console.WriteLine();

            Express express = new Express();
            express.Start();
            express.Stop();
            express.OutInformationAboutExpress();
            Console.WriteLine(express.GetType());
            Console.WriteLine();

            Transport buf = car as Transport;
            Console.WriteLine(buf.GetType());
            buf.Start();
            buf.Stop();
            buf.OutInformationAboutTransport();

            if(car is Car)
            {
                Console.WriteLine("Это машина!\n");
            }


            BaseTransport[] transports = new BaseTransport[] { 
                new Car(), new Train(), new Express(), new Transport()
            };

            Printer print = new Printer();

            for(int i = 0; i < 4; i++)
            {
                print.IAmPrinting(transports[i]);
            }
        }
    }
}