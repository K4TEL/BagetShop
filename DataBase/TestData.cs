using DAL.Interfaces;
using DAL.Model;
using DAL.Reposits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataBase
{
    public class TestData
    {
        private DB Database;
        public TestData(DB database)
        {
            this.Database = database;
            DBUnitOfWork uow = (DBUnitOfWork)database.GetUnitOfWork();

            Material mat1 = new Material("Glass", 10, Material.Units.m2, true);
            Material mat2 = new Material("Red Wood", 25, Material.Units.kg, true);
            Material mat3 = new Material("Silver", 700, Material.Units.g, true);
            Material mat4 = new Material("Gold", 500, Material.Units.g, true);

            BagType type1 = new BagType("Silver Glass");
            Material m1 = new Material("Glass", 2, type1);
            Material m2 = new Material("Silver", 200, type1);

            BagType type2 = new BagType("Red Wood");
            Material m3 = new Material("Glass", 1, type2);
            Material m4 = new Material("Red Wood", 2, type2);
            Material m5 = new Material("Gold", 150, type2);

            uow.TypeRep.Create(type1);
            uow.TypeRep.Create(type2);

            foreach (Material mat in new List<Material> { mat1, mat2, mat3, mat4, m1, m2, m3, m4, m5 })
            {
                uow.MatRep.Create(mat);
                if (!mat.Storage)
                    uow.MatRep.AddNew(mat.Type, mat);
            }
            Order o1 = new Order();
            o1.Customer = "John";

            uow.OrderRep.Create(o1);

            Baget b1 = new Baget(2, 0.25, 0.7, type2, o1);
            Baget b2 = new Baget(1, 0.5, 0.5, type1, o1);

            uow.BagetRep.Create(b1);
            uow.BagetRep.Create(b2);

            uow.BagetRep.AddNew(o1, b1);
            uow.BagetRep.AddNew(o1, b2);

            Order o2 = new Order();
            o2.Customer = "Mike";

            uow.OrderRep.Create(o2);

            Baget b3 = new Baget(4, 0.6, 0.6, type1, o2);
            Baget b4 = new Baget(1, 0.5, 0.5, type1, o2);

            uow.BagetRep.Create(b3);
            uow.BagetRep.Create(b4);

            uow.BagetRep.AddNew(o2, b4);
            uow.BagetRep.AddNew(o2, b3);

            Order o3 = new Order();
            o3.Customer = "Oliver";

            uow.OrderRep.Create(o3);

            Baget b5 = new Baget(1, 0.8, 0.4, type2, o3);

            uow.BagetRep.Create(b5);

            uow.BagetRep.AddNew(o3, b5);
        }
    }
}
