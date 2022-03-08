using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderCLI
{
    class Products
    {
        string name;
        int stock;

        public Products(string name, int stock)
        {
            this.name = name;
            this.stock = stock;
        }
        public string getName()
        {
            return this.name;
        }
        public int GetStock()
        {
            return this.stock;
        }
    }
}
