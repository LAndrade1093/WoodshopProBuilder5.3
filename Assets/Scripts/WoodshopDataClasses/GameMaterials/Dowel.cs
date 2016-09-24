using UnityEngine;
using System.Collections;

[System.Serializable]
public class Dowel : WoodshopMaterial 
{
    [SerializeField]
    private string _diameterInInches;
    [SerializeField]
    private string _lengthInInches;

    public string DiameterInInches
    {
        get { return _diameterInInches; }
        set { _diameterInInches = value; }
    }

    public string LengthInInches
    {
        get { return _lengthInInches; }
        set { _lengthInInches = value; }
    }

    public Dowel() 
        : base()
    {
        this.DiameterInInches = string.Empty;
        this.LengthInInches = string.Empty;
    }

    public Dowel(float id, string name, WoodshopMaterialType type, Sprite icon, string diameter, string length)
        : base(id, name, type, icon)
    {
        this.DiameterInInches = diameter;
        this.LengthInInches = length;
    }

    public override bool Equals(object obj)
    {
        if (object.ReferenceEquals(this, obj)) return true;
        return EqualsInheritance(obj) && obj.GetType() == typeof(Dowel);
    }

    protected override bool EqualsInheritance(object obj)
    {
        if (!base.EqualsInheritance(obj)) return false;
        if (obj == null || !(obj is Dowel)) return false;

        Dowel otherDowel = (Dowel)obj;
        if (this.DiameterInInches != otherDowel.DiameterInInches) return false;
        if (this.LengthInInches != otherDowel.LengthInInches) return false;

        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return Name+": "+DiameterInInches+"\" diameter X "+LengthInInches+"\" long ";
    }
}
