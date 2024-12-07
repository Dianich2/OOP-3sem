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

namespace LAB_12_OOP
{
    public class Program
    {
        public static void Main()
        {
            PDILog.WriteInformationAboutLog();
            PDIDiskInfo.PrintInformationAboutComputerDisks();
            Console.WriteLine("В определенное время");
            Console.WriteLine(PDILog.SearchInformationInLogByDate(new DateTime(2024, 11, 2, 22, 44, 11)));
            Console.WriteLine("\nЗа период");
            Console.WriteLine(PDILog.SearchInformationInLogForPeriod(new DateTime(2024, 11, 2, 22, 42, 17), new DateTime(2024, 11, 2, 22, 45, 17)));
            PDIFileInfo.PrintInformationAboutFile("PDIlog.txt");
            PDIDirInfo.PrintInformationAboutDir("C:\\ФИТ\\Лабораторные работы\\3 сем\\Лабораторные работы по ООП\\Лабораторная работа 12\\LAB_12_OOP\\LAB_12_OOP\\bin\\Debug\\net8.0");
            PDIFileManager.SaveInformationAboutDisk("C:\\");
            PDIFileManager.CopyAndDeleteInspFile();
            PDIFileManager.CreateDirWithFilesAndMoveToPDIInspect("C:\\ФИТ\\Лабораторные работы\\3 сем\\Лабораторные работы по ООП\\Лабораторная работа 12\\LAB_12_OOP\\LAB_12_OOP\\bin\\Debug\\net8.0", "*.txt");
            PDIFileManager.CreateArchieve();
        }
    }
}