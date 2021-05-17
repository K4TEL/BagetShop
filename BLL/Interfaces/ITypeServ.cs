using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITypeServ
    {
        TypeModel Load(Guid id);
        ObservableCollection<TypeModel> LoadAll();
    }
}
