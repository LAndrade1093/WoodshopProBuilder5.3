﻿using UnityEngine;
using System.Collections;

public class Plywood : WorkshopMaterial
{
    private string _thicknessInInches;
    private string _widthInFeet;
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

    public Plywood(string name, WorkshopMaterialType type, Sprite icon, string thickness, string width, string length)
        : base(name, type, icon)
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

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}