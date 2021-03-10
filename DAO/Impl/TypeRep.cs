using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = BagetShop.Model.Type;


namespace BagetShop.DAO.Impl
{
    public class TypeRep : ITypeRep
    {
        private DB Database;
        private List<Type> Types;
        public TypeRep(DB database)
        {
            this.Database = database;
            this.Types = database.Types;
        }
        public void Delete(Type entity)
        {
            this.Types.Remove(entity);
        }

        public List<Type> GetAll()
        {
            return Types;
        }

        public Type GetByID(Guid id)
        {
            return Types.Find(t => t.ID == id);
        }

        public Type GetByName(string name)
        {
            return Types.Find(t => t.Title == name);
        }

        public void Insert(Type entity)
        {
            this.Types.Add(entity);
        }

        public void Update(Type entity)
        {
            Delete(entity);
            Insert(entity);
        }
    }
}
