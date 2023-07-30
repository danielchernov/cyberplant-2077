using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ElementsManager : MonoBehaviour
{
    [SerializeField]
    Transform _water;

    [SerializeField]
    Transform _sunlight;

    [SerializeField]
    Transform _electricity;

    [SerializeField]
    TextMeshPro _waterText;

    [SerializeField]
    TextMeshPro _sunlightText;

    [SerializeField]
    TextMeshPro _electricityText;

    public float WaterMaxValue = 100;

    public float WaterCurrentValue = 100;

    public float SunlightMaxValue = 100;

    public float SunlightCurrentValue = 100;

    public float ElectricityMaxValue = 100;

    public float ElectricityCurrentValue = 100;

    public void UseWater(float waterAmount)
    {
        WaterCurrentValue -= waterAmount;
        UpdateWaterUI();
    }

    public void UseSunlight(float sunlightAmount)
    {
        SunlightCurrentValue -= sunlightAmount;
        UpdateSunlightUI();
    }

    public void UseElectricity(float electricityAmount)
    {
        ElectricityCurrentValue -= electricityAmount;
        UpdateElectricityUI();
    }

    public void AddWater(float waterAmount)
    {
        WaterCurrentValue += waterAmount;
        UpdateWaterUI();
    }

    public void AddSunlight(float sunlightAmount)
    {
        SunlightCurrentValue += sunlightAmount;
        UpdateSunlightUI();
    }

    public void AddElectricity(float electricityAmount)
    {
        ElectricityCurrentValue += electricityAmount;
        UpdateElectricityUI();
    }

    void UpdateWaterUI()
    {
        float uiScale = Mathf.InverseLerp(0, WaterMaxValue, WaterCurrentValue);
        uiScale = Mathf.Lerp(0, 0.925f, uiScale);

        _water.GetChild(1).localScale = new Vector3(_water.GetChild(1).localScale.x, uiScale, 0);
        _waterText.text = WaterCurrentValue + "/" + WaterMaxValue;
    }

    void UpdateSunlightUI()
    {
        float uiScale = Mathf.InverseLerp(0, SunlightMaxValue, SunlightCurrentValue);
        uiScale = Mathf.Lerp(0, 0.925f, uiScale);

        _sunlight.GetChild(1).localScale = new Vector3(
            _sunlight.GetChild(1).localScale.x,
            uiScale,
            0
        );

        _sunlightText.text = SunlightCurrentValue + "/" + SunlightMaxValue;
    }

    void UpdateElectricityUI()
    {
        float uiScale = Mathf.InverseLerp(0, ElectricityMaxValue, ElectricityCurrentValue);
        uiScale = Mathf.Lerp(0, 0.925f, uiScale);

        _electricity.GetChild(1).localScale = new Vector3(
            _electricity.GetChild(1).localScale.x,
            uiScale,
            0
        );

        _electricityText.text = ElectricityCurrentValue + "/" + ElectricityMaxValue;
    }
}
