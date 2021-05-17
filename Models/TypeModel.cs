using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TypeModel
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public ObservableCollection<MaterialModel> Materials { get; set; }

        public override string ToString()
        {
            return Title + " materials: " + Materials.Count;
        }
    }
}
