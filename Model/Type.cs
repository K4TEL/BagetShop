using BagetShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace BagetShop.Model
{
    public class Type : INotifyPropertyChanged
    {
        private Guid ID_;
        private string Title_;
        private List<Material> Materials_;

        public Guid ID { get { return ID_; } set {
                ID_ = value;
            } }
        public string Title { get { return Title_; } set {
                Title_ = value;
                OnPropertyChanged("Title");
            } }
        public List<Material> Materials { get { return Materials_; } set {
                Materials_ = value;
                OnPropertyChanged("Materials");
            } }

        public Type() { this.ID = Guid.NewGuid(); this.Materials = new List<Material>(); }
        public Type(string title)
        {
            this.ID = Guid.NewGuid();
            this.Title = title;
            this.Materials = new List<Material>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public override string ToString()
        {
            return this.Title;
        }
    }
}
