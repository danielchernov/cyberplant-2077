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
    TextMeshPro[] upgradesCounters;

    [SerializeField]
    SeedManager seedManager;

    [SerializeField]
    ElementsManager elementsManager;

    [SerializeField]
    AudioSource sfxAudio;

    [SerializeField]
    AudioClip[] sfxClips;

    [SerializeField]
    float[] upgradesAmounts;

    [SerializeField]
    float upgradeMultiplier = 2;

    Animator upgradeButtonAnimator;

    private void Start()
    {
        upgradeButtonAnimator = gameObject.GetComponentInChildren<Animator>();

        upgradesAmounts = new float[16];
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
                upgradesAmounts[0]++;

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
                upgradesAmounts[1]++;

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
                upgradesAmounts[2]++;

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
                upgradesAmounts[3]++;

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
                upgradesAmounts[4]++;

                if (!upgradesCounters[0].transform.parent.parent.gameObject.activeSelf)
                {
                    upgradesCounters[0].transform.parent.parent.gameObject.SetActive(true);
                    CounterUpdate(upgradesCounters[0], upgradesAmounts[4]);
                }
                else
                {
                    CounterUpdate(upgradesCounters[0], upgradesAmounts[4]);
                    upgradesCounters[0].GetComponentInParent<Animator>().SetTrigger("AddedCounter");
                }

                upgradeMultiplier = 1 + (upgradeMultiplier / upgradesAmounts[4]);

                seedManager.MultiplyAmountToAdd(upgradeMultiplier);
                break;
            case 5:
                upgradesAmounts[5]++;

                if (!upgradesCounters[1].transform.parent.parent.gameObject.activeSelf)
                {
                    upgradesCounters[1].transform.parent.parent.gameObject.SetActive(true);
                    CounterUpdate(upgradesCounters[1], upgradesAmounts[5]);
                }
                else
                {
                    CounterUpdate(upgradesCounters[1], upgradesAmounts[5]);
                    upgradesCounters[1].GetComponentInParent<Animator>().SetTrigger("AddedCounter");
                }

                upgradeMultiplier = 1 + (upgradeMultiplier / upgradesAmounts[5]);

                clickers[0].MultiplyAmountToAddSeedClicker(upgradeMultiplier);
                break;
            case 6:
                upgradesAmounts[6]++;

                if (!upgradesCounters[2].transform.parent.parent.gameObject.activeSelf)
                {
                    upgradesCounters[2].transform.parent.parent.gameObject.SetActive(true);
                    CounterUpdate(upgradesCounters[2], upgradesAmounts[6]);
                }
                else
                {
                    CounterUpdate(upgradesCounters[2], upgradesAmounts[6]);
                    upgradesCounters[2].GetComponentInParent<Animator>().SetTrigger("AddedCounter");
                }

                upgradeMultiplier = 1 + (upgradeMultiplier / upgradesAmounts[6]);

                clickers[1].MultiplyAmountToAddElementClicker(upgradeMultiplier);
                break;
            case 7:
                upgradesAmounts[7]++;

                if (!upgradesCounters[3].transform.parent.parent.gameObject.activeSelf)
                {
                    upgradesCounters[3].transform.parent.parent.gameObject.SetActive(true);
                    CounterUpdate(upgradesCounters[3], upgradesAmounts[7]);
                }
                else
                {
                    CounterUpdate(upgradesCounters[3], upgradesAmounts[7]);
                    upgradesCounters[3].GetComponentInParent<Animator>().SetTrigger("AddedCounter");
                }

                upgradeMultiplier = 1 + (upgradeMultiplier / upgradesAmounts[7]);

                clickers[2].MultiplyAmountToAddElementClicker(upgradeMultiplier);
                break;
            case 8:
                upgradesAmounts[8]++;

                if (!upgradesCounters[4].transform.parent.parent.gameObject.activeSelf)
                {
                    upgradesCounters[4].transform.parent.parent.gameObject.SetActive(true);
                    CounterUpdate(upgradesCounters[4], upgradesAmounts[8]);
                }
                else
                {
                    CounterUpdate(upgradesCounters[4], upgradesAmounts[8]);
                    upgradesCounters[4].GetComponentInParent<Animator>().SetTrigger("AddedCounter");
                }

                upgradeMultiplier = 1 + (upgradeMultiplier / upgradesAmounts[8]);

                clickers[3].MultiplyAmountToAddElementClicker(upgradeMultiplier);
                break;
            case 9:
                upgradesAmounts[9]++;

                if (!upgradesCounters[5].transform.parent.parent.gameObject.activeSelf)
                {
                    upgradesCounters[5].transform.parent.parent.gameObject.SetActive(true);
                    CounterUpdate(upgradesCounters[5], upgradesAmounts[9]);
                }
                else
                {
                    CounterUpdate(upgradesCounters[5], upgradesAmounts[9]);
                    upgradesCounters[5].GetComponentInParent<Animator>().SetTrigger("AddedCounter");
                }

                upgradeMultiplier = 1 + (upgradeMultiplier / upgradesAmounts[9]);

                elementsManager.MultiplySunlightMaxAmount(upgradeMultiplier);
                break;
            case 10:
                upgradesAmounts[10]++;

                if (!upgradesCounters[6].transform.parent.parent.gameObject.activeSelf)
                {
                    upgradesCounters[6].transform.parent.parent.gameObject.SetActive(true);
                    CounterUpdate(upgradesCounters[6], upgradesAmounts[10]);
                }
                else
                {
                    CounterUpdate(upgradesCounters[6], upgradesAmounts[10]);
                    upgradesCounters[6].GetComponentInParent<Animator>().SetTrigger("AddedCounter");
                }

                upgradeMultiplier = 1 + (upgradeMultiplier / upgradesAmounts[10]);

                elementsManager.MultiplyWaterMaxAmount(upgradeMultiplier);
                break;
            case 11:
                upgradesAmounts[11]++;

                if (!upgradesCounters[7].transform.parent.parent.gameObject.activeSelf)
                {
                    upgradesCounters[7].transform.parent.parent.gameObject.SetActive(true);
                    CounterUpdate(upgradesCounters[7], upgradesAmounts[11]);
                }
                else
                {
                    CounterUpdate(upgradesCounters[7], upgradesAmounts[11]);
                    upgradesCounters[7].GetComponentInParent<Animator>().SetTrigger("AddedCounter");
                }

                upgradeMultiplier = 1 + (upgradeMultiplier / upgradesAmounts[11]);

                elementsManager.MultiplyElectricityMaxAmount(upgradeMultiplier);
                break;
            case 12:
                upgradesAmounts[12]++;

                if (!upgradesCounters[8].transform.parent.parent.gameObject.activeSelf)
                {
                    upgradesCounters[8].transform.parent.parent.gameObject.SetActive(true);
                    CounterUpdate(upgradesCounters[8], upgradesAmounts[12]);
                }
                else
                {
                    CounterUpdate(upgradesCounters[8], upgradesAmounts[12]);
                    upgradesCounters[8].GetComponentInParent<Animator>().SetTrigger("AddedCounter");
                }

                upgradeMultiplier = 1 + (upgradeMultiplier / upgradesAmounts[12]);

                clickers[1]
                    .GetComponentInParent<ElementsButtons>()
                    .MultiplyAmountToAdd(upgradeMultiplier);
                break;
            case 13:
                upgradesAmounts[13]++;

                if (!upgradesCounters[9].transform.parent.parent.gameObject.activeSelf)
                {
                    upgradesCounters[9].transform.parent.parent.gameObject.SetActive(true);
                    CounterUpdate(upgradesCounters[9], upgradesAmounts[13]);
                }
                else
                {
                    CounterUpdate(upgradesCounters[9], upgradesAmounts[13]);
                    upgradesCounters[9].GetComponentInParent<Animator>().SetTrigger("AddedCounter");
                }

                upgradeMultiplier = 1 + (upgradeMultiplier / upgradesAmounts[13]);

                clickers[2]
                    .GetComponentInParent<ElementsButtons>()
                    .MultiplyAmountToAdd(upgradeMultiplier);
                break;
            case 14:
                upgradesAmounts[14]++;

                if (!upgradesCounters[10].transform.parent.parent.gameObject.activeSelf)
                {
                    upgradesCounters[10].transform.parent.parent.gameObject.SetActive(true);
                    CounterUpdate(upgradesCounters[10], upgradesAmounts[14]);
                }
                else
                {
                    CounterUpdate(upgradesCounters[10], upgradesAmounts[14]);
                    upgradesCounters[10]
                        .GetComponentInParent<Animator>()
                        .SetTrigger("AddedCounter");
                }

                upgradeMultiplier = 1 + (upgradeMultiplier / upgradesAmounts[14]);

                clickers[3]
                    .GetComponentInParent<ElementsButtons>()
                    .MultiplyAmountToAdd(upgradeMultiplier);
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

    void CounterUpdate(TextMeshPro counter, float upgradesAmount)
    {
        counter.text = upgradesAmount.ToString();
    }
}
