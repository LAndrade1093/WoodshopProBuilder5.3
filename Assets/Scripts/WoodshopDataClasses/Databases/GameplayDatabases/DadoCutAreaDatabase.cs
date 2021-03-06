﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// Database class to store all DadoCut data instances.
/// </summary>
[System.Serializable]
public class DadoCutAreaDatabase : GameplayDatabase<DadoCutAreaData>
{
    private static DadoCutAreaDatabase _instance;

    public static DadoCutAreaDatabase Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new DadoCutAreaDatabase();
            }
            return _instance;
        }
    }

    private DadoCutAreaDatabase() { }

    protected override List<string> DataFilePaths
    {
        get
        {
            return new List<string> { "GameCSVData/DadoCutAreas" };
        }
    }

    protected override void LoadFromDataFile()
    {
        throw new NotImplementedException();
    }
}
