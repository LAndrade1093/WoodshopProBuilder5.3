using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class WorkshopMaterial : AbstractAsset
{
    [SerializeField]
    private string _name;
    [SerializeField]
    private WorkshopMaterialType _type;
    [SerializeField]
    private Sprite _icon;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public WorkshopMaterialType Type
    {
        get { return _type; }
        set { _type = value; }
    }

    public Sprite Icon
    {
        get { return _icon; }
        set { _icon = value; }
    }

    public WorkshopMaterial() : base()
    {
        this.Name = string.Empty;
        this.Type = WorkshopMaterialType.None;
        this.Icon = null;
    }

    public WorkshopMaterial(float id, string name, WorkshopMaterialType type, Sprite icon) 
        : base(id)
    {
        this.Name = name;
        this.Type = type;
        this.Icon = icon;
    }

    public override bool Equals(object obj)
    {
        if (object.ReferenceEquals(this, obj)) return true;
        return EqualsInheritance(obj) && obj.GetType() == typeof(WorkshopMaterial);
    }

    protected virtual bool EqualsInheritance(object obj)
    {
        if (obj == null || !(obj is WorkshopMaterial)) return false;

        WorkshopMaterial otherGameMaterial = (WorkshopMaterial)obj;

        if (this.ID != otherGameMaterial.ID) return false;
        if (this.Name != otherGameMaterial.Name) return false;
        if (this.Type != otherGameMaterial.Type) return false;
        if (this.Icon != otherGameMaterial.Icon) return false;

        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
