using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

/// <summary>
/// Data related to the tools in the game
/// </summary>
[System.Serializable]
public class Tool : AbstractAsset
{
    [SerializeField]
    private string _displayName;
    [SerializeField]
    private Sprite _icon;
    [SerializeField]
    private float _storePrice;

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

    public float StorePrice
    {
        get { return _storePrice; }
        private set { _storePrice = value; }
    }

    public Tool()
        : base()
    {
        this.DisplayName = string.Empty;
        this.Icon = null;
        this.StorePrice = 0f;
    }

    public Tool(float id) 
        : base(id)
    {
        this.DisplayName = string.Empty;
        this.Icon = null;
        this.StorePrice = 0f;
    }

    public Tool(float id, string name, Sprite icon, float price = 0f)
        : base(id)
    {
        this.DisplayName = name;
        this.Icon = icon;
        this.StorePrice = price;
    }

    public override bool Equals(object obj)
    {
        if (this == obj) return true;
        if (obj == null || GetType() != obj.GetType()) return false;

        Tool otherTool = (Tool)obj;
        if (this.ID != otherTool.ID) return false;
        if (this.DisplayName != otherTool.DisplayName) return false;
        if (this.Icon != otherTool.Icon) return false;
        if (this.StorePrice != otherTool.StorePrice) return false;

        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
