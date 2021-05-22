using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleBaget.Interfaces
{
    public interface IValidator<T> where T : class
    {
        T Validate(T model);
        T EmptyModelCheck(T model);
        T EmptyIDCheck(T model);
    }
}
