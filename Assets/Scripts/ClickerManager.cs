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

    [SerializeField]
    int _amountToAddElementClicker = 1;

    [SerializeField]
    int _amountToAddSeedClicker = 1;

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
                    plantManager.ClickSeed(
                        _amountToAddSeedClicker,
                        _sunlightCost,
                        _waterCost,
                        _electricityCost,
                        false
                    );

                    clickTimer = 0;
                }

                break;
            case 1:
                if (clickTimer >= (timeBetweenClicks / clickerAmount))
                {
                    elementsManager.AddSunlight(_amountToAddElementClicker);

                    clickTimer = 0;
                }
                break;
            case 2:
                if (clickTimer >= (timeBetweenClicks / clickerAmount))
                {
                    elementsManager.AddWater(_amountToAddElementClicker);

                    clickTimer = 0;
                }
                break;
            case 3:
                if (clickTimer >= (timeBetweenClicks / clickerAmount))
                {
                    elementsManager.AddElectricity(_amountToAddElementClicker);

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

    public void MultiplyAmountToAddSeedClicker(float multiplier)
    {
        _amountToAddSeedClicker = (int)Mathf.Round(_amountToAddSeedClicker * multiplier);
    }

    public void MultiplyAmountToAddElementClicker(float multiplier)
    {
        _amountToAddElementClicker = (int)Mathf.Round(_amountToAddElementClicker * multiplier);
    }
}
