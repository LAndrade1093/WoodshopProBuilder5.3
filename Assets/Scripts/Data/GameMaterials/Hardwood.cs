using UnityEngine;
using System.Collections;

public class Hardwood : WorkshopMaterial
{
    private string _roughSizeInInches;
    private string _nominalSize;
    private string _actualDimensionSurfacedOneSide;
    private string _actualDimensionSurfacedTwoSides;

    public string RoughSizeInInches
    {
        get { return _roughSizeInInches; }
        set { _roughSizeInInches = value; }
    }

    public string NominalSize
    {
        get { return _nominalSize; }
        set { _nominalSize = value; }
    }

    public string ActualDimensionSurfacedOneSide
    {
        get { return _actualDimensionSurfacedOneSide; }
        set { _actualDimensionSurfacedOneSide = value; }
    }

    public string ActualDimensionSurfacedTwoSides
    {
        get { return _actualDimensionSurfacedTwoSides; }
        set { _actualDimensionSurfacedTwoSides = value; }
    }

    public Hardwood()
        : base()
    {
        this.RoughSizeInInches = string.Empty;
        this.NominalSize = string.Empty;
        this.ActualDimensionSurfacedOneSide = string.Empty;
        this.ActualDimensionSurfacedTwoSides = string.Empty;
    }

    public Hardwood(string name, WorkshopMaterialType type, Sprite icon, string roughSize, string nominalSize, string actualDimensionS1S, string actualDimensionS2S)
        : base(name, type, icon)
    {
        this.RoughSizeInInches = roughSize;
        this.NominalSize = nominalSize;
        this.ActualDimensionSurfacedOneSide = actualDimensionS1S;
        this.ActualDimensionSurfacedTwoSides = actualDimensionS2S;
    }

    public override bool Equals(object obj)
    {
        if (object.ReferenceEquals(this, obj)) return true;
        return EqualsInheritance(obj) && obj.GetType() == typeof(Hardwood);
    }

    protected override bool EqualsInheritance(object obj)
    {
        if (!base.EqualsInheritance(obj)) return false;
        if (obj == null || !(obj is Hardwood)) return false;

        Hardwood otherHardwood = (Hardwood)obj;
        if (this.RoughSizeInInches != otherHardwood.RoughSizeInInches) return false;
        if (this.NominalSize != otherHardwood.NominalSize) return false;
        if (this.ActualDimensionSurfacedOneSide != otherHardwood.ActualDimensionSurfacedOneSide) return false;
        if (this.ActualDimensionSurfacedTwoSides != otherHardwood.ActualDimensionSurfacedTwoSides) return false;

        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
