using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Mappers.Util
{
    [Serializable]
    public class ValidationException : Exception
    {
        public string Property { get; protected set; }

        public bool isNull { get; protected set; }

        public ValidationException(string message, string prop) 
            : base(message) { this.Property = prop; }

        public ValidationException(string message)
            : base(message) { this.isNull = true; }

        protected ValidationException(SerializationInfo info, StreamingContext context) 
            : base(info, context) { }
    }
}
