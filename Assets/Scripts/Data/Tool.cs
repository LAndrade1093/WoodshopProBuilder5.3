using UnityEngine;
using System.Collections;

[System.Serializable]
public class Tool 
{
    private float _id;
    private static float nextID = 0f;

    private string _displayName;
    private ToolType _type;
    private Sprite _icon;

    public float ID
    {
        get { return _id; }
    }

    public string DisplayName
    {
        get { return _displayName; }
        private set { _displayName = value; }
    }

    public ToolType Type
    {
        get { return _type; }
        private set { _type = value; }
    }

    public Sprite Icon
    {
        get { return _icon; }
        private set { _icon = value; }
    }

    public Tool(string name, ToolType tool, Sprite icon)
    {
        this._id = nextID++;
        this.DisplayName = name;
        this.Type = tool;
        this.Icon = icon;
    }

    public override bool Equals(object obj)
    {
        if (this == obj) return true;
        if (obj == null || GetType() != obj.GetType()) return false;

        Tool otherTool = (Tool)obj;
        if (this.ID != otherTool.ID) return false;
        if (this.DisplayName != otherTool.DisplayName) return false;
        if (this.Type != otherTool.Type) return false;
        if (this.Icon != otherTool.Icon) return false;

        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
