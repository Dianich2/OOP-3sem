using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static LAB_4_OOP.Classes;

namespace LAB_4_OOP
{
    internal partial class Classes
    {
        internal interface ITransport
        {
            void Start();
            void Stop();
        }

        internal abstract class BaseTransport{
            public abstract void Start();
            public abstract void Stop();
        }

        internal partial class Transport : BaseTransport, ITransport
        {
            private double? price;
            public double? Price { get { return price; }
                set { 
                  if(value < 0)
                    {
                        throw new NegativePriceException(value, "Цена не может быть отрицательной");
                    }
                  price = value;
                } 
            }
            private double? velocity;
            public double? Velocity {
                get { return velocity; }
                set
                {
                    if (value < 0)
                    {
                        throw new NegativeVelocityException(value, "Модуль скорости не может быть отрицательным");
                    }
                    if (value > 250)
                    {
                        throw new ArgumentException("Превышено допустимое значение скорости");
                    }
                    velocity = value;
                }
            }
            public string type;
            public string? Type {
                get { return type; }
                set
                {
                    if (value == null)
                    {
                        throw new UndeclaredPropertyException(value, "Неинициализированное поле");
                    }
                    type = value;
                }
            }
            public Engine? engine { get; set; }

            public Transport() {
                Velocity = 80;
                Type = "base";
                Price = 2000;
                engine = new Engine();
            }
            public Transport(double vel, string type, double price, Engine engin)
            {
                Velocity = vel;
                Type = type;
                Price = price;
                engine = engin;
            }
            public override void Start()
            {
                Console.WriteLine("Start from abstract class");
            }

            public override void Stop()
            {
                Console.WriteLine("Stop from abstract class");
            }

            void ITransport.Start()
            {
                Console.WriteLine("Start from interface");
            }
            void ITransport.Stop()
            {
                Console.WriteLine("Stop from interface");
            }

            internal class Engine
            {
                private double? enginePower;
                public double? EnginePower { get { return enginePower; } 
                    set { 
                        Debug.Assert(value > 0, "Мощность двигателя должна быть больше нуля(вызван Assert)");
                        if (value <= 0)
                        {
                            throw new Exception("Мощность двигателя должна быть больше нуля");
                        }
                        enginePower = value;
                    } 
                }
                public double? EngineVolume { get; set; }
                public double? Compression { get; set; }

                public Engine() {
                    EnginePower = 3000;
                    EngineVolume = 8;
                    Compression = 10;
                }
                public Engine(double pow, double vol, double comp)
                {
                    EnginePower = pow;
                    EngineVolume = vol;
                    Compression = comp;
                }

                public override string ToString()
                {
                    return ($"Тип: {this.GetType()}, мощность: {this.EnginePower}, емкость: {this.EngineVolume}, сжатие: {this.Compression}\n");
                }
                public void OutInformationAboutEngine()
                {
                    Console.WriteLine(this.ToString());
                }
            }
            public void OutInformationAboutTransport()
            {
                Console.WriteLine(this.ToString());
            }
            public override string ToString()
            {
                return ($"Тип: {this.GetType()}, скорость: {this.Velocity}, цена: {this.Price}, мощность двигателя: {this.engine.EngineVolume}, емкость двигателя: {this.engine.EngineVolume}, сжатие: {this.engine.Compression}\n");
            }
        }
        
        internal enum TransportColor
        {
            Red,
            Green,
            Blue,
            White,
            Brown,
            Black,
            Yellow,
            Grey,
            Orange
        }

        internal struct CarSeats
        {
            public string? Material { get; set; }
            public TransportColor? Color { get; set; }
            public void PrintInformation()
            {
                Console.WriteLine($"Материал: {Material}, Цвет: {Color}");
            }
            public CarSeats() {
                Material = "Винил";
                Color = TransportColor.Black;
            }
            public CarSeats(string mat, TransportColor color)
            {
                Material = mat;
                Color = color;
            }
        }

        internal partial class Car : Transport
        {
            public override bool Equals(object? obj)
            {
                if (this.GetType() == obj.GetType())
                {
                    Car buf = (Car)obj;
                    if (buf.Model == this.Model && buf.Color == this.Color)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            public override int GetHashCode()
            {
                return Math.Abs(this.Model.GetHashCode() + this.Color.GetHashCode());
            }
            public override string ToString()
            {
                return ($"Тип: {this.GetType()}, модель: {this.Model}, цвет: {this.Color}, цена: {this.Price}, скорость: {this.Velocity}, мощность двигателя: {this.engine.EnginePower}, емкость двигателя: {this.engine.EngineVolume}, сжатие: {this.engine.Compression}\n");
            }

            public void OutInformationAboutCar()
            {
                Console.WriteLine(this.ToString());
            }
        }

        internal class Train : Transport
        { 
            protected string? TrainNumber { get; set; }
            protected string? Destination { get; set; }
            protected int? RailCarCount { get; set; }
            protected int? CountOfSeats { get; set; }

            public Train(): base()
            {
                TrainNumber = "2222222222";
                Destination = "Gorki";
                RailCarCount = 12;
                CountOfSeats = 260;
            }
            public Train(string num, string dest, int rc, int cs, int vel, string type, double price, Engine t_e) : base(vel, type, price, t_e)
            {
                TrainNumber = num;
                Destination = dest;
                RailCarCount = rc;
                CountOfSeats = cs;
            }
            internal class railCar
            {
                protected string? Type { get; set; }
                protected double? PriceOfTicket { get; set; }
            }
            public override string ToString()
            {
                return ($"Номер: {this.TrainNumber}, пункт назначения: {this.Destination}, количество вагонов: {this.RailCarCount}, количество мест: {this.CountOfSeats},  мощность двигателя: {this.engine.EnginePower}, емкость двигателя: {this.engine.EngineVolume}, сжатие: {this.engine.Compression}\n");
            }
            public void OutInformationAboutTrain()
            {
                Console.WriteLine(this.ToString());
            }
        }

        internal sealed class Express : Train
        {
            protected string? ServiceType { get; set; }
            protected string? AdditionService { get; set; }

            public Express() : base()
            {
                ServiceType = "комфортный";
                AdditionService = "-";
            }

            public override string ToString()
            {
                return ($"Номер: {this.TrainNumber}, пункт назначения: {this.Destination}, количество вагонов: {this.RailCarCount}, количество мест{this.CountOfSeats}, тип сервиса: {this.ServiceType}, дополнительный сервис: {this.AdditionService},  мощность двигателя: {this.engine.EnginePower}, емкость двигателя: {this.engine.EngineVolume}, сжатие: {this.engine.Compression}\n");
            }
            public void OutInformationAboutExpress()
            {
                Console.WriteLine(this.ToString());
            }
        }


    }
}
