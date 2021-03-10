using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagetShop.Model
{
    public class Order
    {
        public Guid ID { get; set; }
        public List<Baget> Bagets { get; set; }
        public string Customer { get; set; }

        public Order(List<Baget> bagets, string customer)
        {
            this.ID = Guid.NewGuid();
            this.Bagets = bagets;
            this.Customer = customer;
        }

        public Order() { this.ID = Guid.NewGuid(); this.Bagets = new List<Baget>(); }

        public override string ToString()
        {
            string rez = this.Customer;
            foreach (Baget b in this.Bagets)
                rez += "\n" + b.ToString();
            return rez;
        }
    }
}
