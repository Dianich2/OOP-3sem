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
            Car car = new Car("Black", 4500, "Toyota", new Transport.Engine(), new CarSeats(), 150, "car");
            car.Start();
            car.Stop(); 
            car.OutInformationAboutCar();
            Console.WriteLine(car.GetType());
            Console.WriteLine(car.GetHashCode());
            Console.WriteLine();

            Train train = new Train("2", "Minsk", 10, 200, 150, "train", 5000, new Transport.Engine());
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

            Agency agency = new Agency();
            agency.AddTransport(new Car());
            agency.AddTransport(transport);
            agency.AddTransport(new Train());
            agency.AddTransport(new Express());
            agency.AddTransport(new Car("Black", 4000, "Honda", new Transport.Engine(), new CarSeats(), 150, "car"));
            agency.PrintTransport();
            agency.RemoveTransport(transport);
            agency.PrintTransport();
            agency.PrintPrice();

            Controller controller = new Controller();
            controller.SortTransport(agency);
            agency.PrintTransport();
            controller.Search(agency, 50, 60);

            Agency agencyFromFile = controller.ReturnCollectionFromFile("forRead.txt");
            agencyFromFile.PrintTransport();

            Agency agencyFromJSONFile = controller.ReturnCollectionFromJsonFile("forReadJSON.json");
            agencyFromJSONFile.PrintTransport();

            ///////////////////////////
            try
            {
                Car car1 = new Car("Black", -10, "BMW", new Transport.Engine(), new CarSeats(), 140, "car");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            try
            {
                Car car2 = new Car("Black", 2000, "BMW", new Transport.Engine(), new CarSeats(), -140, "car");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            try
            {
                Car car3 = new Car("Black", 2000, "BMW", new Transport.Engine(), new CarSeats(), 140, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            try
            {
                Car car4 = new Car("Black", 2000, "BMW", new Transport.Engine(), new CarSeats(), 270, "car");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            try
            {
                Car car5 = new Car("Black", 2000, "BMW", new Transport.Engine(0, 10, 100), new CarSeats(), 270, "car");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine("Обработка ошибок произошла успешно");
            }

            try
            {
                firstMethod();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Обработка исключения в main" + ex.ToString() + "    ");
                Console.WriteLine("Диагностика" + ex.StackTrace + "    ");
                Console.WriteLine("Причина" + ex.Message + "    ");
            }
            finally
            {
                Console.WriteLine("Обработка закончилась");
            }

            void firstMethod(){
                try
                {
                    secondMetod();
                }
                catch (Exception ex) { 
                    Console.WriteLine("Обработка в первом методе" + ex.ToString() + "    ");
                    throw;
                }
            }

            void secondMetod()
            {
                thirdMetod();
            }

            void thirdMetod() {
                int t = 0;
                int res = 7 / t;
            }
        }
    }
}