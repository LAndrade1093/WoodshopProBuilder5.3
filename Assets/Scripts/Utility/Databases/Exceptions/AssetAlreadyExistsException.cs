using UnityEngine;
using System.Collections;

namespace Woodshop.Utility.Exceptions
{
    public class EntityAlreadyExistsException : System.Exception
    {
        public EntityAlreadyExistsException() { }
        public EntityAlreadyExistsException(string message) : base(message) { }
        public EntityAlreadyExistsException(string message, System.Exception inner) : base(message, inner) { }
        protected EntityAlreadyExistsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }
}
