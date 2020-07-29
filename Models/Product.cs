using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Models
{
    public class Product : ComponentObj
    {
        public Product(string name, decimal price) : base(name, price)
        {
        }
    }
}
