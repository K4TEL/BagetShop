using Entities;
using Mappers.Util;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappers
{
    public static class OrderMapper
    {
        public static OrderModel MapToModel(this Order entity)
        {
            if (entity == null)
                throw new ValidationException("Empty Order entity");

            return new OrderModel
            {
                ID = entity.ID,
                Customer = entity.Customer,

                Bagets = !(entity.Bagets is null) ?
                entity.Bagets.MapToModelList() : 
                new ObservableCollection<BagetModel>()
            };
        }

        public static void UpdateOrderCustomer(this Order entity, OrderModel model)
        {
            if (entity == null)
                throw new ValidationException("Empty Order entity");

            if (model == null)
                throw new ValidationException("Empty OrderModel");

            if (model.Customer == null)
                throw new ValidationException("Empty Customer");

            entity.Customer = model.Customer;
        }

        public static Order NewOrderEntity(this OrderModel model)
        {
            if (model == null)
                throw new ValidationException("Empty OrderModel");

            if (model.Customer == null)
                throw new ValidationException("Empty Customer");

            return new Order(model.Customer);
        }

        public static ObservableCollection<OrderModel> MapToModelList(
            this IEnumerable<Order> entities)
        {
            if (entities == null)
                throw new ValidationException("Empty Order list");

            return new ObservableCollection<OrderModel>
                (from entity in entities select MapToModel(entity));
        }
    }
}
