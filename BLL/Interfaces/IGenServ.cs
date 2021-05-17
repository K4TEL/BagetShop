using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IGenServ<T> where T:class
    {
        T Save(T item, Boolean isNew);
        T Load(Guid id);
        ObservableCollection<T> LoadAll();
        void Del(T item);
    }
}
