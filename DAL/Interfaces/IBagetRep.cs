using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IBagetRep : IGenRep<Baget>
    {
        Baget Load(Guid id);
        IEnumerable<Baget> LoadAll();

        BagType LoadType(Guid id);
        Order LoadOrder(Guid id);
    }
}
