using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickerManager : MonoBehaviour
{
    [SerializeField]
    PlantManager plantManager;

    [SerializeField]
    ElementsManager elementsManager;

    [SerializeField]
    GameObject clickerUpgradeButton;

    [SerializeField]
    int clickerID = 0;

    [SerializeField]
    int clickerAmount = 1;

    [SerializeField]
    TextMeshPro clickerAmountText;

    [SerializeField]
    int _waterCost = 1;

    [SerializeField]
    int _sunlightCost = 1;

    [SerializeField]
    int _electricityCost = 1;

    float clickTimer = 0;
    float timeBetweenClicks = 1f;

    void Start()
    {
        clickerAmountText.text = clickerAmount.ToString();
    }

    private void Update()
    {
        switch (clickerID)
        {
            case 0:
                if (clickTimer >= (timeBetweenClicks / clickerAmount))
                {
                    plantManager.ClickSeed(2, _sunlightCost, _waterCost, _electricityCost, false);

                    clickTimer = 0;
                }

                break;
            case 1:
                if (clickTimer >= (timeBetweenClicks / clickerAmount))
                {
                    elementsManager.AddSunlight(1);

                    clickTimer = 0;
                }
                break;
            case 2:
                if (clickTimer >= (timeBetweenClicks / clickerAmount))
                {
                    elementsManager.AddWater(1);

                    clickTimer = 0;
                }
                break;
            case 3:
                if (clickTimer >= (timeBetweenClicks / clickerAmount))
                {
                    elementsManager.AddElectricity(1);

                    clickTimer = 0;
                }

                break;

            default:
                break;
        }

        clickTimer += Time.deltaTime;
    }

    public void AddClicker()
    {
        clickerAmount++;
        clickerAmountText.text = clickerAmount.ToString();

        if (clickerAmount >= 99)
        {
            clickerUpgradeButton.SetActive(false);
        }
    }
}
