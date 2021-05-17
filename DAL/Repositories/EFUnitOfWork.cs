using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;

namespace DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private BagetContext db;
        private IOrderRep orders;
        private IBagetRep bagets;
        private ITypeRep types;
        private IMatRep materials;

        //public EFUnitOfWork(string connectionString)
        //{
        //    this.db = new BagetContext(connectionString);
        //}

        //public EFUnitOfWork(string connection,
        //    IOrderRep orders,
        //    IBagetRep bagets,
        //    ITypeRep types,
        //    IMatRep materials)
        //{
        //    this.db = new BagetContext(connection);
        //    this.materials = materials;
        //    this.types = types;
        //    this.bagets = bagets;
        //    this.orders = orders;
        //}
        public EFUnitOfWork(BagetContext context, 
            IOrderRep orders, 
            IBagetRep bagets,
            ITypeRep types,
            IMatRep materials)
        {
            this.db = context;
            this.materials = materials;
            this.types = types;
            this.bagets = bagets;
            this.orders = orders;
        }

        //public EFUnitOfWork()
        //{
        //    this.db = new BagetContext("DefaultConnection");
        //}

        public IOrderRep OrderRep { get { return orders;} }
        public IBagetRep BagetRep { get { return bagets; } }

        public ITypeRep TypeRep { get { return types; } }

        public IMatRep MatRep { get { return materials; } }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    db.Dispose();
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
