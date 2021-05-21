using Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICalcServ
    {
        Boolean IsEnough(Order order);
        String showMaterials(OrderModel orderDTO);
    }
}
