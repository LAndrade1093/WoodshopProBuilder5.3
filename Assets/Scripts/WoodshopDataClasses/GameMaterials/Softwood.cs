using UnityEngine;
using System.Collections;

[System.Serializable]
public class Softwood : WoodshopMaterial
{
    [SerializeField]
    private string _nomimalInches;
    [SerializeField]
    private string _actualInches;
    [SerializeField]
    private string _lengthInFeet;

    public string NomimalInches
    {
        get { return _nomimalInches; }
        set { _nomimalInches = value; }
    }

    public string ActualInches
    {
        get { return _actualInches; }
        set { _actualInches = value; }
    }

    public string LengthInFeet
    {
        get { return _lengthInFeet; }
        set { _lengthInFeet = value; }
    }

    public Softwood()
        : base()
    {
        this.NomimalInches = string.Empty;
        this.ActualInches = string.Empty;
        this.LengthInFeet = string.Empty;
    }

    public Softwood(float id, string name, WoodshopMaterialType type, Sprite icon, float price, string nominal, string actual, string length)
        : base(id, name, type, icon, price)
    {
        this.NomimalInches = nominal;
        this.ActualInches = actual;
        this.LengthInFeet = length;
    }

    public override bool Equals(object obj)
    {
        if (object.ReferenceEquals(this, obj)) return true;
        return EqualsInheritance(obj) && obj.GetType() == typeof(Softwood);
    }

    protected override bool EqualsInheritance(object obj)
    {
        if (!base.EqualsInheritance(obj)) return false;
        if (obj == null || !(obj is Softwood)) return false;

        Softwood otherSoftwood = (Softwood)obj;
        if (this.NomimalInches != otherSoftwood.NomimalInches) return false;
        if (this.ActualInches != otherSoftwood.ActualInches) return false;
        if (this.LengthInFeet != otherSoftwood.LengthInFeet) return false;

        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return Name + ": " + NomimalInches + "\" nominal, " + ActualInches + "\" actual, "+ LengthInFeet+"\' long";
    }
}