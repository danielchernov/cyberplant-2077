using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlantManager : MonoBehaviour
{
    [SerializeField]
    long _score = 0;

    [SerializeField]
    TextMeshProUGUI _scoreText;

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
    Animator _flowerAnimator;

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

    public long GetScore()
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
                SFXaudioSource.PlayOneShot(SFXclick[Random.Range(0, SFXclick.Length)], 0.5f);
                _seedAnimator.SetTrigger("SeedClicked");
            }

            if (_flower.position.y < 2.25f)
            {
                MoveFlower(0.0002f);
            }
            else if (!_flowerAnimator.GetBool("isAtTop"))
            {
                _flowerAnimator.SetBool("isAtTop", true);
            }

            _timesClicked++;

            if (GetTimesClicked() % valueToMod == 0)
            {
                _seedManager.MultiplyPointCost(2f);
                valueToMod = (int)Mathf.Round(valueToMod * 2f);
            }
        }
        else if (isClick)
        {
            SFXaudioSource.PlayOneShot(SFXnoResources, 1f);
        }
    }

    public void AddToScore(long amountToAdd)
    {
        _score += amountToAdd;
        _scoreText.text = WriteScore(_score);
    }

    public void SubstractFromScore(int amountToSubstract)
    {
        _score -= amountToSubstract;
        _scoreText.text = WriteScore(_score);
    }

    private string WriteScore(long score)
    {
        if (score < 100000)
        {
            _scoreText.fontSize = 36;
        }
        else if (score < 100000000)
        {
            _scoreText.fontSize = 32;
        }
        else
        {
            _scoreText.fontSize = 24;
        }

        return score.ToString("N0").Replace(",", ".");
    }

    public void SpawnScoreVFX(int amountToShow, bool isClick)
    {
        GameObject addedScore = ObjectPooler.Instance.SpawnFromPool(0);

        TextMeshPro scoreText = addedScore.GetComponentInChildren<TextMeshPro>();

        scoreText.text = "+" + amountToShow.ToString("N0").Replace(",", ".");

        Vector3 spawnPosition;

        if (isClick)
        {
            spawnPosition = new Vector3(Random.Range(-1.5f, -2f), Random.Range(0f, 0.5f), 0);

            scoreText.fontSize = 5;
            scoreText.faceColor = new Color(0.2f, 0.2f, 0.2f, 1);
            scoreText.outlineColor = new Color(1, 1, 1, 1);
        }
        else
        {
            spawnPosition = new Vector3(Random.Range(1.5f, 2f), Random.Range(0f, 0.5f), 0);
            scoreText.fontSize = 4;
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
