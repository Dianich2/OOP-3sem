using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_8_OOP
{
    public class User
    {
        public delegate void UpgradeUser(User u, string n, string s, string p);
        public delegate void UserWork();
        public event UpgradeUser upgrade;
        public event UserWork work;

        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Password { get; set; }
        public User()
        {
            this.Name = "Петя";
            this.Surname = "Петров";
            this.Password = "1212";
        }
        public void PrintInformation()
        {
            Console.WriteLine($"Имя: {this.Name}, фамилия: {this.Surname}, пароль: {this.Password}\n");
        }

        public void Upgrade(string na, string sur, string pas)
        {
            Console.WriteLine("Обновление пользователя \n");
            upgrade.Invoke(this, na, sur, pas);
        }

        public void Work()
        {
            Console.WriteLine("User work");
            work.Invoke();
        }
    }
}
