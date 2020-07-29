using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Models.Coffees
{
    public class BlackCoffee : CoffeeModel
    {
        private const decimal BasePrice = 6.00M;
        private const string BaseName = "BlackCoffee";
        public BlackCoffee() : base(BaseName, BasePrice)
        {

        }


    }
}
