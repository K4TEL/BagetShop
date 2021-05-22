using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IOrderRep : IGenRep<Order, Guid>
    {
        Order Load(Guid id);
        IEnumerable<Order> LoadAll();

        IEnumerable<Baget> LoadBagets(Guid id);

    }
}
