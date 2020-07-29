using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Models.Coffees
{
    public class Mocha : CoffeeModel
    {
        private const decimal BasePrice = 4.90M;
        private const string BaseName = "Mocha";
        public Mocha() : base(BaseName, BasePrice)
        {
        }
    }
}
