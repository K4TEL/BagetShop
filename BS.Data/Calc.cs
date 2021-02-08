using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagetShop.BS.Data
{
    public class Calc
    {
        public Order order;
        public DB db;

        public bool IsEnough()
            {
                foreach (KeyValuePair<Material, double> position in this.db.Storage)
                {
                    foreach (KeyValuePair<Material, double> needed in
                        this.order.Baget.BagetType.MatPerUnit)
                    {
                        if (position.Key == needed.Key)
                        {
                            Console.WriteLine((needed.Value * order.Amount).ToString() 
                                + " of " + position.Value.ToString() + " : " + 
                                position.Key.ToString());

                            if (position.Value * order.Amount < needed.Value)
                                {
                                    Console.WriteLine("Not Enough materials in stock");
                                    return false;
                                }
                        }
                    }
                }
            Console.WriteLine("Enough materials in stock");
            return true;
            }
        public Calc(DB db, BagetType bt, double w, double l, int a)
        {
            this.db = db;
            order = new Order(new Baget(w, l, bt), a);
        }

        public void PrintCalc()
        {
            Console.WriteLine(order);
            Console.WriteLine(IsEnough());
        }
    }
}
