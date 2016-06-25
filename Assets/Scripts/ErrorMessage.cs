using UnityEngine;
using System.Collections;

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
