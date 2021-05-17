using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class BagetContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Baget> Bagets { get; set; }
        public DbSet<BagType> Types { get; set; }
        public DbSet<Material> Materials { get; set; }

        static BagetContext()
        {
            Database.SetInitializer<BagetContext>(new DbInitializer());
        }
        public BagetContext(string connectionString) : base(connectionString) { }

        public BagetContext() : base("DefaultConnection") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new BagetConfiguration());
            modelBuilder.Configurations.Add(new MaterialConfiguration());
            modelBuilder.Configurations.Add(new TypeConfiguration());

            base.OnModelCreating(modelBuilder);
        } 
    }
}
