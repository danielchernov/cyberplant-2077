using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    Animator mainMenuAnimator;

    [SerializeField]
    GameObject _mainGame;

    [SerializeField]
    GameObject _options;

    [SerializeField]
    GameObject _mainMenu;

    [SerializeField]
    GameObject _credits;

    [SerializeField]
    AudioMenu _audioMenu;

    private void Start()
    {
        mainMenuAnimator = GetComponent<Animator>();
    }

    public void PlayButton()
    {
        mainMenuAnimator.SetTrigger("FadeOut");
        _mainGame.SetActive(true);
        _options.SetActive(true);
        _audioMenu.ChangeTrack(Random.Range(0, _audioMenu.tracks.Length));
    }

    // public void ContinueButton()
    // {
    //     mainMenuAnimator.SetTrigger("FadeOut");
    //     _mainGame.SetActive(true);
    //     _options.SetActive(true);
    //     _audioMenu.ChangeTrack(Random.Range(0, _audioMenu.tracks.Length));
    // }



    public void CreditsButton()
    {
        _credits.SetActive(true);
        _mainMenu.SetActive(false);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void BackButton()
    {
        _credits.SetActive(false);
        _mainMenu.SetActive(true);
    }

    public void DeactivateMainMenu()
    {
        gameObject.SetActive(false);
    }

    public void TextFadeIn(Animator animator)
    {
        animator.SetBool("fadeIn", true);
    }

    public void TextFadeOut(Animator animator)
    {
        animator.SetBool("fadeIn", false);
    }
}
