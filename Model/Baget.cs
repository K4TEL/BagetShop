using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagetShop.Model
{
    public class Baget
    {
        public Guid ID { get; set; }
        public int Amount { get; set; }
        public double Width { get; set; }
        public double Lenght { get; set; }
        public Type Type { get; set; }
        public Order Order { get; set; }

        public Baget (int amo, double w, double l, Type bt, Order order)
        {
            this.ID = Guid.NewGuid();
            this.Width = w;
            this.Lenght = l;
            this.Type = bt;
            this.Order = order;
            this.Amount = amo;
        }

        public Baget() { this.ID = Guid.NewGuid(); }

        public override string ToString()
        {
            return this.Amount + " of " + this.Type.ToString() + " ( " + this.Width.ToString() + " x " +
                this.Lenght.ToString() + " )";
        }
    }
}
