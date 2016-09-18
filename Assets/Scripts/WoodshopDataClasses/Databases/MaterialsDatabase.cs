using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class MaterialsDatabase : AbstractDatabase<WoodshopMaterial>
{
    private static MaterialsDatabase _instance;

    public static MaterialsDatabase Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new MaterialsDatabase();
            }
            return _instance;
        }
    }

    private MaterialsDatabase() { }

    protected override List<string> DataFilePaths
    {
        get
        {
            return new List<string> { "GameCSVData/WoodshopMaterials" };
        }
    }

    protected override void LoadFromDataFile()
    {
        throw new NotImplementedException();
    }
}