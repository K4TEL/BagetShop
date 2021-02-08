using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagetShop
{
    public class Order : Base<Order>
    {
        public Baget Baget { get; set; }

        public int Amount { get; set; }

        public Order(Baget baget, int amo) : base()
        {
            this.Baget = baget;
            this.Amount = amo;
        }

        public Order() : base()
        {
            this.Baget = new Baget();
        }

        public void setOrder()
        {
            Baget.SetBaget();

            Console.WriteLine("Set the amount: ");
            this.Amount = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return this.Amount.ToString() + " - " + this.Baget.ToString();
        }
    }
}
