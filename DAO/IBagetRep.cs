using BagetShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = BagetShop.Model.Type;


namespace BagetShop.DAO
{
    public interface IBagetRep : IAnyRep<Baget>
    {
        void AddBaget(Order order, Baget baget);
        void AddBaget(Order order, int amo, double w, double l, Type type);
    }
}
