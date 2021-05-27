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
using Models;
using Mappers;
using System.Data.Entity.Infrastructure;

namespace BLL.Services
{
    public class BagetServ : IBagetServ
    {
        IUnitOfWork database { get; set; }
        public BagetServ(IUnitOfWork uow)
        {
            this.database = uow;
        }
        public ObservableCollection<BagetModel> LoadAll()
        {
            return database.BagetRep.LoadAll().MapToModelList();
        }

        public BagetModel Load(Guid id)
        {
            Baget baget = database.BagetRep.Load(id);
            if (baget == null)
                throw new InvalidOperationException("Can't find Baget with ID " + id);
            return baget.MapToModel();
        }

        public BagetModel Save(BagetModel bagetDTO, bool isNew)
        {
            try
            {
                if (isNew)
                {
                    Baget baget = bagetDTO.NewBagetEntity();
                    database.BagetRep.Create(baget);
                    return Load(baget.ID);
                }
                else
                {
                    Baget baget = database.BagetRep.GetByID(bagetDTO.ID);
                    baget.UpdateBagetEntity(bagetDTO);
                    //baget.ID = Guid.NewGuid();
                    //baget.Order = database.OrderRep.GetAll().ElementAt(2);
                    database.BagetRep.Update(baget);
                    return Load(baget.ID);
                }
            } 
            catch (DbUpdateException e)
            {
                string action = "update";
                if (isNew)
                    action = "create";
                throw NewDALException(bagetDTO, action, e);
            } 
        }

        public void Del(BagetModel bagetDTO)
        {
            try
            {
                database.BagetRep.Delete(database.BagetRep.GetByID(bagetDTO.ID));
            }
            catch (DbUpdateException e)
            {
                throw NewDALException(bagetDTO, "delete", e);
            }
        }

        public TypeModel LoadType(Guid id)
        {
            return database.BagetRep.LoadType(id).MapToModel();
        }

        private DALException NewDALException(object model, string action, Exception inner)
        {
            string description = model.GetType().Name + " is incorrect! Unable to " + action + " " + model;
            return new DALException(description, inner);
        }

        //private Baget Read(BagetModel model)
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

        //public OrderModel LoadOrder(Guid id)
        //{
        //    return OrderMapper.MapToModel(database.BagetRep.LoadOrder(Read(id).ID));
        //}
        //public ObservableCollection<BagetModel> GetAll()
        //{
        //    return BagetMapper.MapToModelList(database.BagetRep.GetAll());
        //}

        //private Baget Read(Guid id)
        //{
        //    if (id == null)
        //        throw new CustomException("No baget id", "");
        //    Baget baget = database.BagetRep.GetByID(id);
        //    if (baget == null)
        //        throw new CustomException("No baget with such id", "");
        //    return baget;
        //}

        //private Order ReadOrder(Guid id)
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
