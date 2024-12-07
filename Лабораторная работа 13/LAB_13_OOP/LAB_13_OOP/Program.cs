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
using static LAB_13_OOP.Classes;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Linq;

namespace Lab_13_OOP
{
    public class Program
    {
        public static void Main()
        {
            Car original = new Car("Black", 2000, "BMW", new Transport.Engine(), new CarSeats(), 250, "new");
            //BinaryFormatter binaryFormatter = new BinaryFormatter();
            //using (FileStream stream = new FileStream("carbinary.bin", FileMode.Create))
            //{
            //    binaryFormatter.Serialize(stream, original);
            //}
            //Car copy;
            //using (FileStream stream = new FileStream("carbinary.bin", FileMode.Create))
            //{
            //    copy = (Car)binaryFormatter.Deserialize(stream);
            //}
            Console.WriteLine("С помощью JsonSerializer\n");
            string json = JsonSerializer.Serialize(original);
            using (StreamWriter wr = new StreamWriter("carjson.json", false, Encoding.Default))
            {
                wr.WriteLine(json);
            }
            Car copy2;
            using (StreamReader rd = new StreamReader("carjson.json"))
            {
                copy2 = JsonSerializer.Deserialize<Car>(rd.ReadToEnd());
            }
            copy2.OutInformationAboutCar();



            Console.WriteLine("С помощью XmlSerializer\n");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Car));
            using (StreamWriter wr = new StreamWriter("carxml.xml", false, Encoding.Default))
            {
                xmlSerializer.Serialize(wr, original);
            }
            Car copy3;
            using (StreamReader rd = new StreamReader("carxml.xml"))
            {
                copy3 = (Car)xmlSerializer.Deserialize(rd);
            }
            copy3.OutInformationAboutCar();

            Console.WriteLine("С помощью SoapFormatter\n");
            SoapFormatter soapFormatter = new SoapFormatter();
            using (FileStream wr = new FileStream("carsoap.soap", FileMode.Create))
            {
                soapFormatter.Serialize(wr, original);
            }
            Car copy4;
            using (FileStream rd = new FileStream("carsoap.soap", FileMode.OpenOrCreate))
            {
                copy4 = (Car)soapFormatter.Deserialize(rd);
            }
            copy4.OutInformationAboutCar();

            List<Car> mas = new List<Car>{
                new Car("Black", 2000, "BMW", new Transport.Engine(), new CarSeats(), 250, "new"),
                new Car("Red", 2500, "Opel", new Transport.Engine(), new CarSeats(), 220, "new"),
                new Car("Green", 1800, "Porsche", new Transport.Engine(), new CarSeats(), 250, "new"),
                new Car("Grey", 1500, "Lada", new Transport.Engine(), new CarSeats(), 190, "new")
            };

            Console.WriteLine("С помощью XmlSerializer\n");
            XmlSerializer xmlSerializer2 = new XmlSerializer(typeof(List<Car>));
            using (StreamWriter wr = new StreamWriter("Mascarxml.xml", false, Encoding.Default))
            {
                xmlSerializer2.Serialize(wr, mas);
            }
            List<Car> newMas;
            using (StreamReader rd = new StreamReader("Mascarxml.xml"))
            {
                newMas = (List<Car>)xmlSerializer2.Deserialize(rd);
            }

            foreach(Car car in newMas)
            {
                car.OutInformationAboutCar();
            }



            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load("Mascarxml.xml");
            XmlNodeList carsprice = xmldoc.SelectNodes("/ArrayOfCar/Car/Price");
            Console.WriteLine("Список цен автомобилей:");
            foreach (XmlNode node in carsprice)
            {
                Console.WriteLine(node.InnerText);
            }

            XmlNodeList carsvelocity = xmldoc.SelectNodes("/ArrayOfCar/Car/Velocity");
            Console.WriteLine("Список скоростей автомобилей:");
            foreach (XmlNode node in carsvelocity)
            {
                Console.WriteLine(node.InnerText);
            }







           XElement xmldoc2 = new XElement("cars",
           new XElement("car",
               new XElement("velocity", "190"),
               new XElement("model", "Scoda"),
               new XElement("price", "1500")
           ),
            new XElement("car",
               new XElement("velocity", "180"),
               new XElement("model", "Fiat"),
               new XElement("price", "1200")
           ),
            new XElement("car",
               new XElement("velocity", "220"),
               new XElement("model", "Opel"),
               new XElement("price", "2200")
           )
           );
            xmldoc2.Save("newdoc.xml");

            var cars = xmldoc2.Elements("car");

            Console.WriteLine("Все машины:");
            foreach (var car in cars)
            {
                Console.WriteLine($"Velocity: {car.Element("velocity").Value}, Model: {car.Element("model").Value}, Price: {car.Element("price").Value}");
            }

            var newcars = from car in cars
                             where (int)car.Element("velocity") < 200
                             select car;

            Console.WriteLine("\nМашины, у которых скорость меньше 200:");
            foreach (var car in newcars)
            {
                Console.WriteLine($"Velocity: {car.Element("velocity").Value}, Model: {car.Element("model").Value}, Price: {car.Element("price").Value}");
            }
        }
    }
}