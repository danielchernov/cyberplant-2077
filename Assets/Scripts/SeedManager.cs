using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedManager : MonoBehaviour
{
    [SerializeField]
    PlantManager plantManager;

    [SerializeField]
    ElementsManager elementsManager;

    [SerializeField]
    float _waterCost = 1;

    [SerializeField]
    float _sunlightCost = 1;

    [SerializeField]
    AudioSource SFXaudioSource;

    [SerializeField]
    AudioClip[] SFXaudioClip;

    void OnMouseDown()
    {
        if (
            elementsManager.GetWaterValue() >= _waterCost
            && elementsManager.GetSunglightValue() >= _sunlightCost
        )
        {
            plantManager.AddToScore();
            plantManager.SpawnScoreVFX();
            elementsManager.UseWater(_waterCost);
            elementsManager.UseSunlight(_sunlightCost);

            SFXaudioSource.PlayOneShot(SFXaudioClip[Random.Range(0, SFXaudioClip.Length)], 1f);
        }
    }
}
