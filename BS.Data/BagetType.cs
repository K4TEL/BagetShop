using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagetShop
{
    public class BagetType : Base<BagetType>
    {
        public string Title { get; set; }

        public Dictionary<Material, Double> MatPerUnit = new Dictionary<Material, double>();

        public BagetType(string title) : base()
        {
            this.Title = title;
        }

        static public BagetType getByName(string title)
        {
            return Objects.Where(bt => bt.Title == title).FirstOrDefault();
        }

        public override string ToString()
        {
            return this.Title;
        }
    }

    public enum Material
    {
        BlackWood,
        RedWood,
        WhiteWood,
        Plastic,
        Metal,
        Silver,
        Gold,
        Copper,
        Bronze,
        Bread,
        Lacker,
        Paint,
        Glass,
        Textile,
        Gyps
    }
}
