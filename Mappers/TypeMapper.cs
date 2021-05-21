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
    public static class TypeMapper
    {
        public static TypeModel MapToModel(this BagType entity)
        {
            if (entity == null)
                throw new ValidationException("Empty Type entity");

            return new TypeModel
            {
                ID = entity.ID,
                Title = entity.Title,

                Materials = !(entity.Materials is null) ?
                entity.Materials.MapToModelList() : 
                new ObservableCollection<MaterialModel>()
            };
        }
        public static ObservableCollection<TypeModel> MapToModelList(
            this IEnumerable<BagType> entities)
        {
            if (entities == null)
                throw new ValidationException("Empty Type list");

            return new ObservableCollection<TypeModel>
                (from entity in entities select MapToModel(entity));
        }
    }
}
