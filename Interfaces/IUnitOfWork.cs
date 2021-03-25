using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Order> OrderRep { get; }
        IRepManyToOne<Order, Baget> BagetRep { get; }
        IRepository<BagType> TypeRep { get; }
        IRepManyToOne<BagType, Material> MatRep { get; }
    }
}
