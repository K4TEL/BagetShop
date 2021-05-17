using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Order : BaseEntity<Guid>
    {
        public List<Baget> Bagets { get; set; }
        public string Customer { get; set; }

        private Order() { }

        public Order(string customer)
        {
            ID = Guid.NewGuid();
            this.Customer = customer;
            this.Bagets = new List<Baget>();
        }
    }
}
