using Coffee.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Coffee.Services
{
    public class UsersService
    {
        private StringBuilder sb;
        public UsersService()
        {
            this.Customers = new List<User>();
            this.sb = new StringBuilder();
        }

        public ICollection<User> Customers { get; set; }

        #region Methods
        public string PaymentProcedure(string customerName, decimal userTotalMoney,ObservableCollection<ComponentObj> componentsList)
        {

            var currentCustomer = this.Customers.FirstOrDefault(x => x.Name == customerName);

            if (currentCustomer == null)
            {
                currentCustomer = new User(customerName, userTotalMoney);
                this.Customers.Add(currentCustomer);

            }
            foreach (var component in componentsList)
            {

                currentCustomer.Components.Add(component);
         
            }
            if(currentCustomer.TotalMoney < currentCustomer.GetBill)
            {
                
                return $"Customer {currentCustomer.Name} doesn't have enough money!";
            }
            this.sb.AppendLine($"Your bill is {currentCustomer.GetBill}");
            this.sb.AppendLine($"Customer {currentCustomer.Name} bought {string.Join(", ",currentCustomer.Components.Select(c => c.Name))}");
            
            this.sb.AppendLine($"Given money {currentCustomer.TotalMoney} -> Change = {currentCustomer.TotalMoney - currentCustomer.GetBill}");
            currentCustomer.TotalMoney = currentCustomer.TotalMoney - currentCustomer.GetBill;
            return this.sb.ToString();
        }
       

        #endregion
    }
}
