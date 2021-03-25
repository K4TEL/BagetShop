using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BagetShop.Model;

namespace BagetShop.VM
{
    public class OrderViewModel : INotifyPropertyChanged
    {
        private Order Order;

        public OrderViewModel(Order order)
        {
            this.Order = order;
        }

        public string Customer { get { return Order.Customer; } set
            {
                Order.Customer = value;
                OnPropertyChanged("Customer");
            } }

        public List<Baget> Bagets
        {
            get { return Order.Bagets; }
            set
            {
                Order.Bagets = value;
                OnPropertyChanged("Bagets");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
