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

    [SerializeField]
    Animator[] trianglesAnimator;

    [SerializeField]
    SpriteRenderer[] trianglesRenderer;

    public float WaterMaxValue = 500;

    public float WaterCurrentValue = 500;

    public float SunlightMaxValue = 500;

    public float SunlightCurrentValue = 500;

    public float ElectricityMaxValue = 500;

    public float ElectricityCurrentValue = 500;

    void Update()
    {
        if (SunlightCurrentValue < SunlightMaxValue * 0.2f)
        {
            trianglesAnimator[0].gameObject.SetActive(true);
            trianglesRenderer[0].color = new Color(1, 1, 1, 1);
        }
        else if (SunlightCurrentValue < SunlightMaxValue * 0.4f)
        {
            trianglesAnimator[0].gameObject.SetActive(true);
            trianglesRenderer[0].color = new Color(0.6f, 0.6f, 0.6f, 0.6f);
        }
        else if (SunlightCurrentValue < SunlightMaxValue * 0.6f)
        {
            trianglesAnimator[0].gameObject.SetActive(true);
            trianglesRenderer[0].color = new Color(0.4f, 0.4f, 0.4f, 0.4f);
        }
        else if (SunlightCurrentValue < SunlightMaxValue * 0.8f)
        {
            trianglesAnimator[0].gameObject.SetActive(true);
            trianglesRenderer[0].color = new Color(0.25f, 0.25f, 0.25f, 0.25f);
        }
        else
        {
            trianglesAnimator[0].gameObject.SetActive(false);
        }

        if (WaterCurrentValue < WaterMaxValue * 0.2f)
        {
            trianglesAnimator[1].gameObject.SetActive(true);
            trianglesRenderer[1].color = new Color(1, 1, 1, 1);
        }
        else if (WaterCurrentValue < WaterMaxValue * 0.4f)
        {
            trianglesAnimator[1].gameObject.SetActive(true);
            trianglesRenderer[1].color = new Color(0.6f, 0.6f, 0.6f, 0.6f);
        }
        else if (WaterCurrentValue < WaterMaxValue * 0.6f)
        {
            trianglesAnimator[1].gameObject.SetActive(true);
            trianglesRenderer[1].color = new Color(0.4f, 0.4f, 0.4f, 0.4f);
        }
        else if (WaterCurrentValue < WaterMaxValue * 0.8f)
        {
            trianglesAnimator[1].gameObject.SetActive(true);
            trianglesRenderer[1].color = new Color(0.25f, 0.25f, 0.25f, 0.25f);
        }
        else
        {
            trianglesAnimator[1].gameObject.SetActive(false);
        }

        if (ElectricityCurrentValue < ElectricityMaxValue * 0.2f)
        {
            trianglesAnimator[2].gameObject.SetActive(true);
            trianglesRenderer[2].color = new Color(1, 1, 1, 1);
        }
        else if (ElectricityCurrentValue < ElectricityMaxValue * 0.4f)
        {
            trianglesAnimator[2].gameObject.SetActive(true);
            trianglesRenderer[2].color = new Color(0.6f, 0.6f, 0.6f, 0.6f);
        }
        else if (ElectricityCurrentValue < ElectricityMaxValue * 0.6f)
        {
            trianglesAnimator[2].gameObject.SetActive(true);
            trianglesRenderer[2].color = new Color(0.4f, 0.4f, 0.4f, 0.4f);
        }
        else if (ElectricityCurrentValue < ElectricityMaxValue * 0.8f)
        {
            trianglesAnimator[2].gameObject.SetActive(true);
            trianglesRenderer[2].color = new Color(0.25f, 0.25f, 0.25f, 0.25f);
        }
        else
        {
            trianglesAnimator[2].gameObject.SetActive(false);
        }
    }

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
        if (WaterCurrentValue < WaterMaxValue)
        {
            WaterCurrentValue += waterAmount;
            if (WaterCurrentValue > WaterMaxValue)
            {
                WaterCurrentValue = WaterMaxValue;
            }
            UpdateWaterUI();
        }
    }

    public void AddSunlight(float sunlightAmount)
    {
        if (SunlightCurrentValue < SunlightMaxValue)
        {
            SunlightCurrentValue += sunlightAmount;
            if (SunlightCurrentValue > SunlightMaxValue)
            {
                SunlightCurrentValue = SunlightMaxValue;
            }
            UpdateSunlightUI();
        }
    }

    public void AddElectricity(float electricityAmount)
    {
        if (ElectricityCurrentValue < ElectricityMaxValue)
        {
            ElectricityCurrentValue += electricityAmount;
            if (ElectricityCurrentValue > ElectricityMaxValue)
            {
                ElectricityCurrentValue = ElectricityMaxValue;
            }
            UpdateElectricityUI();
        }
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

    public void MultiplySunlightMaxAmount(float multiplier)
    {
        SunlightCurrentValue += (int)(
            Mathf.Round(SunlightMaxValue * multiplier) - SunlightMaxValue
        );
        SunlightMaxValue = (int)Mathf.Round(SunlightMaxValue * multiplier);
        UpdateSunlightUI();
    }

    public void MultiplyWaterMaxAmount(float multiplier)
    {
        WaterCurrentValue += (int)(Mathf.Round(WaterMaxValue * multiplier) - WaterMaxValue);
        WaterMaxValue = (int)Mathf.Round(WaterMaxValue * multiplier);
        UpdateWaterUI();
    }

    public void MultiplyElectricityMaxAmount(float multiplier)
    {
        ElectricityCurrentValue += (int)(
            Mathf.Round(ElectricityMaxValue * multiplier) - ElectricityMaxValue
        );
        ElectricityMaxValue = (int)Mathf.Round(ElectricityMaxValue * multiplier);
        UpdateElectricityUI();
    }
}
