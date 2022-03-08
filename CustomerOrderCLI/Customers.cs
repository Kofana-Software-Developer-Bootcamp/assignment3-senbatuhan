using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderCLI
{
    class Customers
    {
        string id;
        string name;
        string surname;
        public Customers(string id, string name, string surname)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
        } 
        public string getName()
        {
            return this.name;
        }
        public string getSurname()
        {
            return this.surname;
        }
        public string getId()
        {
            return this.id;
        }
    }
}
