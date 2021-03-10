using BagetShop.DAO;
using BagetShop.DAO.Impl;
using BagetShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagetShop.Service
{
    public class OrderServ : IOrderServ
    {
        private IUnitOfWork UOW;
        public OrderServ(IUnitOfWork uow)
        {
            this.UOW = uow;
        }
        public bool isEnough(Order order)
        {
            bool enough = true;

            return enough;
        }
    }
}
