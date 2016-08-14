using UnityEngine;
using System.Collections;

namespace Woodshop.Utility.Exceptions
{
    public class AssetAlreadyExistsException : System.Exception
    {
        public AssetAlreadyExistsException() { }
        public AssetAlreadyExistsException(string message) : base(message) { }
        public AssetAlreadyExistsException(string message, System.Exception inner) : base(message, inner) { }
        protected AssetAlreadyExistsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }
}
