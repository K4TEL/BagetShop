using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagetShop.DAO
{
    public interface IUnitOfWork
    {
        IOrderRep GetOrderRep();
        IBagetRep GetBagetRep();
        ITypeRep GetTypeRep();
        IMaterialRep GetMaterialRep();
    }
}
