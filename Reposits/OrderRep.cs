using DAL.DataBase;
using DAL.Interfaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Reposits
{
    public class OrderRep : IRepository<Order>
    {
        private DB db;

        public OrderRep(DB db)
        {
            this.db = db;
        }
        public void Create(Order entity)
        {
            db.Orders.Add(entity);
        }

        public void Delete(Order entity)
        {
            Order order = GetAll().ToList().Find(o => o.ID == entity.ID);
            if (order != null)
                db.Orders.Remove(order);
        }

        public ObservableCollection<Order> Find(Func<Order, bool> predicate)
        {
            return new ObservableCollection<Order>(db.Orders.Where(predicate));
        }

        public ObservableCollection<Order> GetAll()
        {
            return db.Orders;
        }

        public Order GetByID(Guid id)
        {
            return db.Orders.ToList().Find(o => o.ID == id);
        }

        public void Update(Order entity)
        {
            Delete(entity);
            Create(entity);
        }
    }
}
