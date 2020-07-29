using Coffee.Models;
using Coffee.Models.Coffees;
using Coffee.Services;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Coffee.ViewModels
{
    public class CoffeeViewModel : INotifyPropertyChanged

    {
        #region Declaraions

        private UsersService usersService;
        private ComponentObj selectedComponent;
        #endregion

        #region Constructors

        public CoffeeViewModel()
        {
            this.usersService = new UsersService();
            this.ComponentsList = new ObservableCollection<ComponentObj>();
            //CoffeeTypes.Add(new Coffee("Mocha", "add", 7.1m),
            //    new Coffee("Espresso", "add", 6.1m));
        }

        #endregion

        #region Properties

        private ICommand orderCommand;

        private ICommand payCommand;


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ICommand PaymentCommand
        {
            get
            {
                if (payCommand == null)
                    payCommand = new DelegateCommand<object>(MakePayment);

                return payCommand;
            }
        }

        private void MakePayment(object obj)
        {
          
            if(this.UserTotalMoney <= 0)
            {
                MessageBox.Show("Bill cannot be paid!");
                return;
            }
            string info = this.usersService.PaymentProcedure(this.CustomerName, this.UserTotalMoney,this.ComponentsList);

            this.Info = info;

           
            MessageBox.Show($"{this.Info}");
            this.ComponentsList.Clear();
        }

        public ICommand OrderCommand
        {
            get
            {
                if (orderCommand == null)
                    orderCommand = new DelegateCommand<object>(MakeOrder);

                return orderCommand;
            }
        }
        private ComponentObj componentObj;
        public ComponentObj Component
        {
            get
            {
                return this.componentObj;
            }
            set
            {
                this.componentObj = value;
                OnPropertyChanged("Component");
            }
        }

        public List<CoffeeModel> Coffees { get; set; } = new List<CoffeeModel>
        {
            new BlackCoffee(),
            new Espresso(),
            new Mocha()
        };
        public ComponentObj SelectedComponent
        {
            get
            {
                return selectedComponent;
            }
            set
            {
                if (value == selectedComponent)
                    return;

                selectedComponent = value;
                OnPropertyChanged();
            }
        }

        public string ProductName { get; set; }

        public string AdditionType { get; set; }

        public string CustomerName { get; set; }

        public decimal UserTotalMoney { get; set; }


        public List<ComponentObj> AvailableProducts { get; set; } = new List<ComponentObj> {

            new ComponentObj("Ice Tea",5.20M),
            new ComponentObj("Coca-Cola",6.30M),
            new ComponentObj("Coffee",3.00M),
            new BlackCoffee(),
            new Espresso(),
            new Mocha(),
            new ComponentObj("Sugar",7.00M),
            new ComponentObj("Milk",8.20M),
            new ComponentObj("Cream",9.00M)

        };

        public List<string> CoffeeAddition { get; set; } = new List<string> { "Захар", "Мляко", "Cream" };

        
        #endregion


        #region Methods
        private void MakeOrder(object obj)
        {

            CoffeeModel cm = null;
            if (this.Component.Name == "Coffee")
            {

                 cm = this.Component as CoffeeModel;
                
                //cm.Products.AddRange()



            }
            
            this.ComponentsList.Add(this.Component);
            
        }
        
        public ObservableCollection<ComponentObj> ComponentsList { get; set; }

        public List<string> TestItems { get; set; } = new List<string> { "ssss", "zzzz", "hhhhhh" };

        #endregion
        private string info;
        public string Info
        {
            get
            {
                return this.info;

            }
            set
            {
                this.info = value;
                OnPropertyChanged();

            }
        }

    
}
}
