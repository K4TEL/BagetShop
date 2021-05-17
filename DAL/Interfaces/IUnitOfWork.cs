using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderRep OrderRep { get; }
        IBagetRep BagetRep { get; }
        ITypeRep TypeRep { get; }
        IMatRep MatRep { get; }
        void Save();
    }
}
