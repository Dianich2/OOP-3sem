using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LAB_4_OOP.Classes;

namespace LAB_4_OOP
{
    internal class Printer
    {
        public void IAmPrinting(BaseTransport obj)
        {
            if(obj != null)
            {
                Console.WriteLine($"Тип объекта: {obj.GetType()}\n");
                Console.WriteLine(obj.ToString());
            }
        }
    }
}
