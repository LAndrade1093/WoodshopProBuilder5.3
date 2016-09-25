using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// The base class for any material in the game
/// Inherit from this class to add a material that needs this info and more
/// </summary>
[System.Serializable]
public class WoodshopMaterial : AbstractAsset
{
    [SerializeField]
    private string _name;
    [SerializeField]
    private WoodshopMaterialType _type;
    [SerializeField]
    private Sprite _icon;
    [SerializeField]
    private float _storePrice;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public WoodshopMaterialType Type
    {
        get { return _type; }
        set { _type = value; }
    }

    public Sprite Icon
    {
        get { return _icon; }
        set { _icon = value; }
    }

    public float StorePrice
    {
        get { return _storePrice; }
        set { _storePrice = value; }
    }

    public WoodshopMaterial() : base()
    {
        this.Name = string.Empty;
        this.Type = WoodshopMaterialType.None;
        this.Icon = null;
        this.StorePrice = 0f;
    }

    public WoodshopMaterial(float id, string name, WoodshopMaterialType type)
        : base(id)
    {
        this.Name = name;
        this.Type = type;
        this.Icon = null;
        this.StorePrice = 0f;
    }

    public WoodshopMaterial(float id, string name, WoodshopMaterialType type, Sprite icon, float price = 0f) 
        : base(id)
    {
        this.Name = name;
        this.Type = type;
        this.Icon = icon;
        this.StorePrice = price;
    }

    public override bool Equals(object obj)
    {
        if (object.ReferenceEquals(this, obj)) return true;
        return EqualsInheritance(obj) && obj.GetType() == typeof(WoodshopMaterial);
    }

    protected virtual bool EqualsInheritance(object obj)
    {
        if (obj == null || !(obj is WoodshopMaterial)) return false;

        WoodshopMaterial otherGameMaterial = (WoodshopMaterial)obj;

        if (this.ID != otherGameMaterial.ID) return false;
        if (this.Name != otherGameMaterial.Name) return false;
        if (this.Type != otherGameMaterial.Type) return false;
        if (this.Icon != otherGameMaterial.Icon) return false;
        if (this.StorePrice != otherGameMaterial.StorePrice) return false;

        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return Name;
    }
}
