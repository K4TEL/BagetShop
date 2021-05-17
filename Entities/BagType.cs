using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BagType
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public string Title { get; set; }
        public List<Material> Materials { get; set; }
        public virtual List<Baget> Bagets { get; set; }

        private BagType() { }
        public BagType(string title)
        {
            this.ID = Guid.NewGuid();
            this.Title = title;
            this.Materials = new List<Material>();
            this.Bagets = new List<Baget>();
        }
    }
}
