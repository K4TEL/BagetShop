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
    public class BagType : INotifyPropertyChanged
    {
        private Guid ID_;
        private string Title_;
        private ObservableCollection<Material> Materials_;

        public Guid ID
        {
            get { return ID_; }
            set
            {
                ID_ = value;
            }
        }
        public string Title
        {
            get { return Title_; }
            set
            {
                Title_ = value;
                OnPropertyChanged("Title");
            }
        }
        public ObservableCollection<Material> Materials
        {
            get { return Materials_; }
            set
            {
                Materials_ = value;
                OnPropertyChanged("Materials");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public BagType() 
        { 
            this.ID = Guid.NewGuid(); 
            //this.Materials = new ObservableCollection<Material>();
        }
        public BagType(string title)
        {
            this.ID = Guid.NewGuid();
            this.Title = title;
            //this.Materials = new ObservableCollection<Material>();
        }
    }
}
