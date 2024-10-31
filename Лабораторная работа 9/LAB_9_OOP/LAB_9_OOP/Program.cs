using LAB_9_OOP;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Lab_9_OOP
{
    public class Program
    {
        public static void Main()
        {
            MyCollection myCollection = new MyCollection();
            myCollection.AddFigure(new GeometryFigure("2D", "Квадрат", new List<int>() { 4, 4, 4, 4 }));
            myCollection.AddFigure(new GeometryFigure("2D", "круг", null, 10));
            myCollection.AddFigure(new GeometryFigure("3D", "пирамида", new List<int>() { 4, 4, 4, 4, 4, 4}));

            GeometryFigure f = new GeometryFigure("2D", "круг", null, 10);

            myCollection.OutputCollection();

            Console.WriteLine(myCollection.Contains(f));

            Console.WriteLine(myCollection.GetCount());

            myCollection.RemoveFigureAt(2);

            myCollection.OutputCollection();

            /////////////////////////////////////////////////////////////////////
            
            Stack<int> mystack = new Stack<int>();
            mystack.Push(1);
            mystack.Push(2);
            mystack.Push(3);
            mystack.Push(4);
            mystack.Push(5);
            mystack.Push(6);
            foreach (int i in mystack)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine(); 
            

            for(int i = 0; i < 3; i++)
            {
                mystack.Pop();
            }
            foreach (int i in mystack)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            mystack.Push(7);
            mystack.Push(8);
            mystack.Push(9);
            foreach (int i in mystack)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            Queue<int> myqueue = new Queue<int>(mystack);
            foreach (int i in myqueue)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            if (myqueue.Contains(9))
            {
                Console.WriteLine("Элемент найден");
            }
            else
            {
                Console.WriteLine("Элемент не найден");
            }

            static void change(object sender, NotifyCollectionChangedEventArgs e)
            {
                Console.WriteLine("Коллекция изменилась");
            }

            ObservableCollection<GeometryFigure> newcollection = new ObservableCollection<GeometryFigure>();
            newcollection.CollectionChanged += change;

            newcollection.Add(f);
            newcollection.Remove(f);
        }
    }
}