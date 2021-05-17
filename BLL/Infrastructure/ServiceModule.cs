using Ninject.Modules;
using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;

namespace BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }

        public ServiceModule() { }

        public override void Load()
        {
            if (connectionString is null)
                connectionString = "DefaultConnection";

            Bind<BagetContext>().ToSelf()
                .InSingletonScope()
                .WithConstructorArgument(connectionString);

            Bind<IUnitOfWork>().To<EFUnitOfWork>();

            Bind<ITypeRep>().To<TypeRep>();
            Bind<IMatRep>().To<MatRep>();
            Bind<IBagetRep>().To<BagetRep>();
            Bind<IOrderRep>().To<OrderRep>();

            Bind<IOrderServ>().To<OrderServ>();
            Bind<IBagetServ>().To<BagetServ>();
            Bind<ITypeServ>().To<TypeServ>();
        }
    }
}
