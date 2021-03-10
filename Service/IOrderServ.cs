using BagetShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagetShop.Service
{
    public interface IOrderServ
    {
        bool isEnough(Order order);
    }
}
