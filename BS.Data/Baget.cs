using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagetShop
{
    public class Baget : Base<Baget>
    {
        public double Width { get; set; }
        public double Lenght { get; set; }
        public BagetType BagetType { get; set; }

        public Baget (double w, double l, BagetType bt) : base()
        {
            this.Width = w;
            this.Lenght = l;
            this.BagetType = bt;
        }

        public Baget() : base() { }

        public void SetBaget()
        {
            foreach(BagetType bt in BagetType.Objects)
            {
                Console.Write(bt + " ");
            }
            Console.WriteLine(" ");
            Console.WriteLine("Choose type from above: ");
            this.BagetType = BagetType.getByName(Console.ReadLine());

            Console.WriteLine("Set width in cm: ");
            this.Width = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Set lenght in cm: ");
            this.Lenght = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return this.BagetType.ToString() + " (" + this.Width.ToString() + "x" +
                this.Lenght.ToString() + ")";
        }
    }
}
