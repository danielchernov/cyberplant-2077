using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    Animator mainMenuAnimator;

    [SerializeField]
    GameObject mainGame;

    private void Start()
    {
        mainMenuAnimator = GetComponent<Animator>();
    }

    public void PlayButton()
    {
        mainMenuAnimator.SetTrigger("FadeOut");
        mainGame.SetActive(true);
    }

    public void ContinueButton()
    {
        mainMenuAnimator.SetTrigger("FadeOut");
        mainGame.SetActive(true);
    }

    public void ExitButton()
    {
        Application.Quit();
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
