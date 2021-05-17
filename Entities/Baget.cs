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
    public class Baget
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public double Width { get; set; }
        [Required]
        public double Lenght { get; set; }
        public BagType Type { get; set; }
        [Required]
        public Guid Type_ID { get; set; }
        public Order Order { get; set; }
        [Required]
        public Guid Order_ID { get; set; }

        public Baget(int amo, double w, double l, BagType bt, Order order)
        {
            this.ID = Guid.NewGuid();
            this.Width = w;
            this.Lenght = l;
            this.Type = bt;
            this.Order = order;
            this.Amount = amo;
        }

        public Baget(int amo, double w, double l, Guid btID, Guid orderID)
        {
            this.ID = Guid.NewGuid();
            this.Width = w;
            this.Lenght = l;
            this.Type_ID = btID;
            this.Order_ID = orderID;
            this.Amount = amo;
        }

        public Baget(Order order) 
        {
            this.ID = Guid.NewGuid();
            this.Order = order;
        }

        public Baget(Guid orderID)
        {
            this.ID = Guid.NewGuid();
            this.Order_ID = orderID;
        }

        public Baget()
        {
            this.ID = Guid.NewGuid();
        }
    }
}
