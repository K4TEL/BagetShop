using Models;
using System;
using System.Collections.Generic;
using System.Text;
using WpfBaget.Interfaces;

namespace WpfBaget.Validators
{
    public class OrderValidator : IValidator<OrderModel>
    {
        public OrderModel EmptyIDCheck(OrderModel model)
        {
            model = EmptyModelCheck(model);
            Guid id = model.ID;
            if (id == null)
                throw new ValidationException("Empty ID of " + model.GetType().Name + model);
            return model;
        }

        public OrderModel EmptyModelCheck(OrderModel model)
        {
            if (model == null)
                throw new ValidationException("Empty OrderModel");
            return model;
        }

        public OrderModel Validate(OrderModel model)
        {
            model = EmptyModelCheck(model);

            if (model.Customer == null)
                throw new ValidationException("Empty Customer", model);
            return model;
        }
    }
}
