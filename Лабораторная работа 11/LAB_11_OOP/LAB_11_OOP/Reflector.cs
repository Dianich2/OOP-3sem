using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LAB_11_OOP
{
    internal static class Reflector
    {
        public static void GetAssemblyName(object obj)
        {
            Type objtype = obj.GetType();
            Assembly assembly = objtype.Assembly;
            Console.WriteLine($"Имя сборки: {assembly.GetName().Name}");
        }

        public static void CheckPublicConstructors(object obj)
        {
            Type objtype = obj.GetType();
            ConstructorInfo[] constructors = objtype.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
            if(constructors.Length > 0)
            {
                Console.WriteLine("В классе есть публичные конструкторы");
            }
            else
            {
                Console.WriteLine("В классе нет публичных конструкторов");
            }
        }
        public static IEnumerable<string> GetPublicMethods(object obj)
        {
            Type objtype = obj.GetType();
            MethodInfo[] methods = objtype.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            IEnumerable<string> result = methods.Select(m => m.Name);
            return result;
        }
        public static IEnumerable<string> GetFieldsAndProperties(object obj)
        {
            Type objtype = obj.GetType();
            PropertyInfo[] properties = objtype.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            FieldInfo[] fields = objtype.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            IEnumerable<string> result = properties.Select(m => m.Name).Concat(fields.Select(f => f.Name));
            return result;
        }
        public static IEnumerable<string> GetInterfaces(object obj)
        {
            Type objtype = obj.GetType();
            var interfaces = objtype.GetInterfaces();
            IEnumerable<string> result = interfaces.Select(m => m.Name);
            return result;
        }
        public static IEnumerable<string> GetMethodsByClass(object obj, string parm)
        {
            Type objtype = obj.GetType();
            MethodInfo[] methods = objtype.GetMethods();
            IEnumerable<string> result = methods.Where(m => m.GetParameters().Any(s => (s.Name == parm))).Select(m => m.Name);
            return result;
        }
        private static object GenerateValueForType(Type type)
        {
            if (type == typeof(int)) return 222;
            if (type == typeof(string)) return "Иванов";
            if (type == typeof(double)) return 2.2;
            if (type == typeof(bool)) return true;

            if (type.IsClass)
            {
                return Activator.CreateInstance(type);
            }
            throw new Exception("Нельзя создать экземпляр данного типа");
        }
        public static object? Invoke(object obj, string path)
        {
            Type objtype = obj.GetType();
            string[] strings = File.ReadAllLines(path);
            string[] parms = strings.Skip(1).ToArray();
            MethodInfo? method = objtype.GetMethod(strings[0]);
            var args = method.GetParameters()
            .Select((param, index) => GenerateValueForType(param.ParameterType))
            .ToArray();

            return method?.Invoke(obj, args);
        }
        public static T Create<T>(Type t)
        {
            try
            {
                object obj = Activator.CreateInstance(t);
                return (T)obj;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return default(T);
        }

        public static void PrintInformationToFile(object obj, string filePath)
        {
            Type objtype = obj.GetType();
            using (StreamWriter wr = new StreamWriter(filePath))
            {
                wr.WriteLine($"Объект: {obj.ToString()}");
                wr.WriteLine($"\nСборки: {objtype.Assembly}");
                wr.WriteLine($"\nКонструкторы: ");
                foreach (var item in objtype.GetConstructors(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
                {
                    wr.WriteLine(item);
                }
                wr.WriteLine($"\nМетоды: ");
                foreach (var item in objtype.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
                {
                    wr.WriteLine(item);
                }
                wr.WriteLine($"\nПоля: ");
                foreach (var item in objtype.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
                {
                    wr.WriteLine(item);
                }
                wr.WriteLine($"\nСвойства: ");
                foreach (var item in objtype.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
                {
                    wr.WriteLine(item);
                }
                wr.WriteLine($"\nИнтерфейсы: ");
                foreach (var item in objtype.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
                {
                    wr.WriteLine(item);
                }
                wr.WriteLine("\n");
            }
        }
    }
}
