using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Models
{
    public class User
    {
        public User(string name, decimal totalMoney)
        {
            this.TotalMoney = totalMoney;

            this.Name = name;

            this.Id++;
        }
        public string Name { get; set; }
        public int Id { get; set; }
        public decimal TotalMoney { get; set; }

        public List<ComponentObj> Components { get; set; } = new List<ComponentObj>();

        public decimal GetBill => this.Components.Sum(x => x.Price);
    }
}
