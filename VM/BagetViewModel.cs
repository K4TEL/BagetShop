using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BagetShop.Model;
using Type = BagetShop.Model.Type;

namespace BagetShop.VM
{
    public class BagetViewModel : INotifyPropertyChanged
    {
        private Baget Baget;
        public BagetViewModel(Baget baget)
        {
            this.Baget = baget;
        }

        public int Amount { get { return Baget.Amount; } set {
                Baget.Amount = value;
                OnPropertyChanged("Amount");
            } }
        public double Width { get { return Baget.Width; } set {
                Baget.Width = value;
                OnPropertyChanged("Width");
            } }
        public double Lenght { get { return Baget.Lenght; } set {
                Baget.Lenght = value;
                OnPropertyChanged("Lenght");
            } }
        public Type Type { get { return Baget.Type; } set {
                Baget.Type = value;
                OnPropertyChanged("Type");
            } }
        public Order Order { get { return Baget.Order; } set {
                Baget.Order = value;
                OnPropertyChanged("Order");
            } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
