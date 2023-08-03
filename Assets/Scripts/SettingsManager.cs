using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    [SerializeField]
    GameObject mainGame;

    public void ActivateGame()
    {
        mainGame.SetActive(!mainGame.activeSelf);
    }

    public void DeactivateSettings()
    {
        gameObject.SetActive(false);
    }
}
