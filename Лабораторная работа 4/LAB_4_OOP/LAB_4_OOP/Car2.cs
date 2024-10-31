using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_4_OOP
{
    internal partial class Classes
    {
        internal partial class Car : Transport
        {
            public string? Color { get; set; }
            public string? Model { get; set; }
            public CarSeats Seats;

            public Car() : base()
            {
                Color = "Red";
                Model = "Opel";
                Seats = new CarSeats();
                this.engine = new Engine(1000, 10, 100);
            }
            public Car(string col, double pr, string mod, Engine car_e, CarSeats seat, double vel, string type) : base(vel, type, pr, car_e)
            {
                Color = col;
                Model = mod;
                Seats = seat;
            }
        }
    }
    
}
