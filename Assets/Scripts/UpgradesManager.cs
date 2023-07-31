using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradesManager : MonoBehaviour
{
    [SerializeField]
    TextMeshPro costText;

    [SerializeField]
    Animator upgradeDropdownAnimator;

    [SerializeField]
    ClickerManager[] clickers;

    Animator upgradeButtonAnimator;

    private void Start()
    {
        upgradeButtonAnimator = gameObject.GetComponentInChildren<Animator>();
    }

    private void OnMouseEnter()
    {
        upgradeButtonAnimator.SetBool("isHovering", true);
        costText.text = "";
    }

    private void OnMouseExit()
    {
        upgradeButtonAnimator.SetBool("isHovering", false);
    }

    void OnMouseDown()
    {
        upgradeButtonAnimator.SetTrigger("Clicked");

        if (upgradeDropdownAnimator.gameObject.activeSelf)
        {
            CloseDropdown();
        }
        else
        {
            OpenDropdown();
        }
    }

    public void BuyUpgrade(int upgradeID)
    {
        switch (upgradeID)
        {
            case 0:
                if (!clickers[0].gameObject.activeSelf)
                {
                    clickers[0].gameObject.SetActive(true);
                }
                else
                {
                    clickers[0].AddClicker();
                }
                break;
            case 1:
                if (!clickers[1].gameObject.activeSelf)
                {
                    clickers[1].gameObject.SetActive(true);
                }
                else
                {
                    clickers[1].AddClicker();
                }
                break;
            case 2:
                if (!clickers[2].gameObject.activeSelf)
                {
                    clickers[2].gameObject.SetActive(true);
                }
                else
                {
                    clickers[2].AddClicker();
                }
                break;
            case 3:
                if (!clickers[3].gameObject.activeSelf)
                {
                    clickers[3].gameObject.SetActive(true);
                }
                else
                {
                    clickers[3].AddClicker();
                }
                break;

            default:
                break;
        }
    }

    void OpenDropdown()
    {
        upgradeDropdownAnimator.gameObject.SetActive(true);
        upgradeDropdownAnimator.SetBool("isOpen", true);
    }

    void CloseDropdown()
    {
        upgradeDropdownAnimator.SetBool("isOpen", false);
    }
}
