using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagetShop
{
    public class Base<T> where T:Base<T>
    {
        static public List<T> Objects = new List<T>();
        public Guid ID { get; set; }

        public Base()
        {
            ID = Guid.NewGuid();
            Objects.Add((T)this);
        }
    }
}
