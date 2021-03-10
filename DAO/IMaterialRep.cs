using BagetShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = BagetShop.Model.Type;

namespace BagetShop.DAO
{
    public interface IMaterialRep : IAnyRep<Material>
    {
        void AddMaterial(Type type, Material mat);
        void AddMaterial(Type type, string name, double amo);
    }
}
