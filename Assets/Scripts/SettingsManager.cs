using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    Animator _pauseMenuAnimator;

    [SerializeField]
    GameObject _mainGame;

    [SerializeField]
    GameObject _pauseMenu;

    [SerializeField]
    GameObject _creditsMenu;

    private void Start()
    {
        _pauseMenuAnimator = GetComponent<Animator>();
    }

    public void CreditsButton()
    {
        _creditsMenu.SetActive(true);
        _pauseMenu.SetActive(false);
    }

    public void BackButton()
    {
        _creditsMenu.SetActive(false);
        _pauseMenu.SetActive(true);
    }

    public void ResumeButton()
    {
        _pauseMenuAnimator.SetTrigger("FadeOut");
        Time.timeScale = 1;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }

    public void ActivateGame()
    {
        _mainGame.SetActive(!_mainGame.activeSelf);
    }

    public void DeactivateSettings()
    {
        gameObject.SetActive(false);
    }
}
