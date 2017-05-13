using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class User
    {
        private string name;
        private int age;
        private int phone;

        public string Name{
            get{ return name; }
            set{ name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public int Phone
        {
            get { return phone; }
            set { phone = value; }
        }

    }
}
