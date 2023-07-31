using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedManager : MonoBehaviour
{
    [SerializeField]
    PlantManager plantManager;

    [SerializeField]
    int _waterCost = 1;

    [SerializeField]
    int _sunlightCost = 1;

    [SerializeField]
    int _electricityCost = 1;

    void OnMouseDown()
    {
        plantManager.ClickSeed(1, _sunlightCost, _waterCost, _electricityCost, true);
    }
}
