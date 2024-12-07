using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_12_OOP
{
    public static class PDIDiskInfo
    {
        public static void PrintInformationAboutComputerDisks()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            string buf = "";
            foreach (DriveInfo drive in drives) {
                buf += "\nИмя диска: " + drive.Name + '\n';
                buf += "Объем: " + drive.TotalSize + '\n';
                buf += "Доступный объем: " + drive.AvailableFreeSpace + '\n';
                buf += "Метка тома: " + drive.VolumeLabel + '\n';
                buf += "Файловая система: " + drive.DriveFormat + '\n';
                Console.WriteLine("Информация о диске");
                Console.WriteLine(buf);
            }
            PDILog.WriteInformationFromOtherMethods(buf);
        }
    }
}
