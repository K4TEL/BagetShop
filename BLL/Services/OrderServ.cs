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
using System.Data.Entity.Infrastructure;

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
            Order order = database.OrderRep.Load(id);
            if (order == null)
                throw new InvalidOperationException("Can't find Order with ID " + id);
            return order.MapToModel();
        }

        public OrderModel Save(OrderModel orderDTO, bool isNew)
        {
            try { 
            if (isNew)
            {
                Order order = orderDTO.NewOrderEntity();
                database.OrderRep.Create(order);
                return Load(order.ID);
            }
            else
            {
                Order order = database.OrderRep.GetByID(orderDTO.ID);
                order.UpdateOrderCustomer(orderDTO);
                database.OrderRep.Update(order);
                return Load(order.ID);
            }
            }
            catch (DbUpdateException e)
            {
                string action = "update";
                if (isNew)
                    action = "create";
                throw NewDALException(orderDTO, action, e);
            }
        }

        public void Del(OrderModel orderDTO)
        {
            try
            {
                database.OrderRep.Delete(database.OrderRep.GetByID(orderDTO.ID));
            } 
            catch (DbUpdateException e)
            {
                throw NewDALException(orderDTO, "delete", e);
            }
        }

        public OrderModel AddBaget(OrderModel orderDTO, BagetModel bagetDTO)
        {
            try
            {
                Baget baget = bagetDTO.NewBagetEntity();
                database.BagetRep.Create(baget);
                return Load(orderDTO.ID);
            }
            catch (DbUpdateException e)
            {
                throw NewDALException(bagetDTO, "add", e);
            }
        }

        public bool IsEnough(Order order)
        {
            showMat = "";
            bool enough = true;


            foreach (Material mat in database.MatRep.Storage())
            {
                double present = mat.Amount;

                    foreach (Baget baget in order.Bagets)
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
            return enough;
        }

        public string showMaterials(OrderModel orderDTO)
        {
            bool enough = IsEnough(database.OrderRep.GetByID(orderDTO.ID));
            if (enough)
                showMat += "Enough";
            else
                showMat += "Not enough";
            return showMat;
        }

        public OrderModel DelBaget(OrderModel orderDTO, BagetModel bagetDTO)
        {
            try
            {
                database.BagetRep.Delete(database.BagetRep.GetByID(bagetDTO.ID));
                return Load(orderDTO.ID);
            } catch (DbUpdateException e)
            {
                throw NewDALException(bagetDTO, "delete", e);
            }
        }
        private DALException NewDALException(object model, string action, Exception inner)
        {
            string description = model.GetType().Name + " is incorrect! Unable to " + action + " " + model;
            return new DALException(description, inner);
        }
        //private Baget ReadBaget(BagetModel model)
        //{
        //    if (model == null)
        //        throw new ReadModelException("Empty BagetModel");
        //    Guid id = model.ID;
        //    if (id == null)
        //        throw new ReadModelException("Empty ID of BagetModel " + model);
        //    Baget baget = database.BagetRep.GetByID(id);
        //    if (baget == null)
        //        throw new ReadModelException("No Baget with such ID " + id);
        //    return baget;
        //}
        //private Order Read(OrderModel model)
        //{
        //    if (model == null)
        //        throw new ReadModelException("Empty OrderModel");
        //    Guid id = model.ID;
        //    if (id == null)
        //        throw new ReadModelException("Empty ID of OrderModel " + model);
        //    Order order = database.OrderRep.GetByID(id);
        //    if (order == null)
        //        throw new ReadModelException("No Order with such ID " + id);
        //    return order;
        //}


        //public ObservableCollection<BagetModel> LoadBagets(Guid id)
        //{
        //    return BagetMapper.MapToModelList(database.OrderRep.LoadBagets(Read(id).ID));
        //}

        //public ObservableCollection<OrderModel> GetAll()
        //{
        //    return OrderMapper.MapToModelList(database.OrderRep.GetAll());
        //}

        //private BagType ReadType(Guid id)
        //{
        //    if (id == null)
        //        throw new CustomException("No type id", "");
        //    BagType type = database.TypeRep.GetByID(id);
        //    if (type == null)
        //        throw new CustomException("No type with such id", "");
        //    return type;
        //}
        //private Order Read(Guid id)
        //{
        //    if (id == null)
        //        throw new CustomException("No order id", "");
        //    Order order = database.OrderRep.GetByID(id);
        //    if (order == null)
        //        throw new CustomException("No order with such id", "");
        //    return order;
        //}
    }
}
