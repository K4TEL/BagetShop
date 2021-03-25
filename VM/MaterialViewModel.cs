using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Type = BagetShop.Model.Type;
using BagetShop.Model;
using static BagetShop.Model.Material;

namespace BagetShop.VM
{
    public class MaterialViewModel : INotifyPropertyChanged
    {
        private Material Material;
        public MaterialViewModel(Material material)
        {
            this.Material = material;
        }
        public double Amount { get { return Material.Amount; } set {
                Material.Amount = value;
                OnPropertyChanged("Amount");
            } }
        public string Name { get { return Material.Name; } set {
                Material.Name = value;
                OnPropertyChanged("Name");
            } }
        public bool Storage { get { return Material.Storage; } set {
                Material.Storage = value;
                OnPropertyChanged("Storage");
            } }
        public Units Unit { get { return Material.Unit; } set {
                Material.Unit = value;
                OnPropertyChanged("Unit");
            } }
        public Type Type { get { return Material.Type; } set {
                Material.Type = value;
                OnPropertyChanged("Type");
            } }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
