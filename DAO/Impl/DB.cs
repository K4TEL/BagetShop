using BagetShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = BagetShop.Model.Type;


namespace BagetShop.DAO.Impl
{
    public class DB
    {
        public List<Order> Orders { get; set; }
        public List<Baget> Bagets { get; set; }
        public List<Type> Types { get; set; }
        public List<Material> Materials { get; set; }

        public DB()
        {
            this.Orders = new List<Order>();
            this.Bagets = new List<Baget>();
            this.Types = new List<Type>();
            this.Materials = new List<Material>();
        }

        public IUnitOfWork GetUnitOfWork()
        {
            return new UnitOfWork(this);
        }
    }
}
