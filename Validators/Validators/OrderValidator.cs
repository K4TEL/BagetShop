using Models;
using System;
using System.Collections.Generic;
using System.Text;
using Validators.Interfaces;

namespace Validators.Validators
{
    public class OrderValidator : IValidator<OrderModel>
    {
        public OrderModel EmptyIDCheck(OrderModel model)
        {
            model = EmptyModelCheck(model);
            Guid id = model.ID;
            if (id == null)
                throw new ValidatorException("Empty ID of OrderModel", model);
            return model;
        }

        public OrderModel EmptyModelCheck(OrderModel model)
        {
            if (model == null)
                throw new ValidatorException("Empty OrderModel");
            return model;
        }

        public OrderModel Validate(OrderModel model)
        {
            model = EmptyModelCheck(model);
            if (model.Customer == null)
                throw new ValidatorException("Empty Customer of OrderModel", model);
            return model;
        }
    }
}
