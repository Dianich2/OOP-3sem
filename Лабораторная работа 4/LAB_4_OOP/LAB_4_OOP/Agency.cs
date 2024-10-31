using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static LAB_4_OOP.Classes;
using static System.Collections.Specialized.BitVector32;

namespace LAB_4_OOP
{
    internal class Agency
    {
        public List<Transport> agencies = new List<Transport>();

        internal List<Transport> Agencies{
            get{ return agencies; }
            set{ agencies = value; }
        }
        public void AddTransport(Transport transport)
        {
            agencies.Add(transport);
        }
        public void RemoveTransport(Transport transport)
        {
            agencies.Remove(transport);
        }
        public void PrintTransport()
        {
            Console.WriteLine(string.Join(" ", agencies));
        }
        public void PrintPrice()
        {
            double? price = 0;
            for(int i = 0; i < agencies.Count; i++)
            {
                price += agencies[i].Price;
            }
            Console.WriteLine($"Стоимость всех транспортных средств = {price}");
        }


    }
}
