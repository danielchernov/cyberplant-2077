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
    AudioSource _sfxAudio;

    [SerializeField]
    AudioClip[] _sfxClips;

    [SerializeField]
    int _buttonNumber = 0;

    [SerializeField]
    int _amountToAdd = 1;

    [SerializeField]
    float _timerDuration = 1f;

    float _timer = 0;

    [SerializeField]
    GameObject _tutorialMenu;

    void OnMouseOver()
    {
        if (_tutorialMenu.activeSelf)
            return;

        if (
            _buttonNumber == 0
            && _elementsManager.SunlightCurrentValue < _elementsManager.SunlightMaxValue
        )
        {
            CursorChanger.Instance.ChangeCursorHand();

            if (!_holdVFX.isPlaying)
            {
                _holdVFX.Play();
                _colorCircle.SetBool("FadeIn", true);
            }

            if (!_sfxAudio.isPlaying)
            {
                _sfxAudio.PlayOneShot(_sfxClips[1], 0.3f);
            }

            if (_timer < _timerDuration)
            {
                _timer += Time.deltaTime;
            }
            else if (_timer >= _timerDuration)
            {
                _timer = 0;
                _elementsManager.AddSunlight(
                    _amountToAdd,
                    true,
                    transform.position,
                    new Color(1, 0.6f, 0, 1)
                );
            }
        }
        else if (
            _buttonNumber == 1
            && _elementsManager.WaterCurrentValue < _elementsManager.WaterMaxValue
        )
        {
            CursorChanger.Instance.ChangeCursorHand();

            if (!_holdVFX.isPlaying)
            {
                _holdVFX.Play();
                _colorCircle.SetBool("FadeIn", true);
            }

            if (!_sfxAudio.isPlaying)
            {
                _sfxAudio.PlayOneShot(_sfxClips[0], 0.3f);
            }

            if (_timer < _timerDuration)
            {
                _timer += Time.deltaTime;
            }
            else if (_timer >= _timerDuration)
            {
                _timer = 0;
                _elementsManager.AddWater(
                    _amountToAdd,
                    true,
                    transform.position,
                    new Color(0, 0.6f, 1, 1)
                );
            }
        }
        else if (
            _buttonNumber == 2
            && _elementsManager.ElectricityCurrentValue < _elementsManager.ElectricityMaxValue
        )
        {
            CursorChanger.Instance.ChangeCursorHand();

            if (!_holdVFX.isPlaying)
            {
                _holdVFX.Play();
                _colorCircle.SetBool("FadeIn", true);
            }

            if (!_sfxAudio.isPlaying)
            {
                _sfxAudio.PlayOneShot(_sfxClips[2], 0.3f);
            }

            if (_timer < _timerDuration)
            {
                _timer += Time.deltaTime;
            }
            else if (_timer >= _timerDuration)
            {
                _timer = 0;
                _elementsManager.AddElectricity(
                    _amountToAdd,
                    true,
                    transform.position,
                    new Color(0.6f, 0, 1, 1)
                );
            }
        }
        else
        {
            _holdVFX.Stop();
            _colorCircle.SetBool("FadeIn", false);

            if (_sfxAudio.isPlaying)
            {
                _sfxAudio.Stop();
            }

            CursorChanger.Instance.ChangeCursorArrow();
        }
    }

    void OnMouseExit()
    {
        if (_tutorialMenu.activeSelf)
            return;

        _timer = 0;

        if (_holdVFX.isPlaying)
        {
            _holdVFX.Stop();
            _colorCircle.SetBool("FadeIn", false);
        }

        if (_sfxAudio.isPlaying)
        {
            _sfxAudio.Stop();
        }

        CursorChanger.Instance.ChangeCursorArrow();
    }

    public void MultiplyAmountToAdd(float multiplier)
    {
        _amountToAdd = (int)Mathf.Round(_amountToAdd * multiplier);
    }
}
