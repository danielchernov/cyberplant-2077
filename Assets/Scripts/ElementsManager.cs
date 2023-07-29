using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsManager : MonoBehaviour
{
    [SerializeField]
    Transform _water;

    [SerializeField]
    Transform _sunlight;

    [SerializeField]
    float _waterMaxValue = 100;

    [SerializeField]
    float _waterCurrentValue = 100;

    [SerializeField]
    float _sunlightMaxValue = 100;

    [SerializeField]
    float _sunlightCurrentValue = 100;

    public void UseWater(float waterAmount)
    {
        _waterCurrentValue -= waterAmount;
        UpdateWaterUI();
    }

    public void UseSunlight(float sunlightAmount)
    {
        _sunlightCurrentValue -= sunlightAmount;
        UpdateSunlightUI();
    }

    public float GetWaterValue()
    {
        return _waterCurrentValue;
    }

    public float GetSunglightValue()
    {
        return _sunlightCurrentValue;
    }

    void UpdateWaterUI()
    {
        float uiScale = Mathf.InverseLerp(0, _waterMaxValue, _waterCurrentValue);
        uiScale = Mathf.Lerp(0, 0.925f, uiScale);

        _water.GetChild(1).localScale = new Vector3(_water.GetChild(1).localScale.x, uiScale, 0);
    }

    void UpdateSunlightUI()
    {
        float uiScale = Mathf.InverseLerp(0, _sunlightMaxValue, _sunlightCurrentValue);
        uiScale = Mathf.Lerp(0, 0.925f, uiScale);

        _sunlight.GetChild(1).localScale = new Vector3(
            _sunlight.GetChild(1).localScale.x,
            uiScale,
            0
        );
    }
}
