using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagetShop
{
    public class DB
    {
        public Dictionary<Material, double> Storage = new Dictionary<Material, double>();
        public DB()
        {
            BagetType bt1 = new BagetType("Elite");
            bt1.MatPerUnit.Add(Material.Gold, 0.4);
            bt1.MatPerUnit.Add(Material.Glass, 0.5);
            bt1.MatPerUnit.Add(Material.Metal, 0.02);
            bt1.MatPerUnit.Add(Material.Gyps, 0.3);
            bt1.MatPerUnit.Add(Material.Lacker, 0.1);
            bt1.MatPerUnit.Add(Material.Paint, 0.4);

            BagetType bt2 = new BagetType("Cheap");
            bt2.MatPerUnit.Add(Material.Plastic, 0.6);
            bt2.MatPerUnit.Add(Material.Glass, 0.2);
            bt2.MatPerUnit.Add(Material.Metal, 0.01);
            bt2.MatPerUnit.Add(Material.Paint, 0.5);

            BagetType bt3 = new BagetType("Red Gold");
            bt3.MatPerUnit.Add(Material.RedWood, 0.6);
            bt3.MatPerUnit.Add(Material.Gold, 0.2);
            bt3.MatPerUnit.Add(Material.Glass, 0.2);
            bt3.MatPerUnit.Add(Material.Metal, 0.01);
            bt3.MatPerUnit.Add(Material.Lacker, 0.1);

            BagetType bt4 = new BagetType("Silver Dragon");
            bt4.MatPerUnit.Add(Material.Silver, 0.6);
            bt4.MatPerUnit.Add(Material.Glass, 0.4);
            bt4.MatPerUnit.Add(Material.Metal, 0.01);

            foreach(Material mat in Enum.GetValues(typeof(Material)))
            {
                Storage.Add(mat, 10);
            }
        }
    }
}
