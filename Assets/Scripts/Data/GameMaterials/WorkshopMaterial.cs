using UnityEngine;
using System.Collections;

public class WorkshopMaterial 
{
    private float _id;
    private static float nextID = 0f;

    private string _name;
    private WorkshopMaterialType _type;
    private Sprite _icon;

    public float ID
    {
        get { return _id; }
        private set { _id = value; }
    }

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

    public WorkshopMaterial()
    {
        this.ID = nextID++;
        this.Name = string.Empty;
        this.Type = WorkshopMaterialType.None;
        this.Icon = null;
    }

    public WorkshopMaterial(string name, WorkshopMaterialType type, Sprite icon)
    {
        this.ID = nextID++;
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

    public override string ToString()
    {
        return Name;
    }
}
