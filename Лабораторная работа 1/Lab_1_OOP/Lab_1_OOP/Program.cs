using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Lab_1_OOP
{
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-US");

            // exercise 1a
            Console.Write("bool: ");
            bool t = Convert.ToBoolean(Console.ReadLine()); // true or false
            Console.WriteLine(t);
            Console.Write("byte: ");
            byte byt = Convert.ToByte(Console.ReadLine()); //  0 ... 255
            Console.WriteLine(byt);
            Console.Write("sbyte: ");
            sbyte sbyt = Convert.ToSByte(Console.ReadLine()); //  -128 ... 127
            Console.WriteLine(sbyt);
            Console.Write("char: ");
            char cha = Convert.ToChar(Console.ReadLine()); // один символ
            Console.WriteLine(cha);
            Console.Write("decimal: ");
            decimal d = Convert.ToDecimal(Console.ReadLine()); // вещественные числа(16 байтов)
            Console.WriteLine(d);
            Console.Write("double: ");
            double doubl = Convert.ToDouble(Console.ReadLine()); // вещественные числа(8 байтов)
            Console.WriteLine(doubl);
            Console.Write("float: ");
            float f = Convert.ToSingle(Console.ReadLine());// вещественные числа(4 байта)
            Console.WriteLine(f);
            Console.Write("int: ");
            int i = Convert.ToInt32(Console.ReadLine()); // целое число (4 байта)
            Console.WriteLine(i);
            Console.Write("uint: ");
            uint ui = Convert.ToUInt32(Console.ReadLine()); // беззнаковый целый тип (4 байта)
            Console.WriteLine(ui);
            Console.Write("nint: ");
            nint nin = nint.Parse(Console.ReadLine()); // типо указателя или новый тип int, который занимает 4 байта на х32 и 8 байт на х64
            Console.WriteLine(nin);
            Console.Write("nuint: ");
            nuint nuin = nuint.Parse(Console.ReadLine()); // беззнаковый типо указателя или новый тип int, который занимает 4 байта на х32 и 8 байт на х64
            Console.WriteLine(nuin);
            Console.Write("long: ");
            long l = Convert.ToInt64(Console.ReadLine()); // целый тип (8 байт)
            Console.WriteLine(l);
            Console.Write("ulong: ");
            ulong ul = Convert.ToUInt64(Console.ReadLine()); // беззнаковый целый тип (8 байт)
            Console.WriteLine(ul);
            Console.Write("short: ");
            short shor = Convert.ToInt16(Console.ReadLine()); // целый тип (2 байта)
            Console.WriteLine(shor);
            Console.Write("ushort: ");
            ushort ushor = Convert.ToUInt16(Console.ReadLine()); // беззнаковый целый тип (2 байта)
            Console.WriteLine(shor);
            Console.Write("string: ");
            string str = Console.ReadLine(); // строковый тип
            Console.WriteLine(str);

            // exercise 1b

            //неявное преобразование 
            byte s = 5;
            short s1 = s;
            int s2 = s1;
            long s3 = s2;
            BigInteger s4 = s3;
            float f1 = 1.25f;
            double f2 = f1;

            //явное преобразование
            decimal dec = 1.456M;
            double d2 = (double)dec;
            float d3 = (float)d2;
            int int3 = (int)d3;
            short short3 = (short)int3;
            byte byte4 = (byte)short3;

            // exercise 1c
            int basic = 2;
            object packedint = basic; // это будет упаковка

            int unpackedint = (int)packedint; // это будет распаковка

            // exercise 1d
            var boolean = true;
            Console.WriteLine("Тип переменной booolean = " + boolean.GetType());

            //exercise 1e
            int? nulint = null; // Nullable
            Console.Write("Введите значение для переменной nulint ");
            nulint = Convert.ToInt32(Console.ReadLine());

            //exercise 1f

            var a = 5;
            //a = "Error";

            //exercise 2a

            string first = "Hello,";
            string second = "World!";
            Console.WriteLine(first.CompareTo(second));

            //exercise 2b

            string fir = "Hello,";
            string sec = "my friend!\n";
            string thi = fir + sec; // сцепление
            Console.WriteLine(thi);
            thi = string.Copy(sec); // копирование
            Console.WriteLine(thi);
            thi = fir.Substring(0, 2); // выделение подстроки
            Console.WriteLine(thi);
            string words = "My name is Diana";
            string[] splitwords = words.Split(' '); // разделение строки на слова
            foreach (string word in splitwords)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();
            thi = thi.Insert(1, sec.Substring(0, 2)); // вставка подстроки
            Console.WriteLine(thi);
            thi = thi.Remove(thi.IndexOf(sec.Substring(0,2)), 2); // удаление подстроки
            Console.WriteLine(thi);
            double p = 1.25689;
            Console.WriteLine($"Проверка интерполирования {"строк"}.\n Вывод числа с точностью 2 знака после запятой {p:F2}"); // интерполирование

            //exercise 2c

            string empt = "";
            string nul = null;
            if (string.IsNullOrEmpty(empt))
            {
                Console.WriteLine("Строка empt пустая или null");
            }
            if (string.IsNullOrEmpty(nul))
            {
                Console.WriteLine("Строка nul пустая или null");
            }

            //exercise 2d
            StringBuilder strbuild = new StringBuilder();
            strbuild.Append('a');
            Console.WriteLine(strbuild.ToString());
            strbuild.Insert(0, 'g');
            Console.WriteLine(strbuild.ToString());
            strbuild.Insert(strbuild.Length, 'g');
            Console.WriteLine(strbuild.ToString());
            strbuild.Remove(0, 2);
            Console.WriteLine(strbuild.ToString());

            //exercise 3a

            int[,] mas = { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 }, { 9, 10} };
            for(int j = 0; j < mas.GetLength(0); j++)
            {
                for(int k = 0; k < mas.GetLength(1); k++)
                {
                    Console.Write($"{mas[j,k]} ");
                }
                Console.WriteLine();
            }

            //exercise 3b

            string[] masstr = { "C#", "C++", "Python", "JS" };
            for(int j = 0; j < masstr.Length; j++)
            {
                Console.Write(masstr[j] + " ");
            }
            Console.WriteLine("Введите позицию элемента в массиве, который хотите поменять");
            int pos = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.WriteLine("Введите новое значение элемента");
            masstr[pos] = Console.ReadLine();
            for (int j = 0; j < masstr.Length; j++)
            {
                Console.Write(masstr[j] + " ");
            }

            //exercise 3c

            double[][] stup = new double[3][];
            Console.WriteLine("Введите 2 вещественных числа через пробел для первой строки массива ");
            stup[0] = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            Console.WriteLine("Введите 3 вещественных числа через пробел для второй строки массива ");
            stup[1] = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            Console.WriteLine("Введите 4 вещественных числа через пробел для третьей строки массива ");
            stup[2] = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            for(int j = 0; j < 3; j++)
            {
                for(int k = 0; k < stup[j].Length; k++)
                {
                    Console.Write($"{stup[j][k]} ");
                }
                Console.WriteLine();
            }

            //exercise 3d

            var r = new int[]{ 1, 2, 3 };
            var str1 = "C#";

            //exercise 4a, b, c, d

            (int, string, char, string, ulong) tup = (2, "Diana", '7', "ПИ", 2024);
            Console.WriteLine(tup);
            Console.WriteLine(tup.Item2);
            Console.WriteLine(tup.Item3);

            (int, double, int) tup2 = (2, 2.5, 10);
            (int digit1, double digit2, int digit3) = tup2; // 1 способ
            var (digi1, digi2, digi3) = tup2; // 2 способ

            int d1; // 3 способ
            double d4;
            int d5;
            (d1, d4, d5) = tup2;

            (int h, _, int n) = tup2; // использование _ для пропуска какого-то элемента, если он нам не нужен, при взятии элементов из кортежа

            (int, double, int) tup3 = (6, 2.56, 16);
            if (tup3 == tup2)
            {
                Console.WriteLine("Кортежи равны");
            }
            else
            {
                Console.WriteLine("Кортежи разные");
            }

            //exercise 5

            static (int, int, int, char) tups(int[] b, string s)
            {
                (int, int, int, char) func = (b.Max(), b.Min(), b.Sum(), s[0]);
                return func;
            }

            int[] buf = new int[] { 1, 2, 3, 4 };
            string buf2 = "Diana";

            (int, int, int, char) result = tups(buf, buf2);

            Console.WriteLine(result);

            //exercise 6

            static void retint()
            {
                checked
                {
                    int v = int.MaxValue;
                    Console.WriteLine(v);
                }
            }

            static void retint2()
            {
                unchecked
                {
                    int v = int.MaxValue;
                    Console.WriteLine(v);
                }
            }

            retint();
            retint2();
        }
    }
}