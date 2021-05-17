using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IOrderServ : IGenServ<OrderModel>, ICalcServ
    {
        OrderModel AddBaget(OrderModel order, BagetModel baget);
        OrderModel DelBaget(OrderModel order, BagetModel baget);

        //ObservableCollection<BagetModel> LoadBagets(Guid id);
    }
}
