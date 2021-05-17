using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class TypeConfiguration : EntityTypeConfiguration<BagType>
    {
        public TypeConfiguration()
        {
            ToTable("Types").HasKey(o => o.ID);

            HasMany(e => e.Materials).WithRequired(o => o.Type).HasForeignKey(m => m.Type_ID);

            HasMany(e => e.Bagets).WithRequired(o => o.Type).HasForeignKey(b => b.Type_ID);

            Property(t => t.Title).HasMaxLength(20);
        }
    }
}
