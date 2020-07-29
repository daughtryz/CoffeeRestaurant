using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Models
{
    public class CoffeeModel : ComponentObj
    {
        public CoffeeModel(string name, decimal price) : base(name, price)
        {
        }


        public List<Product> Products { get; set; } = new List<Product>();

    }
}
