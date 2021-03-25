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
    public class MatRep : IRepManyToOne<BagType, Material>
    {
        private DB db;

        public MatRep(DB db)
        {
            this.db = db;
        }
        public void AddNew(BagType owner, Material item)
        {
            item.Type = owner;
            //Create(item);
            //db.Types.ToList().Find(t => t == owner).Materials.Add(item);
        }

        public void DelFrom(BagType owner, Material item)
        {
            //db.Types.ToList().Find(t => t == owner).Materials.Remove(item);
            Delete(item);
        }

        public void Create(Material entity)
        {
            if (!entity.Storage)
                entity.Unit = db.Materials.ToList().FirstOrDefault(m => m.Name == entity.Name).Unit;

            if (entity.Type != null)
                entity.TypeID = entity.Type.ID;

            db.Materials.Add(entity);
        }

        public void Delete(Material entity)
        {
            Material mat = db.Materials.ToList().Find(m => m.ID == entity.ID);
            if (mat != null)
                db.Materials.Remove(mat);
        }

        public ObservableCollection<Material> Find(Func<Material, bool> predicate)
        {
            return new ObservableCollection<Material>(db.Materials.Where(predicate));
        }

        public ObservableCollection<Material> GetAll()
        {
            return db.Materials;
        }

        public Material GetByID(Guid id)
        {
            return db.Materials.ToList().Find(m => m.ID == id);
        }

        public void Update(Material entity)
        {
            Delete(entity);
            Update(entity);
        }
    }
}
