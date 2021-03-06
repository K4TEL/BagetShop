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
    public class Material : BaseEntity<Guid>
    {
        public double Amount { get; set; }
        public string Name { get; set; }
        public bool Storage { get; set; }
        public Units Unit { get; set; }
        public Guid Type_ID { get; set; }
        public BagType Type { get; set; }

        private Material() { }
        public Material(string name, double amo, Units unit, bool storage)
        {
            ID = Guid.NewGuid();
            this.Name = name;
            this.Amount = amo;
            this.Unit = unit;
            this.Storage = storage;
        }

        public Material(string name, double amo, BagType type)
        {
            ID = Guid.NewGuid();
            this.Name = name;
            this.Amount = amo;
            this.Type = type;
            this.Storage = false;
        }

        public Material(string name, double amo, Guid typeID)
        {
            ID = Guid.NewGuid();
            this.Name = name;
            this.Amount = amo;
            this.Type_ID = typeID;
            this.Storage = false;
        }

        public enum Units
        {
            ml,
            kg,
            g,
            mg,
            cm2,
            m2
        }
    }
}
