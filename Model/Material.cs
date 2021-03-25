using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Material : INotifyPropertyChanged
    {
        private Guid ID_;
        private double Amount_;
        private string Name_;
        private bool Storage_;
        private Units Unit_;
        private BagType Type_;
        private Guid TypeID_;

        public Guid ID
        {
            get { return ID_; }
            set
            {
                ID_ = value;
            }
        }
        public double Amount
        {
            get { return Amount_; }
            set
            {
                Amount_ = value;
                OnPropertyChanged("Amount");
            }
        }
        public string Name
        {
            get { return Name_; }
            set
            {
                Name_ = value;
                OnPropertyChanged("Name");
            }
        }
        public bool Storage
        {
            get { return Storage_; }
            set
            {
                Storage_ = value;
                OnPropertyChanged("Storage");
            }
        }
        public Units Unit
        {
            get { return Unit_; }
            set
            {
                Unit_ = value;
                OnPropertyChanged("Unit");
            }
        }
        public BagType Type
        {
            get { return Type_; }
            set
            {
                Type_ = value;
                OnPropertyChanged("Type");
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

        public Material() { this.ID = Guid.NewGuid(); }
        public Material(string name, double amo, Units unit, bool storage)
        {
            this.ID = Guid.NewGuid();
            this.Name = name;
            this.Amount = amo;
            this.Unit = unit;
            this.Storage = storage;
        }

        public Material(string name, double amo, BagType type)
        {
            this.ID = Guid.NewGuid();
            this.Name = name;
            this.Amount = amo;
            this.Type = type;
            this.Storage = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public enum Units
        {
            ml,
            kg,
            g,
            mg,
            cm2,
            m2
        }
    }
}
