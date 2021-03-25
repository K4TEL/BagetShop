using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<T> where T: class
    {
        ObservableCollection<T> GetAll();
        ObservableCollection<T> Find(Func<T, Boolean> predicate);
        T GetByID(Guid id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
