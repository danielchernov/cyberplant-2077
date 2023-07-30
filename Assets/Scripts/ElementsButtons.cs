using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsButtons : MonoBehaviour
{
    [SerializeField]
    ElementsManager elementsManager;

    [SerializeField]
    ParticleSystem holdVFX;

    [SerializeField]
    int _buttonNumber = 0;

    [SerializeField]
    float _timerDuration = 1f;

    float _timer = 0;

    void OnMouseOver()
    {
        if (_buttonNumber == 0 && elementsManager.WaterCurrentValue < elementsManager.WaterMaxValue)
        {
            if (!holdVFX.isPlaying)
            {
                holdVFX.Play();
            }

            if (_timer < _timerDuration)
            {
                _timer += Time.deltaTime;
            }
            else if (_timer >= _timerDuration)
            {
                _timer = 0;
                elementsManager.AddWater(1);
            }
        }
        else if (
            _buttonNumber == 1
            && elementsManager.SunlightCurrentValue < elementsManager.SunlightMaxValue
        )
        {
            if (!holdVFX.isPlaying)
            {
                holdVFX.Play();
            }

            if (_timer < _timerDuration)
            {
                _timer += Time.deltaTime;
            }
            else if (_timer >= _timerDuration)
            {
                _timer = 0;
                elementsManager.AddSunlight(1);
            }
        }
        else if (
            _buttonNumber == 2
            && elementsManager.ElectricityCurrentValue < elementsManager.ElectricityMaxValue
        )
        {
            if (!holdVFX.isPlaying)
            {
                holdVFX.Play();
            }

            if (_timer < _timerDuration)
            {
                _timer += Time.deltaTime;
            }
            else if (_timer >= _timerDuration)
            {
                _timer = 0;
                elementsManager.AddElectricity(1);
            }
        }
        else
        {
            holdVFX.Stop();
        }
    }

    void OnMouseExit()
    {
        _timer = 0;

        if (holdVFX.isPlaying)
        {
            holdVFX.Stop();
        }
    }
}
