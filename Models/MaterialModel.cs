using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MaterialModel
    {
        public Guid ID { get; set; }
        public string Amount { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public Guid TypeID { get; set; }

        public override string ToString()
        {
            return Amount + " " + Unit + " of " + Name;
        }
    }
}
