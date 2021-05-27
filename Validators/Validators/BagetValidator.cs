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
                throw NewEmptyValidatorException("ID", model);
            return model;
        }

        public BagetModel EmptyModelCheck(BagetModel model)
        {
            if (model == null)
                throw new ValidatorException("Empty BagetModel");
            return model;
        }

        public BagetModel Validate(BagetModel model)
        {
            model = EmptyModelCheck(model);

            if (model.Amount == null || model.Amount.Length == 0)
                throw NewEmptyValidatorException("Amount", model);
            if (!int.TryParse(model.Amount, out int amount))
                throw NewParseValidatorException("Amount", model);

            if (model.Lenght == null || model.Lenght.Length == 0)
                throw NewEmptyValidatorException("Lenght", model);
            if (!Double.TryParse(model.Lenght, out Double lenght))
                throw NewParseValidatorException("Lenght", model);

            if (model.Width == null || model.Width.Length == 0)
                throw NewEmptyValidatorException("Width", model);
            if (!Double.TryParse(model.Width, out Double width))
                throw NewParseValidatorException("Width", model);

            if (model.OrderID == null || model.OrderID == Guid.Empty)
                throw NewEmptyValidatorException("Order ID", model);

            if (model.TypeID == null || model.TypeID == Guid.Empty)
                throw NewEmptyValidatorException("Type ID", model);

            return model;
        }

        private ValidatorException NewEmptyValidatorException(string property, BagetModel model)
        {
            string description = "Empty " + property + " of BagetModel";
            return new ValidatorException(description, model);
        }
        private ValidatorException NewParseValidatorException(string property, BagetModel model)
        {
            string description = "Can't parse " + property + " of BagetModel";
            return new ValidatorException(description, 
                model.GetType().GetProperty(property).GetValue(model, null).ToString(),
                model);
        }
    }
}
