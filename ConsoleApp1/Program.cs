using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleApp1
{
    class Program
    {
        private MySqlDataReader reader;
        private MySqlConnection connection;
        private MySqlCommand cmd;
        private string server;
        private string database;
        private string uid;
        private string password;

        public void Initialize()
        {
            server = "localhost";
            database = "manger";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

      

        public void Menu()
        {            
            
            User user = new User();
            int choice = 0;
            while (choice != 5)
            {

                Console.WriteLine("------MENU------");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. List");
                Console.WriteLine("3. Delete");
                Console.WriteLine("4. Edit");
                Console.WriteLine("5. Quit");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        //program.AddUser();
                        Insert(user);
                        break;
                    case 2:
                        //program.showUser();
                        List(user);
                        break;
                    case 3:
                        Delete();
                        break;
                    case 4:
                        Edit(user);
                        break;
                    case 5:
                        break;
                    default:
                        break;
                }
            }
        }

        public void Insert(User user)
        {
            Initialize();
            Console.WriteLine("Enter name: ");
            user.Name = Console.ReadLine();
            Console.WriteLine("Enter age: ");
            user.Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter phone: ");
            user.Phone = Convert.ToInt32(Console.ReadLine());
            string sql = "Insert into user (name, age, phone) values('" + user.Name + "'," + user.Age + "," + user.Phone + ")";
            cmd = connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void List(User user)
        {
            Initialize();
            
            cmd = connection.CreateCommand();
            cmd.CommandText = "Select * from user";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine("Id    : " + reader["id"]);
                Console.WriteLine("Name  : " + reader["name"]);
                Console.WriteLine("Age   : " + reader["age"]);
                Console.WriteLine("Phone : " + reader["phone"]);
                Console.WriteLine("-----------------------------");
            }
            connection.Close();
        }
        public void Delete()
        {
            Initialize();
            Console.WriteLine("Enter id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            cmd = connection.CreateCommand();
            cmd.CommandText = "Delete from user where id =" + id;
            Console.WriteLine("Are you sure? 1.Yes|2.No");
            int confirm = Convert.ToInt32(Console.ReadLine());
            if(confirm == 1)
            {
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        } 
        public void Edit(User user)
        {
            Initialize();
            Console.WriteLine("Enter id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            cmd = connection.CreateCommand();
            cmd.CommandText = "Select * from user where id=" + id;
            reader = cmd.ExecuteReader();
            if (reader.Read() != false)
            {
                while (reader.Read())
                {
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Id    : " + reader["id"]);
                    Console.WriteLine("Name  : " + reader["name"]);
                    Console.WriteLine("Age   : " + reader["age"]);
                    Console.WriteLine("Phone : " + reader["phone"]);
                    Console.WriteLine("-----------------------------");
                }
                connection.Close();
                Console.WriteLine("Enter new name: ");
                user.Name = Console.ReadLine();
                Console.WriteLine("Enter new age: ");
                user.Age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter new phone: ");
                user.Phone = Convert.ToInt32(Console.ReadLine());
                Initialize();
                MySqlCommand cmd1 = new MySqlCommand();
                cmd1 = connection.CreateCommand();
                cmd1.CommandText = "Update user Set name='" + user.Name + "', age= " + user.Age + ",phone= " + user.Phone;
                cmd1.ExecuteNonQuery();
                connection.Close();
            } else
            {
                Console.WriteLine("Sorry didn't find that user ..");
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Menu();
        }
    }
}
