using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
    [Serializable]
    public class ReadModelException : Exception
    {
        //public string Property { get; protected set; }
        //public CustomException(string message, string prop, Exception inner) 
        //    : base(message)
        //{
        //    this.Property = prop;
        //}

        //public CustomException(string message, string prop) : base(message)
        //{
        //    this.Property = prop;
        //}

        public ReadModelException(string message) : base(message) { }

        protected ReadModelException(SerializationInfo info, StreamingContext context) 
            : base(info, context) { }
    }
}
