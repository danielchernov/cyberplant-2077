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

    [SerializeField]
    GameObject _tutorialMenu;

    [SerializeField]
    UpgradeButton[] _upgradeButtons;

    [SerializeField]
    float _upgradeDivisor = 3;

    Animator upgradeButtonAnimator;

    private void Start()
    {
        upgradeButtonAnimator = gameObject.GetComponentInChildren<Animator>();

        upgradesAmounts = new float[16];
    }

    private void OnMouseEnter()
    {
        if (_tutorialMenu.activeSelf)
            return;
        upgradeButtonAnimator.SetBool("isHovering", true);
        costText.text = "";

        CursorChanger.Instance.ChangeCursorHand();

        sfxAudio.PlayOneShot(sfxClips[2], 0.2f);
    }

    private void OnMouseExit()
    {
        if (_tutorialMenu.activeSelf)
            return;
        upgradeButtonAnimator.SetBool("isHovering", false);
        CursorChanger.Instance.ChangeCursorArrow();
    }

    void OnMouseDown()
    {
        if (_tutorialMenu.activeSelf)
            return;
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

    public void BuyUpgrade(Upgrades upgradeID)
    {
        switch (upgradeID)
        {
            case Upgrades.SeedClicker:
                // Adds Seed Clicker
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

                if (upgradesAmounts[0] >= 99)
                {
                    _upgradeButtons[3].gameObject.SetActive(false);
                }
                break;
            case Upgrades.GardenLight:
                // Adds Light Clicker
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

                if (upgradesAmounts[1] >= 99)
                {
                    _upgradeButtons[2].gameObject.SetActive(false);
                }
                break;
            case Upgrades.WateringCan:
                // Adds Water Clicker
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

                if (upgradesAmounts[2] >= 99)
                {
                    _upgradeButtons[1].gameObject.SetActive(false);
                }
                break;
            case Upgrades.Battery:
                // Adds Power Clicker
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

                if (upgradesAmounts[3] >= 99)
                {
                    _upgradeButtons[0].gameObject.SetActive(false);
                }
                break;
            case Upgrades.Fertilizer:
                // More points per Player Click
                upgradesAmounts[4]++;

                if (!upgradesCounters[1].transform.parent.parent.gameObject.activeSelf)
                {
                    upgradesCounters[1].transform.parent.parent.gameObject.SetActive(true);
                    CounterUpdate(upgradesCounters[1], upgradesAmounts[4]);
                }
                else
                {
                    CounterUpdate(upgradesCounters[1], upgradesAmounts[4]);
                    upgradesCounters[1].GetComponentInParent<Animator>().SetTrigger("AddedCounter");
                }

                upgradeMultiplier =
                    1
                    + (
                        _upgradeButtons[7].UpgradeMultiplier
                        / (upgradesAmounts[4] / _upgradeDivisor)
                    );

                seedManager.MultiplyAmountToAdd(upgradeMultiplier);

                if (upgradesAmounts[4] >= 99)
                {
                    _upgradeButtons[7].gameObject.SetActive(false);
                }
                break;
            case Upgrades.Trowel:
                // More Light Amount to Add on Hover
                upgradesAmounts[5]++;

                if (!upgradesCounters[2].transform.parent.parent.gameObject.activeSelf)
                {
                    upgradesCounters[2].transform.parent.parent.gameObject.SetActive(true);
                    CounterUpdate(upgradesCounters[2], upgradesAmounts[5]);
                }
                else
                {
                    CounterUpdate(upgradesCounters[2], upgradesAmounts[5]);
                    upgradesCounters[2].GetComponentInParent<Animator>().SetTrigger("AddedCounter");
                }

                upgradeMultiplier =
                    1
                    + (
                        _upgradeButtons[6].UpgradeMultiplier
                        / (upgradesAmounts[5] / _upgradeDivisor)
                    );

                clickers[1]
                    .GetComponentInParent<ElementsButtons>()
                    .MultiplyAmountToAdd(upgradeMultiplier);

                clickers[1]
                    .GetComponentInParent<ElementsButtons>()
                    .MultiplyHoverDuration(upgradeMultiplier);

                if (upgradesAmounts[5] >= 99)
                {
                    _upgradeButtons[6].gameObject.SetActive(false);
                }
                break;
            case Upgrades.Shears:
                // More Water Amount to Add on Hover
                upgradesAmounts[6]++;

                if (!upgradesCounters[3].transform.parent.parent.gameObject.activeSelf)
                {
                    upgradesCounters[3].transform.parent.parent.gameObject.SetActive(true);
                    CounterUpdate(upgradesCounters[3], upgradesAmounts[6]);
                }
                else
                {
                    CounterUpdate(upgradesCounters[3], upgradesAmounts[6]);
                    upgradesCounters[3].GetComponentInParent<Animator>().SetTrigger("AddedCounter");
                }

                upgradeMultiplier =
                    1
                    + (
                        _upgradeButtons[5].UpgradeMultiplier
                        / (upgradesAmounts[6] / _upgradeDivisor)
                    );

                clickers[2]
                    .GetComponentInParent<ElementsButtons>()
                    .MultiplyAmountToAdd(upgradeMultiplier);

                clickers[2]
                    .GetComponentInParent<ElementsButtons>()
                    .MultiplyHoverDuration(upgradeMultiplier);

                if (upgradesAmounts[6] >= 99)
                {
                    _upgradeButtons[5].gameObject.SetActive(false);
                }
                break;
            case Upgrades.Rake:
                // More Power Amount to Add on Hover
                upgradesAmounts[7]++;

                if (!upgradesCounters[4].transform.parent.parent.gameObject.activeSelf)
                {
                    upgradesCounters[4].transform.parent.parent.gameObject.SetActive(true);
                    CounterUpdate(upgradesCounters[4], upgradesAmounts[7]);
                }
                else
                {
                    CounterUpdate(upgradesCounters[4], upgradesAmounts[7]);
                    upgradesCounters[4].GetComponentInParent<Animator>().SetTrigger("AddedCounter");
                }

                upgradeMultiplier =
                    1
                    + (
                        _upgradeButtons[4].UpgradeMultiplier
                        / (upgradesAmounts[7] / _upgradeDivisor)
                    );

                clickers[3]
                    .GetComponentInParent<ElementsButtons>()
                    .MultiplyAmountToAdd(upgradeMultiplier);

                clickers[3]
                    .GetComponentInParent<ElementsButtons>()
                    .MultiplyHoverDuration(upgradeMultiplier);

                if (upgradesAmounts[7] >= 99)
                {
                    _upgradeButtons[4].gameObject.SetActive(false);
                }
                break;
            case Upgrades.PowerPlant:
                // More points per PowerClicker Click
                upgradesAmounts[8]++;

                if (!upgradesCounters[11].transform.parent.parent.parent.gameObject.activeSelf)
                {
                    upgradesCounters[11].transform.parent.parent.parent.gameObject.SetActive(true);
                    CounterUpdate(upgradesCounters[11], upgradesAmounts[8]);
                }
                else
                {
                    CounterUpdate(upgradesCounters[11], upgradesAmounts[8]);
                    upgradesCounters[11]
                        .GetComponentInParent<Animator>()
                        .SetTrigger("AddedCounter");
                }

                upgradeMultiplier =
                    1
                    + (
                        _upgradeButtons[12].UpgradeMultiplier
                        / (upgradesAmounts[8] / _upgradeDivisor)
                    );

                clickers[3].MultiplyAmountToAddElementClicker(upgradeMultiplier);

                if (upgradesAmounts[8] >= 99)
                {
                    _upgradeButtons[12].gameObject.SetActive(false);
                }
                break;

            case Upgrades.Dam:
                // More points per WaterClicker Click
                upgradesAmounts[9]++;

                if (!upgradesCounters[10].transform.parent.parent.parent.gameObject.activeSelf)
                {
                    upgradesCounters[10].transform.parent.parent.parent.gameObject.SetActive(true);
                    CounterUpdate(upgradesCounters[10], upgradesAmounts[9]);
                }
                else
                {
                    CounterUpdate(upgradesCounters[10], upgradesAmounts[9]);
                    upgradesCounters[10]
                        .GetComponentInParent<Animator>()
                        .SetTrigger("AddedCounter");
                }

                upgradeMultiplier =
                    1
                    + (
                        _upgradeButtons[13].UpgradeMultiplier
                        / (upgradesAmounts[9] / _upgradeDivisor)
                    );

                clickers[2].MultiplyAmountToAddElementClicker(upgradeMultiplier);

                if (upgradesAmounts[9] >= 99)
                {
                    _upgradeButtons[13].gameObject.SetActive(false);
                }
                break;

            case Upgrades.SolarPanel:
                // More points per LightClicker Click
                upgradesAmounts[10]++;

                if (!upgradesCounters[9].transform.parent.parent.parent.gameObject.activeSelf)
                {
                    upgradesCounters[9].transform.parent.parent.parent.gameObject.SetActive(true);
                    CounterUpdate(upgradesCounters[9], upgradesAmounts[10]);
                }
                else
                {
                    CounterUpdate(upgradesCounters[9], upgradesAmounts[10]);
                    upgradesCounters[9].GetComponentInParent<Animator>().SetTrigger("AddedCounter");
                }

                upgradeMultiplier =
                    1
                    + (
                        _upgradeButtons[14].UpgradeMultiplier
                        / (upgradesAmounts[10] / _upgradeDivisor)
                    );

                clickers[1].MultiplyAmountToAddElementClicker(upgradeMultiplier);

                if (upgradesAmounts[10] >= 99)
                {
                    _upgradeButtons[14].gameObject.SetActive(false);
                }
                break;

            case Upgrades.Tractor:
                // More points per SeedClicker Click
                upgradesAmounts[11]++;

                if (!upgradesCounters[8].transform.parent.parent.parent.gameObject.activeSelf)
                {
                    upgradesCounters[8].transform.parent.parent.parent.gameObject.SetActive(true);
                    CounterUpdate(upgradesCounters[8], upgradesAmounts[11]);
                }
                else
                {
                    CounterUpdate(upgradesCounters[8], upgradesAmounts[11]);
                    upgradesCounters[8].GetComponentInParent<Animator>().SetTrigger("AddedCounter");
                }

                upgradeMultiplier =
                    1
                    + (
                        _upgradeButtons[15].UpgradeMultiplier
                        / (upgradesAmounts[11] / _upgradeDivisor)
                    );

                clickers[0].MultiplyAmountToAddSeedClicker(upgradeMultiplier);

                if (upgradesAmounts[11] >= 99)
                {
                    _upgradeButtons[15].gameObject.SetActive(false);
                }
                break;

            case Upgrades.Generator:
                // More Max Amount of Power
                upgradesAmounts[12]++;

                if (!upgradesCounters[7].transform.parent.parent.gameObject.activeSelf)
                {
                    upgradesCounters[7].transform.parent.parent.gameObject.SetActive(true);
                    CounterUpdate(upgradesCounters[7], upgradesAmounts[12]);
                }
                else
                {
                    CounterUpdate(upgradesCounters[7], upgradesAmounts[12]);
                    upgradesCounters[7].GetComponentInParent<Animator>().SetTrigger("AddedCounter");
                }

                upgradeMultiplier =
                    1
                    + (
                        _upgradeButtons[8].UpgradeMultiplier
                        / (upgradesAmounts[12] / _upgradeDivisor)
                    );

                elementsManager.MultiplyElectricityMaxAmount(upgradeMultiplier);

                if (upgradesAmounts[12] >= 99)
                {
                    _upgradeButtons[8].gameObject.SetActive(false);
                }
                break;

            case Upgrades.Sprinkler:
                // More Max Amount of Water
                upgradesAmounts[13]++;

                if (!upgradesCounters[6].transform.parent.parent.gameObject.activeSelf)
                {
                    upgradesCounters[6].transform.parent.parent.gameObject.SetActive(true);
                    CounterUpdate(upgradesCounters[6], upgradesAmounts[13]);
                }
                else
                {
                    CounterUpdate(upgradesCounters[6], upgradesAmounts[13]);
                    upgradesCounters[6].GetComponentInParent<Animator>().SetTrigger("AddedCounter");
                }

                upgradeMultiplier =
                    1
                    + (
                        _upgradeButtons[9].UpgradeMultiplier
                        / (upgradesAmounts[13] / _upgradeDivisor)
                    );

                elementsManager.MultiplyWaterMaxAmount(upgradeMultiplier);

                if (upgradesAmounts[13] >= 99)
                {
                    _upgradeButtons[9].gameObject.SetActive(false);
                }
                break;
            case Upgrades.Greenhouse:
                // More Max Amount of Light
                upgradesAmounts[14]++;

                if (!upgradesCounters[5].transform.parent.parent.gameObject.activeSelf)
                {
                    upgradesCounters[5].transform.parent.parent.gameObject.SetActive(true);
                    CounterUpdate(upgradesCounters[5], upgradesAmounts[14]);
                }
                else
                {
                    CounterUpdate(upgradesCounters[5], upgradesAmounts[14]);
                    upgradesCounters[5].GetComponentInParent<Animator>().SetTrigger("AddedCounter");
                }

                upgradeMultiplier =
                    1
                    + (
                        _upgradeButtons[10].UpgradeMultiplier
                        / (upgradesAmounts[14] / _upgradeDivisor)
                    );

                elementsManager.MultiplySunlightMaxAmount(upgradeMultiplier);

                if (upgradesAmounts[14] >= 99)
                {
                    _upgradeButtons[10].gameObject.SetActive(false);
                }
                break;

            case Upgrades.GraphicCard:
                // More Points per Click AND More points per SeedClicker Click
                upgradesAmounts[15]++;

                if (!upgradesCounters[0].transform.parent.parent.gameObject.activeSelf)
                {
                    upgradesCounters[0].transform.parent.parent.gameObject.SetActive(true);
                    CounterUpdate(upgradesCounters[0], upgradesAmounts[15]);
                }
                else
                {
                    CounterUpdate(upgradesCounters[0], upgradesAmounts[15]);
                    upgradesCounters[0].GetComponentInParent<Animator>().SetTrigger("AddedCounter");
                }

                upgradeMultiplier = 1 + (_upgradeButtons[11].UpgradeMultiplier);

                seedManager.MultiplyAmountToAdd(upgradeMultiplier);
                clickers[0].MultiplyAmountToAddSeedClicker(upgradeMultiplier);
                clickers[0].MultiplyTimeBetweenClicks(1.02f);

                upgradeMultiplier = 1 + (_upgradeButtons[11].UpgradeMultiplier * 0.5f);

                clickers[1].MultiplyAmountToAddElementClicker(upgradeMultiplier);
                clickers[2].MultiplyAmountToAddElementClicker(upgradeMultiplier);
                clickers[3].MultiplyAmountToAddElementClicker(upgradeMultiplier);

                if (upgradesAmounts[15] >= 99)
                {
                    _upgradeButtons[11].gameObject.SetActive(false);
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
