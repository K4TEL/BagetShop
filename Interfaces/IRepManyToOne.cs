using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepManyToOne<S, T> : IRepository<T> where T:class where S:class
    {
        void AddNew(S owner, T item);
        void DelFrom(S owner, T item);
    }
}
