using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlantManager : MonoBehaviour
{
    [SerializeField]
    int _score = 0;

    [SerializeField]
    TextMeshProUGUI _scoreText;

    [SerializeField]
    GameObject _addScoreVFX;

    [SerializeField]
    Animator _seedAnimator;

    [SerializeField]
    ElementsManager elementsManager;

    [SerializeField]
    AudioSource SFXaudioSource;

    [SerializeField]
    AudioClip[] SFXclick;

    [SerializeField]
    AudioClip SFXnoResources;

    [SerializeField]
    Transform _flower;

    [SerializeField]
    Transform _stalk;

    [SerializeField]
    int _timesClicked = 0;

    [SerializeField]
    SeedManager _seedManager;

    [SerializeField]
    int valueToMod = 100;

    public int GetScore()
    {
        return _score;
    }

    public int GetTimesClicked()
    {
        return _timesClicked;
    }

    public void ClickSeed(
        int amountToGain,
        int sunlightCost,
        int waterCost,
        int electricityCost,
        bool isClick
    )
    {
        if (
            elementsManager.WaterCurrentValue >= waterCost
            && elementsManager.SunlightCurrentValue >= sunlightCost
            && elementsManager.ElectricityCurrentValue >= electricityCost
        )
        {
            AddToScore(amountToGain);
            SpawnScoreVFX(amountToGain, isClick);
            elementsManager.UseWater(waterCost);
            elementsManager.UseSunlight(sunlightCost);
            elementsManager.UseElectricity(electricityCost);

            if (isClick)
            {
                SFXaudioSource.PlayOneShot(SFXclick[Random.Range(0, SFXclick.Length)], 1f);
                _seedAnimator.SetTrigger("SeedClicked");
            }

            if (_flower.position.y < 2.25f)
            {
                MoveFlower(0.0001f);
            }

            _timesClicked++;

            if (GetTimesClicked() % valueToMod == 0)
            {
                _seedManager.MultiplyPointCost(1.7f);
                valueToMod = (int)Mathf.Round(valueToMod * 1.7f);
            }
        }
        else if (isClick)
        {
            SFXaudioSource.PlayOneShot(SFXnoResources, 1f);
        }
    }

    public void AddToScore(int amountToAdd)
    {
        _score += amountToAdd;
        _scoreText.text = _score.ToString();
    }

    public void SubstractFromScore(int amountToSubstract)
    {
        _score -= amountToSubstract;
        _scoreText.text = _score.ToString();
    }

    public void SpawnScoreVFX(int amountToShow, bool isClick)
    {
        GameObject addedScore = Instantiate(_addScoreVFX);

        TextMeshPro scoreText = addedScore.GetComponentInChildren<TextMeshPro>();

        scoreText.text = "+" + amountToShow;

        Vector3 spawnPosition;

        if (isClick)
        {
            spawnPosition = new Vector3(
                addedScore.transform.position.x + Random.Range(-1.5f, -2f),
                addedScore.transform.position.y + Random.Range(0f, 0.5f),
                addedScore.transform.position.z
            );

            scoreText.fontSize *= 1f;
            scoreText.faceColor = new Color(0.2f, 0.2f, 0.2f, 1);
            scoreText.outlineColor = new Color(1, 1, 1, 1);
        }
        else
        {
            spawnPosition = new Vector3(
                addedScore.transform.position.x + Random.Range(1.5f, 2f),
                addedScore.transform.position.y + Random.Range(0f, 0.5f),
                addedScore.transform.position.z
            );
            scoreText.fontSize *= 0.8f;
            scoreText.faceColor = new Color(0, 0, 0, 1);
            scoreText.outlineColor = new Color(0.5f, 0.5f, 0.5f, 1);
        }

        addedScore.transform.position = spawnPosition;
    }

    private void MoveFlower(float amountToAdd)
    {
        Vector3 flowerPos = new Vector3(
            _flower.transform.position.x,
            _flower.transform.position.y + amountToAdd,
            _flower.transform.position.z
        );

        _flower.transform.position = flowerPos;

        Vector3 stalkScale = new Vector3(
            _stalk.localScale.x,
            _stalk.localScale.y + amountToAdd,
            _stalk.localScale.z
        );
        _stalk.localScale = stalkScale;
    }
}
