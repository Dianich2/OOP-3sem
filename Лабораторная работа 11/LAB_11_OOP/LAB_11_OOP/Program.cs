using LAB_11_OOP;
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

namespace Lab_11_OOP
{
    public class Program
    {
        public static void Main()
        {
            Train train = new Train();
            Reflector.GetAssemblyName(train);
            Reflector.CheckPublicConstructors(train);
            Console.WriteLine("Публичные методы класса");
            IEnumerable<string> methods = Reflector.GetPublicMethods(train);
            foreach (string method in methods) {
                Console.WriteLine(method);
            }
            Console.WriteLine("\nПоля и свойства класса");
            IEnumerable<string> fieldsAndProperties = Reflector.GetFieldsAndProperties(train);
            foreach (string fp in fieldsAndProperties)
            {
                Console.WriteLine(fp);
            }
            IEnumerable<string> interfaces = Reflector.GetInterfaces(train);
            if (interfaces.Count() == 0)
            {
                Console.WriteLine("\nКласс не реализует интерфейсы");
            }
            else
            {
                Console.WriteLine("\nИнтерфейсы класса");
                foreach (string i in interfaces)
                {
                    Console.WriteLine(i);
                }
            }
            IEnumerable<string> methodsWithParm = Reflector.GetMethodsByClass(train, "obj");
            if (methodsWithParm.Count() == 0)
            {
                Console.WriteLine("\nВ классе нет нужных методов");
            }
            else
            {
                Console.WriteLine("\nНужные методы");
                foreach (string i in methodsWithParm)
                {
                    Console.WriteLine(i);
                }
            }

            Train.WriteInformationAboutClass(train);
            Train newt = Reflector.Create<Train>(typeof(Train));
            Train.WriteInformationAboutClass(newt);

            ///////////////////////////////////////////////////////////////////////

            User user = new User();
            Reflector.GetAssemblyName(user);
            Reflector.CheckPublicConstructors(user);
            Console.WriteLine("Публичные методы класса");
            IEnumerable<string> methods2 = Reflector.GetPublicMethods(user);
            foreach (string method in methods2)
            {
                Console.WriteLine(method);
            }
            Console.WriteLine("\nПоля и свойства класса");
            IEnumerable<string> fieldsAndProperties2 = Reflector.GetFieldsAndProperties(user);
            foreach (string fp in fieldsAndProperties2)
            {
                Console.WriteLine(fp);
            }
            IEnumerable<string> interfaces2 = Reflector.GetInterfaces(user);
            if (interfaces.Count() == 0)
            {
                Console.WriteLine("\nКласс не реализует интерфейсы");
            }
            else
            {
                Console.WriteLine("\nИнтерфейсы класса");
                foreach (string i in interfaces2)
                {
                    Console.WriteLine(i);
                }
            }
            IEnumerable<string> methodsWithParm2 = Reflector.GetMethodsByClass(user, "obj");
            if (methodsWithParm2.Count() == 0)
            {
                Console.WriteLine("\nВ классе нет нужных методов");
            }
            else
            {
                Console.WriteLine("\nНужные методы");
                foreach (string i in methodsWithParm2)
                {
                    Console.WriteLine(i);
                }
            }

            Reflector.Invoke(user, "C:\\ФИТ\\Лабораторные работы\\3 сем\\Лабораторные работы по ООП\\Лабораторная работа 11\\LAB_11_OOP\\LAB_11_OOP\\bin\\Debug\\net8.0\\forInvoke.txt");
            user.PrintInformation();
            User newt2 = Reflector.Create<User>(typeof(User));
            newt2.PrintInformation();

            Reflector.PrintInformationToFile(newt2, "C:\\ФИТ\\Лабораторные работы\\3 сем\\Лабораторные работы по ООП\\Лабораторная работа 11\\LAB_11_OOP\\LAB_11_OOP\\bin\\Debug\\net8.0\\objToFile.txt");
        }
    }
}