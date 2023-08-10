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
    int _clickerAmount = 1;

    [SerializeField]
    TextMeshPro clickerAmountText;

    public int WaterCost = 1;

    public int SunlightCost = 1;

    public int ElectricityCost = 1;

    [SerializeField]
    int _amountToAddElementClicker = 1;

    [SerializeField]
    int _amountToAddSeedClicker = 1;

    float _clickTimer = 0;

    [SerializeField]
    float _timeBetweenClicks = 1f;

    void Start()
    {
        clickerAmountText.text = _clickerAmount.ToString();
    }

    private void Update()
    {
        switch (clickerID)
        {
            case 0:
                if (_clickTimer >= (_timeBetweenClicks / (_clickerAmount * 1f)))
                {
                    plantManager.ClickSeed(
                        _amountToAddSeedClicker,
                        SunlightCost,
                        WaterCost,
                        ElectricityCost,
                        false
                    );

                    _clickTimer = 0;
                }

                break;
            case 1:
                if (_clickTimer >= (_timeBetweenClicks / (_clickerAmount * 1.5f)))
                {
                    elementsManager.AddSunlight(
                        _amountToAddElementClicker,
                        false,
                        transform.position,
                        new Color(1, 0.6f, 0, 1)
                    );

                    _clickTimer = 0;
                }
                break;
            case 2:
                if (_clickTimer >= (_timeBetweenClicks / (_clickerAmount * 1.5f)))
                {
                    elementsManager.AddWater(
                        _amountToAddElementClicker,
                        false,
                        transform.position,
                        new Color(0, 0.6f, 1, 1)
                    );

                    _clickTimer = 0;
                }
                break;
            case 3:
                if (_clickTimer >= (_timeBetweenClicks / (_clickerAmount * 1.5f)))
                {
                    elementsManager.AddElectricity(
                        _amountToAddElementClicker,
                        false,
                        transform.position,
                        new Color(0.6f, 0, 1, 1)
                    );

                    _clickTimer = 0;
                }

                break;

            default:
                break;
        }

        _clickTimer += Time.deltaTime;
    }

    public void AddClicker()
    {
        _clickerAmount++;
        clickerAmountText.text = _clickerAmount.ToString();
    }

    public void MultiplyAmountToAddSeedClicker(float multiplier)
    {
        _amountToAddSeedClicker = (int)Mathf.Round(_amountToAddSeedClicker * multiplier);
    }

    public void MultiplyAmountToAddElementClicker(float multiplier)
    {
        _amountToAddElementClicker = (int)Mathf.Round(_amountToAddElementClicker * multiplier);
    }

    public void MultiplyTimeBetweenClicks(float multiplier)
    {
        _timeBetweenClicks = _timeBetweenClicks / multiplier;
    }
}
