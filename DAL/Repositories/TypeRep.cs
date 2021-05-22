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
    public class TypeRep : GenRep<BagType, Guid>, ITypeRep
    {
        BagetContext db;
        DbSet<BagType> set;
        public TypeRep(BagetContext context) : base(context)
        {
            this.db = context;
            this.set = context.Set<BagType>();
        }
        public BagType Load(Guid id)
        {
            BagType type = set
                .Include(t => t.Materials)
                .FirstOrDefault(t => t.ID == id);
            if (type == null)
                throw new Exception("Can't fount BagType with ID " + id);
            return type;
        }

        public IEnumerable<BagType> LoadAll()
        {
            return set
                .Include(t => t.Materials)
                .Where(t => t.Title != "Storage")
                .ToList();
        }

        //public IEnumerable<Material> LoadMaterials(Guid id)
        //{
        //    return set
        //        .Include(t => t.Materials)
        //        .FirstOrDefault(t => t.ID == id)
        //        .Materials;
        //}
    }
}
