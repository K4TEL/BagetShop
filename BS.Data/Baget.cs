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

        public override string ToString()
        {
            return this.BagetType.ToString() + " (" + this.Width.ToString() + "x" +
                this.Lenght.ToString() + ")";
        }
    }
}
