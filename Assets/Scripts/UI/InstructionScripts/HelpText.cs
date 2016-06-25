using UnityEngine;
using System.Collections;

[System.Serializable]
public class HelpText
{
    public string Title;
    [TextArea(3, 10)]
    public string Info;
}
