using BagetShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = BagetShop.Model.Type;


namespace BagetShop.DAO.Impl
{
    public class MaterialRep : IMaterialRep
    {
        private DB Database;
        private List<Material> Materials;
        public MaterialRep(DB database)
        {
            this.Database = database;
            this.Materials = database.Materials;
        }
        public void AddMaterial(Type type, Material mat)
        {
            this.Database.Types.Find(t => t == type).Materials.Add(mat);
            mat.Type = type;
            Insert(mat);
        }

        public void AddMaterial(Type type, string name, double amo)
        {
            Material mat = new Material(name, amo, type);
            this.Database.Types.Find(t => t == type).Materials.Add(mat);
            Insert(mat);
        }

        public void Delete(Material entity)
        {
            this.Materials.Remove(entity);
        }

        public List<Material> GetAll()
        {
            return Materials;
        }

        public Material GetByID(Guid id)
        {
            return Materials.Find(m => m.ID == id);
        }

        public List<Material> GetStorage()
        {
            return Materials.Where(m => m.Storage).ToList();
        }

        public void Insert(Material entity)
        {
            this.Materials.Add(entity);
        }

        public void Update(Material entity)
        {
            Delete(entity);
            Insert(entity);
        }
    }
}
