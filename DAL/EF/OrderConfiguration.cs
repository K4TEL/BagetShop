using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            ToTable("Orders").HasKey(o => o.ID);

            Property(o => o.Customer).HasMaxLength(100);

            HasMany(o => o.Bagets).WithRequired(b => b.Order).HasForeignKey(b => b.Order_ID);
        }
    }
}
