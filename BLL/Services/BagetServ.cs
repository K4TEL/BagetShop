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
            return database.BagetRep.Load(Read(id).ID).MapToModel();
        }

        public BagetModel Save(BagetModel bagetDTO, bool isNew)
        {
            if (isNew)
            {
                if (bagetDTO == null)
                    throw new ValidationException("No baget model", "");

                Baget baget = bagetDTO.NewBagetEntity();

                database.BagetRep.Create(baget);
                return Load(baget.ID);
            }
            else
            {
                Baget baget = Read(bagetDTO);
                baget.UpdateBagetEntity(bagetDTO);

                database.BagetRep.Update(baget);
                return Load(baget.ID);
            }
        }

        public void Del(BagetModel bagetDTO)
        {
            database.BagetRep.Delete(Read(bagetDTO));
        }

        public TypeModel LoadType(Guid id)
        {
            return database.BagetRep.LoadType(Read(id).ID).MapToModel();
        }

        //public OrderModel LoadOrder(Guid id)
        //{
        //    return OrderMapper.MapToModel(database.BagetRep.LoadOrder(Read(id).ID));
        //}
        //public ObservableCollection<BagetModel> GetAll()
        //{
        //    return BagetMapper.MapToModelList(database.BagetRep.GetAll());
        //}

        private Baget Read(BagetModel model)
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
        private Baget Read(Guid id)
        {
            if (id == null)
                throw new ValidationException("No baget id", "");
            Baget baget = database.BagetRep.GetByID(id);
            if (baget == null)
                throw new ValidationException("No baget with such id", "");
            return baget;
        }

        private Order ReadOrder(Guid id)
        {
            if (id == null)
                throw new ValidationException("No order id", "");
            Order order = database.OrderRep.GetByID(id);
            if (order == null)
                throw new ValidationException("No order with such id", "");
            return order;
        }
    }
}
