using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Baget : BaseEntity<Guid>
    {
        public int Amount { get; set; }
        public double Width { get; set; }
        public double Lenght { get; set; }
        public BagType Type { get; set; }
        public Guid Type_ID { get; set; }
        public Order Order { get; set; }
        public Guid Order_ID { get; set; }

        public Baget(int amo, double w, double l, BagType bt, Order order)
        {
            ID = Guid.NewGuid();
            this.Width = w;
            this.Lenght = l;
            this.Type = bt;
            this.Order = order;
            this.Amount = amo;
        }

        public Baget(int amo, double w, double l, Guid btID, Guid orderID)
        {
            ID = Guid.NewGuid();
            this.Width = w;
            this.Lenght = l;
            this.Type_ID = btID;
            this.Order_ID = orderID;
            this.Amount = amo;
        }

        public Baget() { ID = Guid.NewGuid(); }
    }
}
