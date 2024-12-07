using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_12_OOP
{
    public static class PDIFileInfo
    {
        public static void PrintInformationAboutFile(string file)
        {
            if(file is null)
            {
                throw new ArgumentNullException(nameof(file));
            }
            FileInfo fileInfo = new FileInfo(file);
            string buf = "";
            buf += "\nПуть: " + fileInfo.DirectoryName;
            buf += "\nПолное имя файла: " + fileInfo.Name;
            buf += "\nРазмер: " + fileInfo.Length;
            buf += "\nРасширение: " + fileInfo.Extension;
            buf += "\nДата создания: " + fileInfo.CreationTime;
            buf += "\nДата изменения: " + fileInfo.LastWriteTime + '\n';
            Console.WriteLine("Информация о файле");
            Console.WriteLine(buf);
            PDILog.WriteInformationFromOtherMethods(buf);
        }
    }
}
