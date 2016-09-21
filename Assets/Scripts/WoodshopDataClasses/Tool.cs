using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

[System.Serializable]
public class Tool : AbstractAsset
{
    [SerializeField]
    private string _displayName;
    [SerializeField]
    private Sprite _icon;

    public string DisplayName
    {
        get { return _displayName; }
        private set { _displayName = value; }
    }
    
    public Sprite Icon
    {
        get { return _icon; }
        private set { _icon = value; }
    }

    public Tool()
        : base()
    {
        this.DisplayName = string.Empty;
        this.Icon = null;
    }

    public Tool(float id) 
        : base(id)
    {
        this.DisplayName = string.Empty;
        this.Icon = null;
    }

    public Tool(float id, string name, Sprite icon)
        : base(id)
    {
        this.DisplayName = name;
        this.Icon = icon;
    }

    public override bool Equals(object obj)
    {
        if (this == obj) return true;
        if (obj == null || GetType() != obj.GetType()) return false;

        Tool otherTool = (Tool)obj;
        if (this.ID != otherTool.ID) return false;
        if (this.DisplayName != otherTool.DisplayName) return false;
        if (this.Icon != otherTool.Icon) return false;

        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
