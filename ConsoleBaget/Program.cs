using BLL.Infrastructure;
using BLL.Interfaces;
using Models;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBaget
{
    class Program
    {
        static ITypeServ typeServ;
        static IOrderServ orderServ;
        static IBagetServ bagetServ;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, user!");
            try
            {
                StandardKernel kernel = new StandardKernel(new ServiceModule());
                kernel.Load(Assembly.GetExecutingAssembly());

                typeServ = kernel.Get<ITypeServ>();
                orderServ = kernel.Get<IOrderServ>();
                bagetServ = kernel.Get<IBagetServ>();
            }
            catch
            {
                Console.WriteLine("Dependencies error");
                Environment.Exit(0);
            }
            Console.WriteLine("Connecting to DB");
            OrderModel test = orderServ.LoadAll()[0];
            try
            {
                //OrderModel test = orderServ.LoadAll()[0];
            }
            catch
            {
                Console.WriteLine("Database error");
                Environment.Exit(0);
            }
            Menu();
        }
        static void Test()
        {
            Console.WriteLine("================================= ORDERS");

            Console.WriteLine("All orders " + orderServ.LoadAll().Count);
            foreach (OrderModel o in orderServ.LoadAll())
            {
                Console.WriteLine("-Order " + o);
                foreach (BagetModel b in o.Bagets)
                    Console.WriteLine("--Baget " + b);
            }
            Console.WriteLine("================================= BAGETS");

            Console.WriteLine("All bagets " + bagetServ.LoadAll().Count);
            foreach (BagetModel o in bagetServ.LoadAll())
                Console.WriteLine("-Baget " + o);
            Console.WriteLine("================================= TYPES");

            Console.WriteLine("All types " + typeServ.LoadAll().Count);
            foreach (TypeModel o in typeServ.LoadAll())
            {
                Console.WriteLine("-Type " + o);
                foreach (MaterialModel m in o.Materials)
                    Console.WriteLine("--Material " + m);
            }

            Console.WriteLine("================================= ORDER CHANGES");

            OrderModel order = orderServ.LoadAll().ToList()[0];
            Console.WriteLine("Order " + order);
            Console.WriteLine(orderServ.showMaterials(order));

            order.Customer = "Jimmy";
            order = orderServ.Save(order, false);
            Console.WriteLine("Order changed " + order);

            Console.WriteLine("================================= BAGET NEW");

            Console.WriteLine("All bagets " + bagetServ.LoadAll().Count);

            BagetModel baget = new BagetModel();
            baget.OrderID = order.ID;
            baget.Lenght = "5,77";
            baget.Width = "5,5";
            baget.Amount = "5";
            baget.TypeID = typeServ.LoadAll()[0].ID;

            Console.WriteLine("Baget " + baget);
            baget = bagetServ.Save(baget, true);
            Console.WriteLine("Baget changed and saved " + baget);

            Console.WriteLine("All bagets " + bagetServ.LoadAll().Count);

            baget = bagetServ.Load(baget.ID);
            Console.WriteLine("Baget get by ID " + baget);

            Console.WriteLine("================================= ORDER NEW");

            Console.WriteLine("All orders " + orderServ.LoadAll().Count);

            order = new OrderModel();
            order.Customer = "Daria";
            order = orderServ.Save(order, true);
            Console.WriteLine("Order saved " + order);

            Console.WriteLine("All orders " + orderServ.LoadAll().Count);

            baget = new BagetModel();
            baget.OrderID = order.ID;
            baget.Lenght = "7,8";
            baget.Width = "5,59";
            baget.Amount = "6";
            baget.TypeID = typeServ.LoadAll()[1].ID;
            order = orderServ.AddBaget(order, baget);
            Console.WriteLine("Baget added to Order " + order);

            order = orderServ.Load(order.ID);
            Console.WriteLine("Order get by ID " + order);

            Console.WriteLine("================================= BAGET CHANGES AND DEL");

            baget = order.Bagets[0];
            Console.WriteLine("Baget in order " + baget);
            baget.Amount = "7";
            baget.TypeID = typeServ.LoadAll()[0].ID;
            Console.WriteLine("Baget changed " + baget);

            Console.WriteLine("All bagets " + bagetServ.LoadAll().Count);

            baget = bagetServ.Save(baget, false);
            Console.WriteLine("Baget changed and saved " + baget);

            order = orderServ.Load(order.ID);
            Console.WriteLine("Order get by ID " + order);
            Console.WriteLine("Baget in order " + order.Bagets[0]);

            Console.WriteLine("All bagets " + bagetServ.LoadAll().Count);

            order = orderServ.DelBaget(order, baget);
            Console.WriteLine("Baget deleted from Order " + order);

            Console.WriteLine("All bagets " + bagetServ.LoadAll().Count);
            order = orderServ.Load(order.ID);
            Console.WriteLine("Order get by ID " + order);

            Console.WriteLine("================================= ORDER DEL");

            Console.WriteLine("All orders " + orderServ.LoadAll().Count);

            orderServ.Del(order);
            Console.WriteLine("Order deleted");

            Console.WriteLine("All orders " + orderServ.LoadAll().Count);
            Console.WriteLine("All bagets " + bagetServ.LoadAll().Count);

            order = orderServ.LoadAll()[0];
            orderServ.Del(order);
            Console.WriteLine("Order with bagets deleted");

            Console.WriteLine("All orders " + orderServ.LoadAll().Count);
            Console.WriteLine("All bagets " + bagetServ.LoadAll().Count);
        }
        static void GetAll(string type)
        {
            switch (type)
            {
                case "0":
                    Console.WriteLine("================================= ORDERS");

                    Console.WriteLine("All orders " + orderServ.LoadAll().Count);
                    foreach (OrderModel o in orderServ.LoadAll())
                    {
                        Console.WriteLine("-Order " + o);
                        foreach (BagetModel b in o.Bagets)
                            Console.WriteLine("--Baget " + b);
                    }
                    Console.WriteLine("================================= BAGETS");

                    Console.WriteLine("All bagets " + bagetServ.LoadAll().Count);
                    foreach (BagetModel o in bagetServ.LoadAll())
                        Console.WriteLine("-Baget " + o);
                    Console.WriteLine("================================= TYPES");

                    Console.WriteLine("All types " + typeServ.LoadAll().Count);
                    foreach (TypeModel o in typeServ.LoadAll())
                    {
                        Console.WriteLine("-Type " + o);
                        foreach (MaterialModel m in o.Materials)
                            Console.WriteLine("--Material " + m);
                    }
                    break;
                case "1":
                    Console.WriteLine("================================= ORDERS");
                    int count = orderServ.LoadAll().Count;
                    for (int i = 0; i < count; i++)
                    {
                        OrderModel order = orderServ.LoadAll()[i];
                        Console.WriteLine(i + " - Order " + order);
                        for (int j = 0; j < order.Bagets.Count; j++)
                            Console.WriteLine(i + "-" + j + " - Baget " + order.Bagets[j]);
                    }
                    break;
                case "2":
                    Console.WriteLine("================================= BAGETS");

                    count = bagetServ.LoadAll().Count;
                    for (int i = 0; i < count; i++)
                        Console.WriteLine(i + " - Baget " + bagetServ.LoadAll()[i]);
                    break;
                case "3":
                    Console.WriteLine("================================= TYPES");
                    count = typeServ.LoadAll().Count;
                    for (int i = 0; i < count; i++)
                    {
                        TypeModel bagtype = typeServ.LoadAll()[i];
                        Console.WriteLine(i + " - Type " + bagtype);
                        for (int j = 0; j < bagtype.Materials.Count; j++)
                            Console.WriteLine(i + "-" + j + " - Material " + bagtype.Materials[j]);
                    }
                    break;
                case "4":
                    Menu();
                    break;
                default:
                    Console.WriteLine("??? Unknown command ???");
                    break;
            }
        }
        static void Get(string type)
        {
            GetAll(type);
            switch (type)
            {
                case "1":
                    Console.WriteLine("Index of Order");
                    string id = Console.ReadLine();
                    try
                    {
                        OrderModel order = orderServ.LoadAll()[int.Parse(id)];
                        Console.WriteLine("Order " + order);
                        for (int i = 0; i < order.Bagets.Count; i++)
                            Console.WriteLine(i + " - Baget " + order.Bagets[i]);
                        Order(order);
                    }
                    catch { Console.WriteLine("XXX Order not found XXX"); }
                    break;
                case "2":
                    Console.WriteLine("Index of Baget"); ;
                    id = Console.ReadLine();
                    try
                    {
                        BagetModel baget = bagetServ.LoadAll().ToList()[int.Parse(id)];
                        Console.WriteLine("Baget " + baget);
                        Baget(baget);
                    }
                    catch { Console.WriteLine("XXX Baget not found XXX"); }
                    break;
                case "3":
                    Console.WriteLine("Index of Type");
                    id = Console.ReadLine();
                    try
                    {
                        TypeModel bagtype = typeServ.LoadAll().ToList()[int.Parse(id)];
                        Console.WriteLine("Type " + bagtype);
                        foreach (MaterialModel m in bagtype.Materials)
                            Console.WriteLine("-Material " + m);
                    }
                    catch { Console.WriteLine("XXX Type not found XXX"); }
                    break;
                case "4":
                    Menu();
                    break;
                default:
                    Console.WriteLine("??? Unknown command ???");
                    break;
            }
        }
        static void Baget(BagetModel baget)
        {
            Console.WriteLine("================================= BAGET MENU");
            Console.WriteLine("1 - Edit");
            Console.WriteLine("2 - Del");
            Console.WriteLine("3 - Back to Order");
            string command = Console.ReadLine();

            switch (command)
            {
                case "1":
                    BagetEdit(baget, false);
                    break;
                case "2":
                    OrderModel order = orderServ.Load(baget.OrderID);
                    order = orderServ.DelBaget(order, baget);
                    Console.WriteLine("Baget deleted " + order);
                    break;
                case "3":
                    order = orderServ.Load(baget.OrderID);
                    Console.WriteLine("Order " + order);
                    for (int i = 0; i < order.Bagets.Count; i++)
                        Console.WriteLine(i + " - Baget " + order.Bagets[i]);
                    Order(order);
                    break;
                default:
                    Console.WriteLine("??? Unknown command ???");
                    break;
            }
        }
        static void Order(OrderModel order)
        {
            Console.WriteLine("================================= ORDER MENU");
            Console.WriteLine("0 - Calculate");
            Console.WriteLine("1 - Edit");
            Console.WriteLine("2 - Del");
            Console.WriteLine("3 - Add Baget");
            if (order.Bagets.Count > 0)
                Console.WriteLine("4 - Get Baget");
            Console.WriteLine("5 - Back");

            string command = Console.ReadLine();

            switch (command)
            {
                case "0":
                    Console.WriteLine(orderServ.showMaterials(order));
                    break;
                case "1":
                    Console.WriteLine("================================= EDIT ORDER");
                    OrderEdit(order, false);
                    break;
                case "2":
                    orderServ.Del(order);
                    Console.WriteLine("Order deleted");
                    break;
                case "3":
                    Console.WriteLine("================================= NEW BAGET");
                    BagetModel baget = new BagetModel();
                    baget.OrderID = order.ID;
                    BagetEdit(baget, true);
                    break;
                case "4":
                    for (int i = 0; i < order.Bagets.Count; i++)
                        Console.WriteLine(i + " - Baget " + order.Bagets[i]);
                    Console.WriteLine("Index of Baget");
                    string id = Console.ReadLine();
                    try
                    {
                        baget = order.Bagets[int.Parse(id)];
                        Console.WriteLine("Baget " + baget);
                        Baget(baget);
                    }
                    catch { Console.WriteLine("XXX Baget not found XXX"); }
                    break;
                case "5":
                    Menu();
                    break;
                default:
                    Console.WriteLine("??? Unknown command ???");
                    break;
            }
        }
        static void BagetEdit(BagetModel baget, bool isNew)
        {
            Console.WriteLine("Type " + baget.Typename);
            for (int i = 0; i < typeServ.LoadAll().Count; i++)
                Console.WriteLine(i + " - Type " + typeServ.LoadAll()[i]);
            string value = Console.ReadLine();
            if (value == "")
                baget.TypeID = isNew ? typeServ.LoadAll()[0].ID : baget.TypeID;
            else
            {
                try
                {
                    TypeModel bagtype = typeServ.LoadAll()[int.Parse(value)];
                    baget.TypeID = bagtype.ID;
                }
                catch
                {
                    Console.WriteLine("XXX Type not found XXX");
                    return;
                }
            }

            Console.WriteLine("Width " + baget.Width);
            value = Console.ReadLine();
            if (value == "")
                baget.Width = isNew ? "0" : baget.Width;
            else
                baget.Width = value;
            Console.WriteLine("Lenght " + baget.Lenght);
            value = Console.ReadLine();
            if (value == "")
                baget.Lenght = isNew ? "0" : baget.Lenght;
            else
                baget.Lenght = value;
            Console.WriteLine("Amount " + baget.Amount);
            value = Console.ReadLine();
            if (value == "")
                baget.Amount = isNew ? "0" : baget.Amount;
            else
                baget.Amount = value;
            try
            {
                baget = bagetServ.Save(baget, isNew);
                Console.WriteLine("Baget saved " + baget);
            }
            catch { Console.WriteLine("XXX Baget not saved XXX"); }
        }
        static void OrderEdit(OrderModel order, bool isNew)
        {
            Console.WriteLine("Customer " + order.Customer);
            string value = Console.ReadLine();
            if (value == "")
                order.Customer = isNew ? "???" : order.Customer;
            else
                order.Customer = value;
            try
            {
                order = orderServ.Save(order, isNew);
                Console.WriteLine("Order saved " + order);
            }
            catch { Console.WriteLine("XXX Order not saved XXX"); }
        }
        static void Menu()
        {
            while (true)
            {
                Console.WriteLine("================================= MENU");
                Console.WriteLine("0 - Test");
                Console.WriteLine("1 - Get All");
                Console.WriteLine("2 - Get");
                Console.WriteLine("3 - New Order");
                Console.WriteLine("4 - Exit");

                string command = Console.ReadLine();

                switch (command)
                {
                    case "0":
                        Console.WriteLine("================================= TEST");
                        Test();
                        break;
                    case "1":
                        Console.WriteLine("================================= GET ALL MENU");
                        Console.WriteLine("0 - All");
                        Console.WriteLine("1 - Orders");
                        Console.WriteLine("2 - Bagets");
                        Console.WriteLine("3 - Types");
                        Console.WriteLine("4 - Back");
                        command = Console.ReadLine();
                        GetAll(command);
                        break;
                    case "2":
                        Console.WriteLine("================================= GET MENU");
                        Console.WriteLine("1 - Order");
                        Console.WriteLine("2 - Baget");
                        Console.WriteLine("3 - Type");
                        Console.WriteLine("4 - Back");
                        command = Console.ReadLine();
                        Get(command);
                        break;
                    case "3":
                        Console.WriteLine("================================= NEW ORDER");
                        OrderEdit(new OrderModel(), true);
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("??? Unknown command ???");
                        break;
                }
            }
        }
    }
}
