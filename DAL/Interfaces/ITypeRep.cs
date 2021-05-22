using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITypeRep : IGenRep<BagType, Guid>
    {
        BagType Load(Guid id);
        IEnumerable<BagType> LoadAll();

        IEnumerable<Material> LoadMaterials(Guid id);
    }
}
