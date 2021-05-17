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
    static class MaterialMapper
    {
        public static MaterialModel MapToModel(this Material entity)
        {
            return new MaterialModel
            {
                ID = entity.ID,
                Amount = entity.Amount.ToString(),
                Name = entity.Name,
                Unit = entity.Unit.ToString(),

                TypeID = entity.Type_ID
            };
        }

        public static ObservableCollection<MaterialModel> MapToModelList(
            this IEnumerable<Material> entities)
        {
            return new ObservableCollection<MaterialModel>
                (from entity in entities select MapToModel(entity));
        }
    }
}
