using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Validators
{
    [Serializable]
    public class ValidatorException : Exception
    {
        public string Property { get; protected set; }
        public object Model { get; protected set; }
        public ValidatorException() { }
        
        public ValidatorException(string message)
            : base(message) { }

        public ValidatorException(string message, object model) 
            : base(message) 
        { 
            this.Model = model; 
        }
        public ValidatorException(string message, string prop, object model)
            : base(message)
        {
            this.Property = prop;
            this.Model = model;
        }

        protected ValidatorException(SerializationInfo info, StreamingContext context) 
            : base(info, context) { }
    }
}
