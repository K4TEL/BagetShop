using DAL.EF;
using Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class OrderRep : GenRep<Order, Guid>, IOrderRep
    {
        BagetContext db;
        DbSet<Order> set;
        public OrderRep(BagetContext context) : base(context)
        {
            this.db = context;
            this.set = context.Set<Order>();
        }

        public Order Load(Guid id)
        {
            return set
                .Include(o => o.Bagets
                .Select(b => b.Type))
                .FirstOrDefault(e => e.ID == id);
        }

        public IEnumerable<Order> LoadAll()
        {
            return set
                .Include(o => o.Bagets
                .Select(b => b.Type))
                .ToList();
        }

        public IEnumerable<Baget> LoadBagets(Guid id)
        {
            return set
                .Include(o => o.Bagets
                .Select(b => b.Type)
                .Select(t => t.Materials))
                .FirstOrDefault(e => e.ID == id)
                .Bagets;
        }
    }
}
