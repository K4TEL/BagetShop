using DAL.Interfaces;
using DAL.Model;
using DAL.Reposits;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataBase
{
    public class DB
    {
        public ObservableCollection<Order> Orders { get; set; }
        public ObservableCollection<Baget> Bagets { get; set; }
        public ObservableCollection<BagType> Types { get; set; }
        public ObservableCollection<Material> Materials { get; set; }

        public DB()
        {
            this.Orders = new ObservableCollection<Order>();
            this.Bagets = new ObservableCollection<Baget>();
            this.Types = new ObservableCollection<BagType>();
            this.Materials = new ObservableCollection<Material>();
        }

        public IUnitOfWork GetUnitOfWork()
        {
            return new DBUnitOfWork(this);
        }
    }
}
