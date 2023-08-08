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

    public int WaterCost = 1;

    public int SunlightCost = 1;

    public int ElectricityCost = 1;

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
                if (clickTimer >= ((timeBetweenClicks / clickerAmount) * 2))
                {
                    plantManager.ClickSeed(
                        _amountToAddSeedClicker,
                        SunlightCost,
                        WaterCost,
                        ElectricityCost,
                        false
                    );

                    clickTimer = 0;
                }

                break;
            case 1:
                if (clickTimer >= ((timeBetweenClicks / clickerAmount) * 2))
                {
                    elementsManager.AddSunlight(
                        _amountToAddElementClicker,
                        false,
                        transform.position,
                        new Color(1, 0.6f, 0, 1)
                    );

                    clickTimer = 0;
                }
                break;
            case 2:
                if (clickTimer >= ((timeBetweenClicks / clickerAmount) * 2))
                {
                    elementsManager.AddWater(
                        _amountToAddElementClicker,
                        false,
                        transform.position,
                        new Color(0, 0.6f, 1, 1)
                    );

                    clickTimer = 0;
                }
                break;
            case 3:
                if (clickTimer >= ((timeBetweenClicks / clickerAmount) * 2))
                {
                    elementsManager.AddElectricity(
                        _amountToAddElementClicker,
                        false,
                        transform.position,
                        new Color(0.6f, 0, 1, 1)
                    );

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
