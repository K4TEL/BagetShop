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
    public static class TypeMapper
    {
        public static TypeModel MapToModel(this BagType entity)
        {
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
            return new ObservableCollection<TypeModel>
                (from entity in entities select MapToModel(entity));
        }
    }
}
