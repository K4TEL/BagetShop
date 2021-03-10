using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagetShop.DAO
{
    public interface IAnyRep<T>
    {
        List<T> GetAll();
        T GetByID(Guid id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
