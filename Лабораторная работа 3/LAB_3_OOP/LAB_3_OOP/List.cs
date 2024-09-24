using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LAB_3_OOP
{
    internal class MyList<T>  where T : IComparable<T>
    {
        int Capacity{ get; set; }
        public T[] mas;
        public int size;

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= size)
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }
                return mas[index];
            }
            set
            {
                if (index < 0 || index >= size)
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }
                mas[index] = value;
            }
        }

        public MyList(int s)
        {
            Capacity = s;
            mas = new T[Capacity];
            size = 0;
        }

        public MyList()
        {
            Capacity = 1;
            mas = new T[Capacity];
            size = 0;
        }

        public void add(T item) 
        { 
            if(size == Capacity)
            {
                Array.Resize(ref mas, Capacity * 2);
                Capacity *= 2;
            }
            mas[size] = item;
            size++;
        }

        public void pop() 
        {
            if(size == 0)
            {
                throw new InvalidOperationException();
            }
            size--;
        }

        public int getCapacity() 
        {
            return Capacity;
        }

        public void insert(int pos, T item)
        {
            if (pos < 0 || pos > size)
            {
                throw new ArgumentOutOfRangeException(nameof(pos), "Position is out of range.");
            }
            if (size == Capacity)
            {
                Capacity = Capacity == 0 ? 1 : Capacity * 2; 
                Array.Resize(ref mas, Capacity);
            }
            for (int i = size; i > pos; i--)
            {
                mas[i] = mas[i - 1];
            }
            mas[pos] = item; 
            size++; 
        }
        public void remove(int pos) 
        {
            if (pos < 0 || pos > size || size == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pos), "Position is out of range.");
            }
            for (int i = pos; i < size - 1; i++)
            {
                mas[i] = mas[i + 1];
            }
            size--;
        }

        public void clearMyList()
        {
            size = 0;
        }

        public bool isEmpty()
        {
            return size == 0;
        }

        public string join(char del)
        {
            string buf = "";
            for(int i = 0; i < this.size - 1; i++)
            {
                buf += this[i];
                buf += del;
            }
            buf += this[size - 1];
            return buf;
        }

        public void output()
        {
            Console.WriteLine(this.join(' '));
        }

        public static MyList<T> operator +(MyList<T> l, T value)
        {
           l.add(value);
           return l;
        }
        public static MyList<T> operator --(MyList<T> l)
        {
            l.pop();
            return l;
        }

        public override bool Equals(object? obj)
        {
            if (obj is MyList<T> other)
            {
                if (this.size == other.size)
                {
                    for (int i = 0; i < this.size; i++)
                    {
                        if (!this[i].Equals(other[i]))
                        {
                            return false;
                        }
                    }
                    return true;
                }
                return false;
            }
            return false;
        }

        public static bool operator ==(MyList<T> l, MyList<T> l2)
        {
            if (l.size == l2.size)
            {
                for (int i = 0; i < l.size; i++)
                {
                    if (!l[i].Equals(l2[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public static bool operator !=(MyList<T> l, MyList<T> l2)
        {
            return !(l == l2);
        }

        public static explicit operator bool(MyList<T> l)
        {
            if(l.size == 0)
            {
                return true;
            }

            for (int i = 0; i < l.size - 1; i++)
            {
                if (l[i].CompareTo(l[i + 1]) > 0) 
                {
                    return false; 
                }
            }
            return true;
        }


        public class Production
        {
            private int ID;
            public string? Organization { get; set; }

            public Production()
            {
                ID = GetHashCode();
            }
            public Production(string name)
            {
                ID = GetHashCode();
                Organization = name;
            }
        }

        public class Developer
        {
            public string? Name { get; set; }
            public string? Surname { get; set; }
            public string? Patronimic { get; set; }
            private int ID;
            public string? Department;
            public Developer()
            {
                ID = GetHashCode();
            }

            public Developer(string surname, string name, string patronimic, string department) { 
                ID = GetHashCode();
                Name = name;
                Surname = surname;
                Patronimic = patronimic;
                Department = department;
            }

        }
    }

    internal static class StatisticOperation
    {
        public static int getSum(MyList<int> l)
        {
            int sum = 0;
            for(int i = 0; i < l.size; i++)


            {
                sum += l[i];
            }
            return sum;
        }

        public static int getDistance(MyList<int> l)
        {
            if(l.size == 0)
            {
                throw new IndexOutOfRangeException();
            }
            int max = l[0];
            int min = l[0];
            for (int i = 0; i < l.size; i++)
            {
                if (l[i] > max)
                {
                    max = l[i];
                }
                if (l[i] < min)
                {
                    min = l[i];
                }
            }
            return max - min;
        }

        public static int GetSize<T>(MyList<T> l) where T : IComparable<T>
        {
            return l.size;
        }

        public static int GetCountOfWords(this string str)
        {
            return str.Split(' ').Length;
        }

        public static bool ConstainsNull<T>(this MyList<T> l) where T : IComparable<T>
        {
            for(int i = 0; i < l.size; i++)
            {
                if (l[i] == null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
