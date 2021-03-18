using BagetShop.DAO;
using BagetShop.DAO.Impl;
using BagetShop.Model;
using BagetShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WpfBaget;

namespace BagetShop
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IUnitOfWork uow = new UnitOfWork();
            IOrderServ orderServ = new OrderServ();

            Order order = new Order();
            order.Customer = "Mike";
            uow.GetOrderRep().Insert(order);

            Baget baget1 = new Baget(1, 0.2, 0.5, uow.GetTypeRep().GetByName("Silver Glass"), order);
            uow.GetBagetRep().AddBaget(order, baget1);

            Baget baget2 = new Baget(2, 0.3, 0.45, uow.GetTypeRep().GetByName("Red Wood"), order);
            uow.GetBagetRep().AddBaget(order, baget2);

            Console.WriteLine(orderServ.isEnough(order));

            MainWindow win = new MainWindow();
            new App().Run(win);
        }
    }
}
