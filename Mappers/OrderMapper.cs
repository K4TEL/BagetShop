using BLL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    static class OrderMapper
    {
        public static OrderModel MapToModel(this Order entity)
        {
            return new OrderModel
            {
                ID = entity.ID,
                Customer = entity.Customer,

                Bagets = !(entity.Bagets is null) ?
                BagetMapper.MapToModelList(entity.Bagets) : 
                new ObservableCollection<BagetModel>()
            };
        }

        public static ObservableCollection<OrderModel> MapToModelList(
            this IEnumerable<Order> entities)
        {
            return new ObservableCollection<OrderModel>
                (from entity in entities select MapToModel(entity));
        }
    }
}
