using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsButtons : MonoBehaviour
{
    [SerializeField]
    ElementsManager _elementsManager;

    [SerializeField]
    ParticleSystem _holdVFX;

    [SerializeField]
    Animator _colorCircle;

    [SerializeField]
    int _buttonNumber = 0;

    [SerializeField]
    float _timerDuration = 1f;

    float _timer = 0;

    void OnMouseOver()
    {
        if (
            _buttonNumber == 0
            && _elementsManager.SunlightCurrentValue < _elementsManager.SunlightMaxValue
        )
        {
            if (!_holdVFX.isPlaying)
            {
                _holdVFX.Play();
                _colorCircle.SetBool("FadeIn", true);
            }

            if (_timer < _timerDuration)
            {
                _timer += Time.deltaTime;
            }
            else if (_timer >= _timerDuration)
            {
                _timer = 0;
                _elementsManager.AddSunlight(1);
            }
        }
        else if (
            _buttonNumber == 1
            && _elementsManager.WaterCurrentValue < _elementsManager.WaterMaxValue
        )
        {
            if (!_holdVFX.isPlaying)
            {
                _holdVFX.Play();
                _colorCircle.SetBool("FadeIn", true);
            }

            if (_timer < _timerDuration)
            {
                _timer += Time.deltaTime;
            }
            else if (_timer >= _timerDuration)
            {
                _timer = 0;
                _elementsManager.AddWater(1);
            }
        }
        else if (
            _buttonNumber == 2
            && _elementsManager.ElectricityCurrentValue < _elementsManager.ElectricityMaxValue
        )
        {
            if (!_holdVFX.isPlaying)
            {
                _holdVFX.Play();
                _colorCircle.SetBool("FadeIn", true);
            }

            if (_timer < _timerDuration)
            {
                _timer += Time.deltaTime;
            }
            else if (_timer >= _timerDuration)
            {
                _timer = 0;
                _elementsManager.AddElectricity(1);
            }
        }
        else
        {
            _holdVFX.Stop();
            _colorCircle.SetBool("FadeIn", false);
        }
    }

    void OnMouseExit()
    {
        _timer = 0;

        if (_holdVFX.isPlaying)
        {
            _holdVFX.Stop();
            _colorCircle.SetBool("FadeIn", false);
        }
    }
}
