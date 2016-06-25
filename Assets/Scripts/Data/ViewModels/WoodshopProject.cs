﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WoodshopProject : MonoBehaviour
{
    public string Name;
    public float SalePrice;
    public int CurrentStepNumber;
    public Score ScoreManager;
    public ProjectRequirements MaterialRequirements;
    public List<WoodshopStep> Steps;
}
