using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class DbInitializer : DropCreateDatabaseAlways<BagetContext>
    {
        protected override void Seed(BagetContext context)
        {
            Console.WriteLine("Generating Test Data");

            Material mat1 = new Material("Glass", 10, Material.Units.m2, true);
            Material mat2 = new Material("Red Wood", 25, Material.Units.kg, true);
            Material mat3 = new Material("Silver", 700, Material.Units.g, true);
            Material mat4 = new Material("Gold", 500, Material.Units.g, true);

            BagType strg = new BagType("Storage");
            context.Types.Add(strg);
            var storage = new List<Material> { mat1, mat2, mat3, mat4 };

            foreach (Material mat in storage)
            {
                mat.Type = strg;
                context.Materials.Add(mat);
            }

            BagType type1 = new BagType("Silver Glass");
            Material m1 = new Material("Glass", 2, type1.ID);
            Material m2 = new Material("Silver", 200, type1.ID);

            BagType type2 = new BagType("Red Wood");
            Material m3 = new Material("Glass", 1, type2);
            Material m4 = new Material("Red Wood", 2, type2);
            Material m5 = new Material("Gold", 150, type2);

            context.Types.Add(type1);
            context.Types.Add(type2);

            foreach (Material mat in new List<Material> { m1, m2, m3, m4, m5 })
            {
                Material s = storage.FirstOrDefault(m => m.Name == mat.Name);
                if (s != null)
                    mat.Unit = s.Unit;
                else
                    Console.WriteLine("Units unset");

                context.Materials.Add(mat);
            }
            Order o1 = new Order("John");

            context.Orders.Add(o1);

            Baget b1 = new Baget(2, 0.25, 0.7, type2.ID, o1.ID);
            Baget b2 = new Baget(1, 0.5, 0.5, type1.ID, o1.ID);

            context.Bagets.Add(b1);
            context.Bagets.Add(b2);

            Order o2 = new Order("Mike");

            context.Orders.Add(o2);

            Baget b3 = new Baget(4, 0.6, 0.6, type1, o2);
            Baget b4 = new Baget(1, 0.5, 0.5, type1, o2);

            context.Bagets.Add(b3);
            context.Bagets.Add(b4);

            Order o3 = new Order("Oliver");

            context.Orders.Add(o3);

            Baget b5 = new Baget(1, 0.8, 0.4, type2, o3);

            context.Bagets.Add(b5);
            context.SaveChanges();
        }
    }
}
