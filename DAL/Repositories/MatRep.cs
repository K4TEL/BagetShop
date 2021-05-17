using DAL.EF;
using Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class MatRep : GenRep<Material>, IMatRep
    {
        BagetContext db;
        DbSet<Material> set;
        public MatRep(BagetContext context) : base(context)
        {
            this.db = context;
            this.set = context.Set<Material>();
        }
        public Material Load(Guid id)
        {
            return set
                .Include(m => m.Type)
                .FirstOrDefault(m => m.ID == id);
        }

        public IEnumerable<Material> LoadAll()
        {
            return set
                .Include(m => m.Type)
                .Where(m => !m.Storage)
                .ToList();
        }

        public BagType LoadType(Guid id)
        {
            return set
                .Include(m => m.Type)
                .FirstOrDefault(m => m.ID == id)
                .Type;
        }

        public IEnumerable<Material> Storage()
        {
            return set
                .AsNoTracking()
                .Where(m => m.Storage)
                .ToList();
        }
    }
}
