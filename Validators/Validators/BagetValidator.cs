using Models;
using System;
using System.Collections.Generic;
using System.Text;
using Validators.Interfaces;

namespace Validators.Validators
{
    public class BagetValidator : IValidator<BagetModel>
    {
        public BagetModel EmptyIDCheck(BagetModel model)
        {
            model = EmptyModelCheck(model);
            Guid id = model.ID;
            if (id == null || id == Guid.Empty)
                throw new ValidationException("Empty ID of " + model.GetType().Name + model);
            return model;
        }

        public BagetModel EmptyModelCheck(BagetModel model)
        {
            if (model == null)
                throw new ValidationException("Empty BagetModel");
            return model;
        }

        public BagetModel Validate(BagetModel model)
        {
            model = EmptyModelCheck(model);

            if (model.Amount == null)
                throw new ValidationException("Empty Amount", model);
            if (!int.TryParse(model.Amount, out int amount))
                throw new ValidationException("Can't parse Amount", model.Amount, model);

            if (model.Lenght == null)
                throw new ValidationException("Empty Lenght", model);
            if (!Double.TryParse(model.Lenght, out Double lenght))
                throw new ValidationException("Can't parse Lenght", model.Lenght, model);

            if (model.Width == null)
                throw new ValidationException("Empty Width", model);
            if (!Double.TryParse(model.Width, out Double width))
                throw new ValidationException("Can't parse Width", model.Width, model);

            if (model.OrderID == null || model.OrderID == Guid.Empty)
                throw new ValidationException("Empty Order ID", model);

            if (model.TypeID == null || model.TypeID == Guid.Empty)
                throw new ValidationException("Empty Type ID", model);

            return model;
        }
    }
}
