using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Baget : INotifyPropertyChanged
    {
        private Guid ID_;
        private int Amount_;
        private double Width_;
        private double Lenght_;
        private BagType Type_;
        private Order Order_;
        private Guid TypeID_;
        private Guid OrderID_;

        public Guid ID
        {
            get { return ID_; }
            set
            {
                ID_ = value;
            }
        }
        public int Amount
        {
            get { return Amount_; }
            set
            {
                Amount_ = value;
                OnPropertyChanged("Amount");
            }
        }
        public double Width
        {
            get { return Width_; }
            set
            {
                Width_ = value;
                OnPropertyChanged("Width");
            }
        }
        public double Lenght
        {
            get { return Lenght_; }
            set
            {
                Lenght_ = value;
                OnPropertyChanged("Lenght");
            }
        }
        public BagType Type
        {
            get { return Type_; }
            set
            {
                Type_ = value;
                if (value != null)
                    TypeID = value.ID;
                OnPropertyChanged("Type");
            }
        }
        public Order Order
        {
            get { return Order_; }
            set
            {
                Order_ = value;
                if (value != null)
                    OrderID = value.ID;
                OnPropertyChanged("Order");
            }
        }
        
        public Guid TypeID 
        {
            get { return TypeID_; }
            set
            {
                TypeID_ = value;
                OnPropertyChanged("TypeID");
            }
        }

        public Guid OrderID
        {
            get { return OrderID_; }
            set
            {
                OrderID_ = value;
                OnPropertyChanged("OrderID");
            }
        }

        public Baget(int amo, double w, double l, BagType bt, Order order)
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
    }
}
