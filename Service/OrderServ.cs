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

        public OrderServ()
        {
            this.UOW = new UnitOfWork();
        }
        public bool isEnough(Order order)
        {
            bool enough = true;
            Console.WriteLine(order);

            foreach (Material mat in UOW.GetMaterialRep().GetStorage())
            {
                double present = mat.Amount;
                foreach (Baget baget in order.Bagets)
                {
                    foreach (Material needed in baget.Type.Materials)
                    {
                        if (needed.Name == mat.Name)
                            present -= baget.Amount * needed.Amount * baget.Width * baget.Lenght * 10;
                    }
                }

                if (present > 0)
                    Console.WriteLine(present + " of " + mat + " left");
                else
                {
                    enough = false;
                    Console.WriteLine("Lacks " + Math.Abs(present) + " of " + mat);
                }

            }

            return enough;
        }

        public IUnitOfWork GetUOW()
        {
            return UOW;
        }
    }
}
