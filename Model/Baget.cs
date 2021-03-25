using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BagetShop.Model
{
    public class Baget : INotifyPropertyChanged
    {
        private Guid ID_;
        private int Amount_;
        private double Width_;
        private double Lenght_;
        private Type Type_;
        private Order Order_;

        public Guid ID { get { return ID_; } set {
                ID_ = value;
            } }
        public int Amount { get { return Amount_; } set {
                Amount_ = value;
                OnPropertyChanged("Amount");
            } }
        public double Width { get { return Width_; } set {
                Width_ = value;
                OnPropertyChanged("Width");
            } }
        public double Lenght { get { return Lenght_; } set {
                Lenght_ = value;
                OnPropertyChanged("Lenght");
            } }
        public Type Type { get { return Type_; } set {
                Type_ = value;
                OnPropertyChanged("Type");
            } }
        public Order Order { get { return Order_; } set {
                Order_ = value;
                OnPropertyChanged("Order");
            } }

        public Baget (int amo, double w, double l, Type bt, Order order)
        {
            this.ID = Guid.NewGuid();
            this.Width = w;
            this.Lenght = l;
            this.Type = bt;
            this.Order = order;
            this.Amount = amo;
        }

        public Baget() { this.ID = Guid.NewGuid(); }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public override string ToString()
        {
            return this.Amount + " of " + this.Type.ToString() + " ( " + this.Width.ToString() + " x " +
                this.Lenght.ToString() + " )";
        }
    }
}
