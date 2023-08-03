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

    [SerializeField]
    int _amountToAdd = 1;

    public void MultiplyAmountToAdd(float multiplyBy)
    {
        _amountToAdd = (int)Mathf.Round(_amountToAdd * multiplyBy);
    }

    private void OnMouseEnter()
    {
        CursorChanger.Instance.ChangeCursorHand();
    }

    private void OnMouseExit()
    {
        CursorChanger.Instance.ChangeCursorArrow();
    }

    void OnMouseDown()
    {
        plantManager.ClickSeed(_amountToAdd, _sunlightCost, _waterCost, _electricityCost, true);
    }
}
