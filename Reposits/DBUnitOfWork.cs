using DAL.DataBase;
using DAL.Interfaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Reposits
{
    public class DBUnitOfWork : IUnitOfWork
    {
        private DB db;
        private OrderRep orders;
        private BagetRep bagets;
        private TypeRep types;
        private MatRep materials;

        public DBUnitOfWork(DB db)
        {
            this.db = db;
        }

        public DBUnitOfWork()
        {
            this.db = new DB();
            TestData data = new TestData(db);
        }

        public IRepository<Order> OrderRep
        {
            get
            {
                if (orders == null)
                    orders = new OrderRep(db);
                return orders;
            }
        }
        public IRepManyToOne<Order, Baget> BagetRep
        {
            get
            {
                if (bagets == null)
                    bagets = new BagetRep(db);
                return bagets;
            }
        }

        public IRepository<BagType> TypeRep
        {
            get
            {
                if (types == null)
                    types = new TypeRep(db);
                return types;
            }
        }

        public IRepManyToOne<BagType, Material> MatRep
        {
            get
            {
                if (materials == null)
                    materials = new MatRep(db);
                return materials;
            }
        }
    }
}
