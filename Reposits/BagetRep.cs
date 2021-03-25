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
    public class BagetRep : IRepManyToOne<Order, Baget>
    {
        private DB db;

        public BagetRep(DB db)
        {
            this.db = db;
        }
        public void AddNew(Order owner, Baget item)
        {
            item.Order = owner;
            //Create(item);
            //db.Orders.ToList().Find(o => o.ID == owner.ID).Bagets.Add(item);
        }

        public void Create(Baget entity)
        {
            if (entity.Type != null)
                entity.TypeID = entity.Type.ID;
            if (entity.Order != null)
                entity.OrderID = entity.Order.ID;

            if (entity.TypeID != null)
                entity.Type = db.Types.ToList().Find(t => t.ID == entity.TypeID);
            if (entity.OrderID != null)
                entity.Order = db.Orders.ToList().Find(o => o.ID == entity.OrderID);
            db.Bagets.Add(entity);
        }

        public void Delete(Baget entity)
        {
            Baget baget = GetByID(entity.ID);
            if (baget != null)
                db.Bagets.Remove(baget);
        }

        public void DelFrom(Order owner, Baget item)
        {
            //Order order = db.Orders.ToList().Find(o => o.ID == owner.ID);
            //if (order != null)
            //    order.Bagets.Remove(order.Bagets.ToList().Find(b => b.ID == item.ID));
            Delete(item);
        }

        public ObservableCollection<Baget> Find(Func<Baget, bool> predicate)
        {
            return new ObservableCollection<Baget>(db.Bagets.Where(predicate));
        }

        public ObservableCollection<Baget> GetAll()
        {
            return db.Bagets;
        }

        public Baget GetByID(Guid id)
        {
            return db.Bagets.ToList().Find(b => b.ID == id);
        }

        public void Update(Baget entity)
        {
            Delete(entity);
            Create(entity);
        }
    }
}
