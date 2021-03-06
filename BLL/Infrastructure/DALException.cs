using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
    [Serializable]
    public class DALException : Exception
    {
        public DALException() { }
        public DALException(string message)
            : base(message) { }
        public DALException(string message, Exception inner) 
            : base(message, inner) { }
        protected DALException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
