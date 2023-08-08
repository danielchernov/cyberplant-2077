using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    [SerializeField]
    GameObject _tutorialMenu;

    [SerializeField]
    TextMeshPro _costText;

    [SerializeField]
    ClickerManager _clickerManager;

    public void MultiplyAmountToAdd(float multiplyBy)
    {
        _amountToAdd = (int)Mathf.Round(_amountToAdd * multiplyBy);
    }

    public void MultiplyPointCost(float multiplyBy)
    {
        if ((int)Mathf.Round(_sunlightCost * multiplyBy) > 99)
        {
            _sunlightCost = 99;
            _clickerManager.SunlightCost = 99;
        }
        else
        {
            _sunlightCost = (int)Mathf.Round(_sunlightCost * multiplyBy);
            _clickerManager.SunlightCost = (int)Mathf.Round(_sunlightCost * multiplyBy);
        }
        if ((int)Mathf.Round(_waterCost * multiplyBy) > 99)
        {
            _waterCost = 99;
            _clickerManager.WaterCost = 99;
        }
        else
        {
            _waterCost = (int)Mathf.Round(_waterCost * multiplyBy);
            _clickerManager.WaterCost = (int)Mathf.Round(_waterCost * multiplyBy);
        }
        if ((int)Mathf.Round(_electricityCost * multiplyBy) > 99)
        {
            _electricityCost = 99;
            _clickerManager.ElectricityCost = 99;
        }
        else
        {
            _electricityCost = (int)Mathf.Round(_electricityCost * multiplyBy);
            _clickerManager.ElectricityCost = (int)Mathf.Round(_electricityCost * multiplyBy);
        }

        _costText.text = _sunlightCost.ToString();
    }

    private void OnMouseEnter()
    {
        if (_tutorialMenu.activeSelf)
            return;
        CursorChanger.Instance.ChangeCursorHand();
    }

    private void OnMouseExit()
    {
        if (_tutorialMenu.activeSelf)
            return;
        CursorChanger.Instance.ChangeCursorArrow();
    }

    void OnMouseDown()
    {
        if (_tutorialMenu.activeSelf)
            return;

        plantManager.ClickSeed(_amountToAdd, _sunlightCost, _waterCost, _electricityCost, true);
    }
}
