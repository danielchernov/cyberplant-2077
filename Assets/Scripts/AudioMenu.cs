using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class AudioMenu : MonoBehaviour
{
    public AudioMixer mainMixer;
    public Slider soundSliderSFX;
    public Slider soundSliderBGM;

    public AudioSource bgmAudio;
    public AudioClip[] tracks;
    public int currentTrack = 0;

    public TextMeshProUGUI trackText;
    public TextMeshProUGUI trackTitleText;

    void Start()
    {
        soundSliderSFX.value = PlayerPrefs.GetFloat("volumeSFX", 0.5f);
        soundSliderBGM.value = PlayerPrefs.GetFloat("volumeBGM", 0.5f);

        ChangeTrack(0);
    }

    void Update()
    {
        if (!bgmAudio.isPlaying)
        {
            ChangeTrackForward();
        }
    }

    public void ChangeTrack(int currentTrack)
    {
        bgmAudio.clip = tracks[currentTrack];
        bgmAudio.Play();
        trackText.text = (currentTrack + 1) + "/" + tracks.Length;
        ChangeTrackTitle(currentTrack);
    }

    public void SetVolumeSFX(float volume)
    {
        mainMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("volumeSFX", volume);
    }

    public void SetVolumeBGM(float volume)
    {
        mainMixer.SetFloat("BGMVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("volumeBGM", volume);
    }

    public void ChangeTrackForward()
    {
        if (currentTrack < tracks.Length - 1)
        {
            currentTrack++;
        }
        else
        {
            currentTrack = 0;
        }

        ChangeTrackTitle(currentTrack);

        bgmAudio.clip = tracks[currentTrack];
        bgmAudio.Play();

        trackText.text = (currentTrack + 1) + "/" + tracks.Length;
    }

    public void ChangeTrackBackwards()
    {
        if (currentTrack > 0)
        {
            currentTrack--;
        }
        else
        {
            currentTrack = tracks.Length - 1;
        }

        ChangeTrackTitle(currentTrack);

        bgmAudio.clip = tracks[currentTrack];
        bgmAudio.Play();

        trackText.text = (currentTrack + 1) + "/" + tracks.Length;
    }

    void ChangeTrackTitle(int currentTrack)
    {
        switch (currentTrack)
        {
            case 0:
                trackTitleText.text = "'Ay Amor!'";
                break;
            case 1:
                trackTitleText.text = "'Abrázame'";
                break;
            case 2:
                trackTitleText.text = "'Corazón'";
                break;
            case 3:
                trackTitleText.text = "'No Tiene Caso'";
                break;
            case 4:
                trackTitleText.text = "'Algo en Común'";
                break;
            case 5:
                trackTitleText.text = "'Mis Lágrimas'";
                break;
            case 6:
                trackTitleText.text = "'No!'";
                break;
            case 7:
                trackTitleText.text = "'Para que no me olvides'";
                break;
            case 8:
                trackTitleText.text = "'Ven Ven Ven'";
                break;
            case 9:
                trackTitleText.text = "'Mate y Cumbia'";
                break;
            default:
                trackTitleText.text = "";
                break;
        }
    }
}
