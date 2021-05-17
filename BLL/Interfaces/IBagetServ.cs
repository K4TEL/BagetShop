using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBagetServ : IGenServ<BagetModel>
    {
        TypeModel LoadType(Guid id);
        //OrderModel LoadOrder(Guid id);
    }
}
