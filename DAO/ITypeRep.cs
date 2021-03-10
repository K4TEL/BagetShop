using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = BagetShop.Model.Type;


namespace BagetShop.DAO
{
    public interface ITypeRep : IAnyRep<Type>
    {
        Type GetByName(string name);
    }
}
