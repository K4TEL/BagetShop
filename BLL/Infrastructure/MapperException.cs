using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
    [Serializable]
    public class MapperException : Exception
    {
        //public string Property { get; protected set; }
        //public MapperException(string message, string prop, Exception inner) 
        //    : base(message, inner)
        //{
        //    this.Property = prop;
        //}
        public MapperException(string message, Exception inner)
            : base(message, inner) { }

        protected MapperException(SerializationInfo info, StreamingContext context) 
            : base(info, context) { }
    }
}
