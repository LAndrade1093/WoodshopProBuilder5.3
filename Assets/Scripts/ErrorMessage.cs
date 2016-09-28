using UnityEngine;
using System.Collections;

/* NOTES:
 * This was meant as a way to return an object with data instead of throwing errors whenever a 
 * method needed to return a boolean saying that the method was successful. After some use, the 
 * code became too verbose, so I dedcided to use Exceptions instead. I kept this around in case
 * I missed any other places still using it.
 */

/// <summary>
/// Class that returns the results of a method with a message
/// </summary>
public class MethodResult 
{
    private string _message;
    private bool _successful;
    private ErrorType _error;

    public string Message
    {
        get { return _message; }
        private set { _message = value; }
    }

    public bool Successful
    {
        get { return _successful; }
        private set { _successful = value; }
    }

    public ErrorType Error
    {
        get { return (Successful) ? ErrorType.None : _error; }
        private set { _error = value; }
    }

    public MethodResult(string message = null, bool successful = true, ErrorType error = ErrorType.None)
    {
        this.Message = message;
        this.Successful = successful;
        this.Error = error;
    }
}

public enum ErrorType
{
    None,
    MaterialNotAvailable,
    NegativeCashAmountResult,
    NegativeInventoryInputAmount,
    NotEnoughMaterialsAvailable,
    ToolCantBeAdded,
    ToolCantBeRemoved,
    UnableToAddNode,
    UnableToRemoveConnection,
    UnableToAddToDatabase
}
