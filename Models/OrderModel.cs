using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class OrderModel
    {
        public Guid ID { get; set; }
        public string Customer { get; set; }
        public ObservableCollection<BagetModel> Bagets { get; set; }

        public override string ToString()
        {
            return Customer + " bagets: " + Bagets.Count;
        }
    }
}
