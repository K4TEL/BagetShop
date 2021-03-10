using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagetShop.Model
{
    public class Material
    {
        public Guid ID { get; set; }
        public double Amount { get; set; }
        public string Name { get; set; }
        public bool Storage { get; set; }
        public Units Unit { get; set; }
        public Type Type { get; set; }

        public Material() { this.ID = Guid.NewGuid(); }
        public Material(string name, double amo, Units unit, bool storage)
        {
            this.ID = Guid.NewGuid();
            this.Name = name;
            this.Amount = amo;
            this.Unit = unit;
            this.Storage = storage;
        }

        public Material(string name, double amo, Type type)
        {
            this.ID = Guid.NewGuid();
            this.Name = name;
            this.Amount = amo;
            this.Type = type;
            this.Storage = false;
        }

        public override string ToString()
        {
            return this.Amount + " " + this.Name;
        }

        public enum Units
        {
            kg,
            g,
            mg,
            cm2,
            m2
        }
    }
}
