using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BagetShop.Model
{
    public class Order : INotifyPropertyChanged
    {
        private Guid ID_;
        private List<Baget> Bagets_;
        private string Customer_;
        public Guid ID { get { return ID_; } set {
                ID_ = value;
            } }
        public List<Baget> Bagets { get { return Bagets_; } set {
                Bagets_ = value;
                OnPropertyChanged("Bagets");
            } }
        public string Customer { get { return Customer_; } set {
                Customer_ = value;
                OnPropertyChanged("Customer");
            } }

        public Order(List<Baget> bagets, string customer)
        {
            this.ID = Guid.NewGuid();
            this.Bagets = bagets;
            this.Customer = customer;
        }

        public Order() { this.ID = Guid.NewGuid(); this.Bagets = new List<Baget>(); }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public override string ToString()
        {
            string rez = this.Customer;
            foreach (Baget b in this.Bagets)
                rez += "\n" + b.ToString();
            return rez;
        }
    }
}
