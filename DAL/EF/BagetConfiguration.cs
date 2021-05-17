using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class BagetConfiguration : EntityTypeConfiguration<Baget>
    {
        public BagetConfiguration()
        {
            ToTable("Bagets").HasKey(o => o.ID);
        }
    }
}
