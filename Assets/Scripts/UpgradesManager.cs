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

    [SerializeField]
    SeedManager seedManager;

    [SerializeField]
    ElementsManager elementsManager;

    [SerializeField]
    AudioSource sfxAudio;

    [SerializeField]
    AudioClip[] sfxClips;

    Animator upgradeButtonAnimator;

    private void Start()
    {
        upgradeButtonAnimator = gameObject.GetComponentInChildren<Animator>();
    }

    private void OnMouseEnter()
    {
        upgradeButtonAnimator.SetBool("isHovering", true);
        costText.text = "";

        CursorChanger.Instance.ChangeCursorHand();
    }

    private void OnMouseExit()
    {
        upgradeButtonAnimator.SetBool("isHovering", false);
        CursorChanger.Instance.ChangeCursorArrow();
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
                    clickers[0].GetComponent<Animator>().SetTrigger("AddedClicker");
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
                    clickers[1].GetComponent<Animator>().SetTrigger("AddedClicker");
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
                    clickers[2].GetComponent<Animator>().SetTrigger("AddedClicker");
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
                    clickers[3].GetComponent<Animator>().SetTrigger("AddedClicker");
                }
                break;
            case 4:
                seedManager.MultiplyAmountToAdd(1.5f);
                break;
            case 5:
                clickers[0].MultiplyAmountToAddSeedClicker(1.5f);
                break;
            case 6:
                clickers[1].MultiplyAmountToAddElementClicker(1.5f);
                break;
            case 7:
                clickers[2].MultiplyAmountToAddElementClicker(1.5f);
                break;
            case 8:
                clickers[3].MultiplyAmountToAddElementClicker(1.5f);
                break;
            case 9:
                elementsManager.MultiplySunlightMaxAmount(1.5f);
                break;
            case 10:
                elementsManager.MultiplyWaterMaxAmount(1.5f);
                break;
            case 11:
                elementsManager.MultiplyElectricityMaxAmount(1.5f);
                break;
            case 12:
                clickers[1].GetComponentInParent<ElementsButtons>().MultiplyAmountToAdd(1.5f);
                break;
            case 13:
                clickers[2].GetComponentInParent<ElementsButtons>().MultiplyAmountToAdd(1.5f);
                break;
            case 14:
                clickers[3].GetComponentInParent<ElementsButtons>().MultiplyAmountToAdd(1.5f);
                break;

            default:
                break;
        }
    }

    void OpenDropdown()
    {
        upgradeDropdownAnimator.gameObject.SetActive(true);
        upgradeDropdownAnimator.SetBool("isOpen", true);

        sfxAudio.PlayOneShot(sfxClips[0], 0.5f);
    }

    void CloseDropdown()
    {
        upgradeDropdownAnimator.SetBool("isOpen", false);

        sfxAudio.PlayOneShot(sfxClips[1], 0.5f);
    }
}
