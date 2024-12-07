using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_12_OOP
{
    public static class PDIFileManager
    {
        public static void SaveInformationAboutDisk(string disk)
        {
            DriveInfo drive = new DriveInfo(disk);
            string[] files = Directory.GetFiles(disk);
            string[] directories = Directory.GetDirectories(disk);
            string buf = "\nФайлы на диске:\n";
            foreach (string file in files) {
                buf += file + '\n';
            }
            buf += "\nДиректории на диске:\n";
            foreach (string dir in directories)
            {
                buf += dir + '\n';
            }

            DirectoryInfo insp = new DirectoryInfo("PDIInspect");
            if (!insp.Exists)
            {
                insp.Create();
            }
            FileInfo inspfile = new FileInfo(insp.FullName + "\\PDIdirinfo.txt");
            using (StreamWriter wr = new StreamWriter(inspfile.FullName, false, Encoding.Default))
            {
                wr.WriteLine(buf);
            }
            PDILog.WriteInformationFromOtherMethods(buf);
        }

        public static void CopyAndDeleteInspFile()
        {
            string path = Path.GetFullPath("PDIInspect");
            FileInfo newfile = new FileInfo(path + "\\newdirinfo.txt");
            System.IO.File.Copy(path + "\\PDIdirinfo.txt", newfile.FullName, true);
            System.IO.File.Delete(path + "\\PDIdirinfo.txt");
        }

        public static void CreateDirWithFilesAndMoveToPDIInspect(string pathdir, string ext)
        {
            DirectoryInfo dir = new DirectoryInfo("PDIFiles");
            if (!dir.Exists)
            {
                dir.Create();
            }
            else
            {
                Directory.Delete(dir.FullName, true);
                dir.Create();
            }
            DirectoryInfo sourcedir = new DirectoryInfo(pathdir);
            FileInfo[] files = sourcedir.GetFiles(ext);
            foreach (FileInfo file in files) {
                string filepath = Path.Combine(dir.FullName, file.Name);
                System.IO.File.Copy(file.FullName, filepath, true);
            }
            if (new DirectoryInfo("C:\\ФИТ\\Лабораторные работы\\3 сем\\Лабораторные работы по ООП\\Лабораторная работа 12\\LAB_12_OOP\\LAB_12_OOP\\bin\\Debug\\net8.0\\PDIInspect\\PDIFiles").Exists)
            {
                Directory.Delete("C:\\ФИТ\\Лабораторные работы\\3 сем\\Лабораторные работы по ООП\\Лабораторная работа 12\\LAB_12_OOP\\LAB_12_OOP\\bin\\Debug\\net8.0\\PDIInspect\\PDIFiles", true);
            }
            Directory.Move(dir.FullName, "C:\\ФИТ\\Лабораторные работы\\3 сем\\Лабораторные работы по ООП\\Лабораторная работа 12\\LAB_12_OOP\\LAB_12_OOP\\bin\\Debug\\net8.0\\PDIInspect\\" + "PDIFiles");
        }

        public static void CreateArchieve()
        {
            if(new FileInfo("C:\\ФИТ\\Лабораторные работы\\3 сем\\Лабораторные работы по ООП\\Лабораторная работа 12\\LAB_12_OOP\\LAB_12_OOP\\bin\\Debug\\net8.0\\PDIInspect\\PDIFiles.zip").Exists)
            {
                File.Delete("C:\\ФИТ\\Лабораторные работы\\3 сем\\Лабораторные работы по ООП\\Лабораторная работа 12\\LAB_12_OOP\\LAB_12_OOP\\bin\\Debug\\net8.0\\PDIInspect\\PDIFiles.zip");
            }
            ZipFile.CreateFromDirectory("C:\\ФИТ\\Лабораторные работы\\3 сем\\Лабораторные работы по ООП\\Лабораторная работа 12\\LAB_12_OOP\\LAB_12_OOP\\bin\\Debug\\net8.0\\PDIInspect\\PDIFiles", "C:\\ФИТ\\Лабораторные работы\\3 сем\\Лабораторные работы по ООП\\Лабораторная работа 12\\LAB_12_OOP\\LAB_12_OOP\\bin\\Debug\\net8.0\\PDIInspect\\PDIFiles.zip");
        }
    }
}
