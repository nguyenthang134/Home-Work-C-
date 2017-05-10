using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static ArrayList al = new ArrayList();
        static void Main(string[] args)
        {
            int choice = 0;
            while (choice != 3)
            {
                Program program = new Program();
                Console.WriteLine("------MENU------");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. List");
                Console.WriteLine("3. Quit");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        program.AddUser();
                        break;
                    case 2:
                        program.showUser();
                        break;
                    case 3:
                        break;
                }
            }
        }

        public void AddUser()
        {
            Console.WriteLine("Enter name: ");
            String name = Console.ReadLine();
            Console.WriteLine("Enter age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter phone: ");
            int phone = Convert.ToInt32(Console.ReadLine());
            User user = new User();
            user.setName(name);
            user.setAge(age);
            user.setPhone(phone);
            al.Add(user);
        }

        public void showUser()
        {
            foreach (User u in al)
            {
                Console.WriteLine("Name: " + u.name);
                Console.WriteLine("Age:" + u.age);
                Console.WriteLine("Phone: " + u.phone);
                Console.ReadKey();
            }
        }

    }

    class User
    {
        public String name;
        public int age;
        public int phone;

        public void setName(String name)
        {
            this.name = name;
        }
        public void setAge(int age)
        {
            this.age = age;
        }
        public void setPhone(int phone)
        {
            this.phone = phone;
        }
    }
}
