using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IMatRep : IGenRep<Material, Guid>
    {
        Material Load(Guid id);
        IEnumerable<Material> LoadAll();
        IEnumerable<Material> Storage();

        BagType LoadType(Guid id);

    }
}
