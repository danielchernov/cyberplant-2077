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

    public void AddToScore()
    {
        _score++;
        _scoreText.text = _score.ToString();
    }

    public void SpawnScoreVFX()
    {
        GameObject addedScore = Instantiate(_addScoreVFX, transform.position, Quaternion.identity);

        Transform scoreText = addedScore.transform.GetChild(0);

        Vector3 spawnPosition = new Vector3(
            scoreText.position.x + Random.Range(1f, 2f),
            scoreText.position.y,
            scoreText.position.z
        );

        scoreText.position = spawnPosition;
    }
}
