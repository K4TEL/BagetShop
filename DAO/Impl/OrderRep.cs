using BagetShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagetShop.DAO.Impl
{
    public class OrderRep : IOrderRep
    {
        private DB Database;
        private List<Order> Orders;
        public OrderRep(DB database)
        {
            this.Database = database;
            this.Orders = database.Orders;
        }
        public void Delete(Order entity)
        {
            this.Orders.Remove(entity);
        }

        public List<Order> GetAll()
        {
            return Orders;
        }

        public Order GetByID(Guid id)
        {
            return Orders.Find(o => o.ID == id);
        }

        public void Insert(Order entity)
        {
            this.Orders.Add(entity);
        }

        public void Update(Order entity)
        {
            Delete(entity);
            Insert(entity);
        }
    }
}
