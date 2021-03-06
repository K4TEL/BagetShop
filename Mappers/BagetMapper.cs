using Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappers
{
    public static class BagetMapper
    {
        public static BagetModel MapToModel(this Baget entity)
        {
            return new BagetModel
            {
                ID = entity.ID,
                Amount = entity.Amount.ToString(),
                Lenght = entity.Lenght.ToString(),
                Width = entity.Width.ToString(),

                OrderID = entity.Order_ID,
                TypeID = entity.Type_ID,
                Typename = !(entity.Type is null) ? entity.Type.Title : null
            };
        }

        public static void UpdateBagetEntity(this Baget entity, BagetModel model)
        {
            entity.Amount = int.Parse(model.Amount);
            entity.Lenght = double.Parse(model.Lenght);
            entity.Width = double.Parse(model.Width);
            entity.Order_ID = model.OrderID;
            entity.Type_ID = model.TypeID;
        }

        public static Baget NewBagetEntity(this BagetModel model)
        {
            return new Baget
            {
                ID = Guid.NewGuid(),
                Amount = int.Parse(model.Amount),
                Lenght = double.Parse(model.Lenght),
                Width = double.Parse(model.Width),
                Order_ID = model.OrderID,
                Type_ID = model.TypeID
            };
        }
        public static ObservableCollection<BagetModel> MapToModelList(
            this IEnumerable<Baget> entities)
        {
            return new ObservableCollection<BagetModel>(
                from entity in entities select MapToModel(entity));
        }
    }
}
