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
    public class BagetRep : GenRep<Baget>, IBagetRep
    {
        BagetContext db;
        DbSet<Baget> set;
        public BagetRep(BagetContext context) : base(context)
        {
            this.db = context;
            this.set = context.Set<Baget>();
        }

        public Order LoadOrder(Guid id)
        {
            return set
                .Include(b => b.Order)
                .FirstOrDefault(b => b.ID == id)
                .Order;
        }

        public BagType LoadType(Guid id)
        {
            return set
                .Include(b => b.Type)
                .FirstOrDefault(b => b.ID == id)
                .Type;
        }

        Baget IBagetRep.Load(Guid id)
        {
            return set
                .Include(b => b.Order)
                .Include(b => b.Type)
                .FirstOrDefault(b => b.ID == id);
        }

        IEnumerable<Baget> IBagetRep.LoadAll()
        {
            return set
                .Include(b => b.Order)
                .Include(b => b.Type)
                .ToList();
        }
    }
}
