using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BagetShop.Model;
using System.Collections.ObjectModel;

namespace BagetShop.VM
{
    public class AppViewModel : INotifyPropertyChanged
    {
        private Order SelectedOrder_;
        public ObservableCollection<Order> Orders { get; set; }
        public Order SelectedOrder { get { return SelectedOrder_; } set
            {
                SelectedOrder_ = value;
                OnPropertyChanged("SelectedOrder");
            } }

        public AppViewModel()
        {
            Orders = new ObservableCollection<Order>();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
