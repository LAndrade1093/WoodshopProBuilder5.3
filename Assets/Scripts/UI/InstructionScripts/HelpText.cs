using UnityEngine;
using System.Collections;

/// <summary>
/// Data class for any UI that needs to display a title and information
/// </summary>
[System.Serializable]
public class HelpText
{
    public string Title;
    [TextArea(3, 10)]
    public string Info;
}
