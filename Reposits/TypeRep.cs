using DAL.DataBase;
using DAL.Interfaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Reposits
{
    public class TypeRep : IRepository<BagType>
    {
        private DB db;

        public TypeRep(DB db)
        {
            this.db = db;
        }
        public void Create(BagType entity)
        {
            db.Types.Add(entity);
        }

        public void Delete(BagType entity)
        {
            BagType type = db.Types.ToList().Find(t => t.ID == entity.ID);
            if (type != null)
                db.Types.Remove(type);
        }

        public ObservableCollection<BagType> Find(Func<BagType, bool> predicate)
        {
            return new ObservableCollection<BagType>(db.Types.Where(predicate));
        }

        public ObservableCollection<BagType> GetAll()
        {
            return db.Types;
        }

        public BagType GetByID(Guid id)
        {
            return db.Types.ToList().Find(t => t.ID == id);
        }

        public void Update(BagType entity)
        {
            Delete(entity);
            Create(entity);
        }
    }
}
