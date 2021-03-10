using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagetShop.DAO.Impl
{
    public class UnitOfWork : IUnitOfWork
    {
        private DB Database;

        private ITypeRep TypeRep;
        private IOrderRep OrderRep;
        private IBagetRep BagetRep;
        private IMaterialRep MaterialRep;

        public UnitOfWork(DB database)
        {
            this.Database = database;
        }
        public IBagetRep GetBagetRep()
        {
            if (BagetRep == null)
                this.BagetRep = new BagetRep(Database);
            return BagetRep;
        }

        public IMaterialRep GetMaterialRep()
        {
            if (MaterialRep == null)
                this.MaterialRep = new MaterialRep(Database);
            return MaterialRep;
        }

        public IOrderRep GetOrderRep()
        {
            if (OrderRep == null)
                this.OrderRep = new OrderRep(Database);
            return OrderRep;
        }

        public ITypeRep GetTypeRep()
        {
            if (TypeRep == null)
                this.TypeRep = new TypeRep(Database);
            return TypeRep;
        }
    }
}
