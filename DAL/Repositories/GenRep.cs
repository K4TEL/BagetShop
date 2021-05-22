using DAL.EF;
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
    public class GenRep<T, Key> : IGenRep<T, Key> where T : class
    {
        BagetContext db;
        DbSet<T> set;

        public GenRep(BagetContext context)
        {
            this.db = context;
            this.set = context.Set<T>();
        }
        public virtual void Create(T entity)
        {
            set.Add(entity);
            db.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            set.Remove(entity);
            db.SaveChanges();
        }

        //public IEnumerable<T> Find(Func<T, bool> predicate)
        //{
        //    return set.AsNoTracking().Where(predicate).ToList();
        //}

        public IEnumerable<T> GetAll()
        {
            return set.AsNoTracking().ToList();
        }

        public virtual T GetByID(Key id)
        {
            return set.Find(id);
        }

        public virtual void Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        //private IQueryable<T> Include(params Expression<Func<T, object>>[] includeProperties)
        //{
        //    IQueryable<T> query = set.AsNoTracking();
        //    return includeProperties
        //        .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        //}

        //public virtual IEnumerable<T> GetAllInclude(params Expression<Func<T, object>>[] includeProperties)
        //{
        //    return Include(includeProperties).ToList();
        //}

        //public virtual IEnumerable<T> FindInclude(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties)
        //{
        //    var query = Include(includeProperties);
        //    return query.Where(predicate).ToList();
        //}
    }
}
