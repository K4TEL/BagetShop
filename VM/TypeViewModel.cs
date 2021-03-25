using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Type = BagetShop.Model.Type;
using BagetShop.Model;

namespace BagetShop.VM
{
    class TypeViewModel : INotifyPropertyChanged
    {
        private Type Type;

        public TypeViewModel(Type type)
        {
            this.Type = type;
        }
        public string Title { get { return Type.Title; } set {
                Type.Title = value;
                OnPropertyChanged("Title");
            } }
        public List<Material> Materials { get { return Type.Materials; } set {
                Type.Materials = value;
                OnPropertyChanged("Materials");
            } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
