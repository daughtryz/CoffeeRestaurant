using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Models.Coffees
{
    public class Espresso : CoffeeModel
    {
        private const decimal BasePrice = 5.10M;
        private const string BaseName = "Espresso";
        public Espresso() : base(BaseName, BasePrice)
        {
        }
    }
}
