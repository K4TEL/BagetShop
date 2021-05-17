using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mappers;
using Models;

namespace BLL.Services
{
    public class OrderServ : IOrderServ
    {
        private String showMat;
        IUnitOfWork database { get; set; }
        public OrderServ(IUnitOfWork uow)
        {
            this.database = uow;
        }
        
        public ObservableCollection<OrderModel> LoadAll()
        {
            return database.OrderRep.LoadAll().MapToModelList();
        }

        public OrderModel Load(Guid id)
        {
            return database.OrderRep.Load(Read(id).ID).MapToModel();
        }

        public OrderModel Save(OrderModel orderDTO, bool isNew)
        {
            if (isNew)
            {
                if (orderDTO == null)
                    throw new ValidationException("No order model", "");
                Order order = orderDTO.NewOrderEntity();
                database.OrderRep.Create(order);
                return Load(order.ID);
            }
            else
            {
                Order order = Read(orderDTO);
                order.UpdateOrderCustomer(orderDTO);
                database.OrderRep.Update(order);
                return Load(order.ID);
            }
        }

        public void Del(OrderModel orderDTO)
        {
            database.OrderRep.Delete(Read(orderDTO));
        }

        public OrderModel AddBaget(OrderModel orderDTO, BagetModel bagetDTO)
        {
            if (bagetDTO == null)
                throw new ValidationException("No baget model", "");

            BagType type = ReadType(bagetDTO.TypeID);

            Baget baget = bagetDTO.NewBagetEntity();

            database.BagetRep.Create(baget);
            return Load(Read(orderDTO).ID);
        }

        public bool IsEnough(OrderModel orderDTO)
        {
            showMat = "";
            bool enough = true;

            foreach (Material mat in database.MatRep.Storage())
            {
                double present = mat.Amount;
                foreach (Baget baget in database.OrderRep.LoadBagets(Read(orderDTO).ID))
                {
                    foreach (Material needed in baget.Type.Materials)
                        if (needed.Name == mat.Name)
                            present -= baget.Amount * needed.Amount *
                                baget.Width * baget.Lenght;
                }

                if (present > 0)
                {
                    string matString = present + " " + mat.Unit.ToString() +
                        " of " + mat.Amount + " " + mat.Name + " left";
                    showMat += matString + "\n";
                }
                else
                {
                    enough = false;
                    string matString = "Lacks " + Math.Abs(present) + 
                        " " + mat.Unit.ToString() + " of " + mat.Amount + " " + mat.Name;
                    showMat += matString + "\n";
                }
            }
            database.Save();
            return enough;
        }

        public string showMaterials(OrderModel orderDTO)
        {
            bool enough = IsEnough(orderDTO);
            if (enough)
                showMat += "Enough";
            else
                showMat += "Not enough";
            return showMat;
        }

        public OrderModel DelBaget(OrderModel orderDTO, BagetModel bagetDTO)
        {
            database.BagetRep.Delete(ReadBaget(bagetDTO));
            return Load(Read(orderDTO).ID);
        }

        //public ObservableCollection<BagetModel> LoadBagets(Guid id)
        //{
        //    return BagetMapper.MapToModelList(database.OrderRep.LoadBagets(Read(id).ID));
        //}

        //public ObservableCollection<OrderModel> GetAll()
        //{
        //    return OrderMapper.MapToModelList(database.OrderRep.GetAll());
        //}

        private BagType ReadType(Guid id)
        {
            if (id == null)
                throw new ValidationException("No type id", "");
            BagType type = database.TypeRep.GetByID(id);
            if (type == null)
                throw new ValidationException("No type with such id", "");
            return type;
        }
        private Baget ReadBaget(BagetModel model)
        {
            if (model == null)
                throw new ValidationException("No baget model", "");
            Guid id = model.ID;
            if (id == null)
                throw new ValidationException("No baget id", "");
            Baget baget = database.BagetRep.GetByID(id);
            if (baget == null)
                throw new ValidationException("No baget with such id", "");
            return baget;
        }
        private Order Read(Guid id)
        {
            if (id == null)
                throw new ValidationException("No order id", "");
            Order order = database.OrderRep.GetByID(id);
            if (order == null)
                throw new ValidationException("No order with such id", "");
            return order;
        }

        private Order Read(OrderModel model)
        {
            if (model == null)
                throw new ValidationException("No order model", "");
            Guid id = model.ID;
            if (id == null)
                throw new ValidationException("No order id", "");
            Order order = database.OrderRep.GetByID(id);
            if (order == null)
                throw new ValidationException("No order with such id", "");
            return order;
        }
    }
}
