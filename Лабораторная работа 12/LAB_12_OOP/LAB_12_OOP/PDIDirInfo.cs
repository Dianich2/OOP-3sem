using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_12_OOP
{
    public static class PDIDirInfo
    {
        public static void PrintInformationAboutDir(string dir)
        {
            if(dir is null)
            {
                throw new ArgumentNullException(nameof(dir));
            }
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            string buf = "";
            buf += $"\nДиректория: {dirInfo.Name}";
            buf += $"\nКоличество файлов: {dirInfo.GetFiles().Length}";
            buf += $"\nВремя создания: {dirInfo.CreationTime}";
            buf += $"\nКоличество поддиректорий: {dirInfo.GetDirectories().Length}";
            buf += $"\nСписок родительских директорий: {dirInfo.Parent.Name}";
            Console.WriteLine("Информация о директории");
            Console.WriteLine(buf);
            PDILog.WriteInformationFromOtherMethods(buf);
        }
    }
}
