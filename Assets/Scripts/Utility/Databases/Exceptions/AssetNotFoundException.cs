using UnityEngine;
using System.Collections;

namespace Woodshop.Utility.Exceptions
{
    public class AssetNotFoundException : System.Exception
    {
        public AssetNotFoundException() { }
        public AssetNotFoundException(string message) : base(message) { }
        public AssetNotFoundException(string message, System.Exception inner) : base(message, inner) { }
        protected AssetNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }
}