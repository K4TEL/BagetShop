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
    public static class BagetMapper
    {
        public static BagetModel MapToModel(this Baget entity)
        {
            if (entity == null)
                throw new ValidationException("Empty Baget entity");

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
            if (model == null)
                throw new ValidationException("Empty BagetModel");

            if (entity == null)
                throw new ValidationException("Empty Baget entity");

            if (model.Amount == null)
                throw new ValidationException("Empty amount");
            if (!int.TryParse(model.Amount, out int amount))
                throw new ValidationException("Incorrect amount", model.Amount);
            entity.Amount = amount;

            if (model.Lenght == null)
                throw new ValidationException("Empty lenght");
            if (!Double.TryParse(model.Lenght, out Double lenght))
                throw new ValidationException("Incorrect lenght", model.Lenght);
            entity.Lenght = lenght;

            if (model.Width == null)
                throw new ValidationException("Empty width");
            if (!Double.TryParse(model.Width, out Double width))
                throw new ValidationException("Incorrect width", model.Width);
            entity.Width = width; 
            

            if (model.OrderID == null || model.OrderID == Guid.Empty)
                throw new ValidationException("Empty Order ID");
            entity.Order_ID = model.OrderID;

            if (model.TypeID == null || model.TypeID == Guid.Empty)
                throw new ValidationException("Empty Type ID");
            entity.Type_ID = model.TypeID;
        }

        public static Baget NewBagetEntity(this BagetModel model)
        {
            if (model == null)
                throw new ValidationException("Empty BagetModel");

            Baget entity = new Baget();

            if (model.Amount == null)
                throw new ValidationException("Empty amount");
            if (!int.TryParse(model.Amount, out int amount))
                throw new ValidationException("Incorrect amount", model.Amount);
            entity.Amount = amount;

            if (model.Lenght == null)
                throw new ValidationException("Empty lenght");
            if (!Double.TryParse(model.Lenght, out Double lenght))
                throw new ValidationException("Incorrect lenght", model.Lenght);
            entity.Lenght = lenght;

            if (model.Width == null)
                throw new ValidationException("Empty width");
            if (!Double.TryParse(model.Width, out Double width))
                throw new ValidationException("Incorrect width", model.Width);
            entity.Width = width;


            if (model.OrderID == null || model.OrderID == Guid.Empty)
                throw new ValidationException("Empty Order ID");
            entity.Order_ID = model.OrderID;

            if (model.TypeID == null || model.TypeID == Guid.Empty)
                throw new ValidationException("Empty Type ID");
            entity.Type_ID = model.TypeID;

            return entity;
        }
        public static ObservableCollection<BagetModel> MapToModelList(
            this IEnumerable<Baget> entities)
        {
            if (entities == null)
                throw new ValidationException("Empty BagetModel list");

            return new ObservableCollection<BagetModel>(
                from entity in entities select MapToModel(entity));
        }
    }
}
