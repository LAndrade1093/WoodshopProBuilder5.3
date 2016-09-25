using UnityEngine;
using System.Collections;

[System.Serializable]
public class Plywood : WoodshopMaterial
{
    [SerializeField]
    private string _thicknessInInches;
    [SerializeField]
    private string _widthInFeet;
    [SerializeField]
    private string _lengthInFeet;

    public string ThicknessInInches
    {
        get { return _thicknessInInches; }
        set { _thicknessInInches = value; }
    }

    public string WidthInFeet
    {
        get { return _widthInFeet; }
        set { _widthInFeet = value; }
    }

    public string LengthInFeet
    {
        get { return _lengthInFeet; }
        set { _lengthInFeet = value; }
    }

    public Plywood()
        : base()
    {
        this.ThicknessInInches = string.Empty;
        this.WidthInFeet = string.Empty;
        this.LengthInFeet = string.Empty;
    }

    public Plywood(float id, string name, WoodshopMaterialType type, Sprite icon, float price, string thickness, string width, string length)
        : base(id, name, type, icon, price)
    {
        this.ThicknessInInches = thickness;
        this.WidthInFeet = width;
        this.LengthInFeet = length;
    }

    public override bool Equals(object obj)
    {
        if (object.ReferenceEquals(this, obj)) return true;
        return EqualsInheritance(obj) && obj.GetType() == typeof(Plywood);
    }

    protected override bool EqualsInheritance(object obj)
    {
        if (!base.EqualsInheritance(obj)) return false;
        if (obj == null || !(obj is Plywood)) return false;

        Plywood otherPlywood = (Plywood)obj;
        if (this.ThicknessInInches != otherPlywood.ThicknessInInches) return false;
        if (this.WidthInFeet != otherPlywood.WidthInFeet) return false;
        if (this.LengthInFeet != otherPlywood.LengthInFeet) return false;

        return true;
    }

    public override string ToString()
    {
        return Name + ": " + LengthInFeet + "\' L x " + WidthInFeet + "\' W x " + ThicknessInInches + "\" T ";
    }
}