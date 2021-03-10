using BagetShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = BagetShop.Model.Type;


namespace BagetShop.DAO.Impl
{
    public class BagetRep : IBagetRep
    {
        private DB Database;
        private List<Baget> Bagets;
        public BagetRep(DB database)
        {
            this.Database = database;
            this.Bagets = database.Bagets;
        }
        public void AddBaget(Order order, Baget baget)
        {
            Database.Orders.Find(o => o == order).Bagets.Add(baget);
            baget.Order = order;
            Insert(baget);
        }

        public void AddBaget(Order order, int amo, double w, double l, Type type)
        {
            Baget baget = new Baget(amo, w, l, type, order);
            Database.Orders.Find(o => o == order).Bagets.Add(baget);
            Insert(baget);
        }

        public void Delete(Baget entity)
        {
            this.Bagets.Remove(entity);
        }

        public List<Baget> GetAll()
        {
            return Bagets;
        }

        public Baget GetByID(Guid id)
        {
            return Bagets.Find(b => b.ID == id);
        }

        public void Insert(Baget entity)
        {
            this.Bagets.Add(entity);
        }

        public void Update(Baget entity)
        {
            Delete(entity);
            Insert(entity);
        }
    }
}
