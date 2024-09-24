using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static LAB_4_OOP.Classes;

namespace LAB_4_OOP
{
    internal class Classes
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

        internal class Transport : BaseTransport, ITransport
        {
            protected double? Velocity { get; set; }
            protected string? Type { get; set; }

            public Transport() {
                Velocity = 80;
                Type = null;
            }
            public Transport(double vel, string type)
            {
                Velocity = vel;
                Type = type;
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
                internal double? EnginePower { get; set; }
                internal double? EngineVolume { get; set; }
                internal double? Compression { get; set; }

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
                return ($"Тип: {this.GetType()}, скорость: {this.Velocity}\n");
            }
        }


        internal class Car : Transport
        {
            protected string? Color { get; set; }
            protected double? Price { get; set; }
            protected string? Model { get; set; }
            protected Engine? CarEngine { get; set; }

            public Car(): base()
            {
                Color = "Red";
                Price = 12000;
                Model = "Opel";
                CarEngine = new Engine();
            }
            public Car(string col, double pr, string mod, Engine car_e, double vel, string type) : base(vel, type)
            {
                Color = col;
                Price = pr;
                Model = mod;
                CarEngine = car_e;
            }

            public override bool Equals(object? obj)
            {
                if(this.GetType() == obj.GetType())
                {
                        Car buf = (Car)obj;
                        if(buf.Model == this.Model && buf.Color == this.Color && buf.Price == this.Price)
                        {
                            return true;
                        }
                    return false;
                }
                return false;
            }
            public override int GetHashCode() {
                return Math.Abs(this.Model.GetHashCode() + this.Color.GetHashCode());
            }
            public override string ToString() {
                return ($"Тип: {this.GetType()}, модель: {this.Model}, цвет: {this.Color}, цена: {this.Price}, скорость: {this.Velocity}, мощность двигателя: {this.CarEngine.EnginePower}, емкость двигателя: {this.CarEngine.EngineVolume}, сжатие: {this.CarEngine.Compression}\n");
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
            protected Engine? TrainEngine { get; set; }

            public Train(): base()
            {
                TrainNumber = "2222222222";
                Destination = "Gorki";
                RailCarCount = 12;
                CountOfSeats = 260;
                TrainEngine = new Engine();
            }
            public Train(string num, string dest, int rc, int cs, int vel, string type) : base(vel, type)
            {
                TrainNumber = num;
                Destination = dest;
                RailCarCount = rc;
                CountOfSeats = cs;
                TrainEngine = new Engine();
            }
            internal class railCar
            {
                protected string? Type { get; set; }
                protected double? PriceOfTicket { get; set; }
            }
            public override string ToString()
            {
                return ($"Номер: {this.TrainNumber}, пункт назначения: {this.Destination}, количество вагонов: {this.RailCarCount}, количество мест: {this.CountOfSeats},  мощность двигателя: {this.TrainEngine.EnginePower}, емкость двигателя: {this.TrainEngine.EngineVolume}, сжатие: {this.TrainEngine.Compression}\n");
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
                return ($"Номер: {this.TrainNumber}, пункт назначения: {this.Destination}, количество вагонов: {this.RailCarCount}, количество мест{this.CountOfSeats}, тип сервиса: {this.ServiceType}, дополнительный сервис: {this.AdditionService},  мощность двигателя: {this.TrainEngine.EnginePower}, емкость двигателя: {this.TrainEngine.EngineVolume}, сжатие: {this.TrainEngine.Compression}\n");
            }
            public void OutInformationAboutExpress()
            {
                Console.WriteLine(this.ToString());
            }
        }


    }
}
