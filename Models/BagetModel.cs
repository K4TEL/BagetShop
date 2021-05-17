using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BagetModel
    {
        public Guid ID { get; set; }
        public string Amount { get; set; }
        public string Width { get; set; }
        public string Lenght { get; set; }
        public Guid TypeID { get; set; }
        public Guid OrderID { get; set; }

        public string Typename { get; set; }

        public override string ToString()
        {
            return Amount + " of " + Typename + " " + Width + "x" + Lenght;
        }
    }
}
