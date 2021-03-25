using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Order : INotifyPropertyChanged
    {
        private Guid ID_;
        private ObservableCollection<Baget> Bagets_;
        private string Customer_;
        public Guid ID
        {
            get { return ID_; }
            set
            {
                ID_ = value;
            }
        }
        public ObservableCollection<Baget> Bagets
        {
            get { return Bagets_; }
            set
            {
                Bagets_ = value;
                OnPropertyChanged("Bagets");
            }
        }
        public string Customer
        {
            get { return Customer_; }
            set
            {
                Customer_ = value;
                OnPropertyChanged("Customer");
            }
        }

        public Order(ObservableCollection<Baget> bagets, string customer)
        {
            this.ID = Guid.NewGuid();
            //this.Bagets = bagets;
            this.Customer = customer;
        }

        public Order() 
        { 
            this.ID = Guid.NewGuid(); 
            //this.Bagets = new ObservableCollection<Baget>(); 
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
