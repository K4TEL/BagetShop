﻿using Entities;
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
    public static class MaterialMapper
    {
        public static MaterialModel MapToModel(this Material entity)
        {
            if (entity == null)
                throw new ValidationException("Empty Material entity");

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
            if (entities == null)
                throw new ValidationException("Empty Material list");

            return new ObservableCollection<MaterialModel>
                (from entity in entities select MapToModel(entity));
        }
    }
}
