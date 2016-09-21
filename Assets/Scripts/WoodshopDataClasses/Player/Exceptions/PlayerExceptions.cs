using UnityEngine;
using System.Collections;

public class PlayerDoesNotExistException : System.Exception
{
    public PlayerDoesNotExistException() { }
    public PlayerDoesNotExistException(string message) : base(message) { }
    public PlayerDoesNotExistException(string message, System.Exception inner) : base(message, inner) { }
    protected PlayerDoesNotExistException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
}

public class MaxProfileLimitReachedException : System.Exception
{
    public MaxProfileLimitReachedException() { }
    public MaxProfileLimitReachedException(string message) : base(message) { }
    public MaxProfileLimitReachedException(string message, System.Exception inner) : base(message, inner) { }
    protected MaxProfileLimitReachedException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context)
    { }
}
