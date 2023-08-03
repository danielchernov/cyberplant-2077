using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButtons : MonoBehaviour
{
    Animator buttonAnimator;

    [SerializeField]
    GameObject tutorialMenu;

    [SerializeField]
    GameObject settingsMenu;

    [SerializeField]
    int buttonID = 0;

    void Start()
    {
        buttonAnimator = GetComponent<Animator>();
    }

    private void OnMouseEnter()
    {
        buttonAnimator.SetBool("isHovering", true);
        CursorChanger.Instance.ChangeCursorHand();
    }

    private void OnMouseExit()
    {
        buttonAnimator.SetBool("isHovering", false);
        CursorChanger.Instance.ChangeCursorArrow();
    }

    private void OnMouseDown()
    {
        if (buttonID == 0)
        {
            tutorialMenu.SetActive(!tutorialMenu.activeSelf);
        }
        else if (buttonID == 1)
        {
            if (!settingsMenu.activeSelf)
            {
                settingsMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                settingsMenu.GetComponent<Animator>().SetTrigger("FadeOut");
                Time.timeScale = 1;
            }
        }

        if (tutorialMenu.activeSelf)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
