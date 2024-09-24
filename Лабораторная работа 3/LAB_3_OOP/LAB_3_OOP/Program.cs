using LAB_3_OOP;
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

namespace Lab_3_OOP
{
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            MyList<int> myList = new MyList<int>();
            myList = myList + 5;
            myList = myList + 8;
            Console.WriteLine("Элементы myList");
            myList.output();
            bool check = ((bool)myList);
            Console.WriteLine($"myList упорядочен? {check}");
            MyList<int> myList2 = new MyList<int>();
            myList2 = myList2 + 2;
            myList2 = myList2 + 8;
            Console.WriteLine($"myList == myList2? {(myList2 == myList)}");
            Console.WriteLine($"myList != myList2? {(myList2 != myList)}");

            myList[0] = 10;
            Console.WriteLine("Элементы myList");
            myList.output();

            myList--;
            Console.WriteLine("Элементы myList");
            myList.output();

            myList.insert(0, 15);
            myList.insert(2, 19);
            Console.WriteLine("Элементы myList");
            myList.output();

            myList.remove(1);
            Console.WriteLine("Элементы myList");
            myList.output();

            myList.add(20);
            Console.WriteLine("Элементы myList");
            myList.output();

            myList.pop();
            Console.WriteLine("Элементы myList");
            myList.output();

            myList = myList + 50;
            myList = myList + 150;
            myList = myList + 250;

            Console.WriteLine("Элементы myList");
            myList.output();

            Console.WriteLine($"Максимальная текущая вместимость myList = {myList.getCapacity()}");

            Console.WriteLine($"Текущая вместимость myList = {myList.size}");

            myList.clearMyList();
            Console.WriteLine($"myList пустой? {myList.isEmpty()}");


            var productionList = new MyList<string>.Production();
            productionList.Organization = "NewCorporation";
            Console.WriteLine(productionList.Organization);

            var developer = new MyList<string>.Developer("Ivanov", "Ivan", "Ivanovich", "2");

            myList.add(200);
            myList.add(500);
            myList.insert(1, 100);
            Console.WriteLine("Элементы myList");
            myList.output();

            Console.WriteLine($"Сумма элементов myList = {StatisticOperation.getSum(myList)}");

            Console.WriteLine($"Разность максимального и минимального элементов в myList = {StatisticOperation.getDistance(myList)}");

            Console.WriteLine($"Текущая вместимость myList = {StatisticOperation.GetSize(myList)}");

            Console.WriteLine($"myList содержит null = {StatisticOperation.ConstainsNull(myList)}");

            string s = "C# мой любимый язык";
            Console.WriteLine($"Количество слов в строке s = {StatisticOperation.GetCountOfWords(s)}");
        }
    }
}