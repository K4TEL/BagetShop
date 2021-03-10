using BagetShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = BagetShop.Model.Type;

namespace BagetShop.DAO.Impl
{
    public class TestData
    {
        private DB Database;
        public TestData(DB database)
        {
            this.Database = database;
            UnitOfWork uow = (UnitOfWork)database.GetUnitOfWork();

            Material mat1 = new Material("Glass", 10, Material.Units.m2, true);
            Material mat2 = new Material("Red Wood", 25, Material.Units.kg, true);
            Material mat3 = new Material("Silver", 700, Material.Units.g, true);
            Material mat4 = new Material("Gold", 500, Material.Units.g, true);
            
            Type type1 = new Type("Silver Glass");
            Material m1 = new Material("Glass", 1, type1);
            Material m2 = new Material("Silver", 200, type1);
            type1.Materials.AddRange(new List<Material>() { m1, m2});

            Type type2 = new Type("Red Wood");
            Material m3 = new Material("Glass", 1, type1);
            Material m4 = new Material("Red Wood", 2, type1);
            Material m5 = new Material("Gold", 150, type1);
            type2.Materials.AddRange(new List<Material>() { m3, m4, m5 });

            uow.GetTypeRep().Insert(type1);
            uow.GetTypeRep().Insert(type2);

            foreach (Material mat in new List<Material> { mat1, mat2, mat3, mat4, m1, m2, m3, m4, m5})
            {
                if (mat.Storage)
                    uow.GetMaterialRep().Insert(mat);
                else
                    uow.GetMaterialRep().AddMaterial(mat.Type, mat);
            }

        }
    }
}
