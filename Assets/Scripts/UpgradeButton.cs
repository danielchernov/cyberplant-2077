using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField]
    Upgrades upgradeID;

    [SerializeField]
    float price;

    UpgradesManager upgradesManager;

    [SerializeField]
    PlantManager plantManager;

    [SerializeField]
    TextMeshPro costText;

    [SerializeField]
    Animator upgradeNameAnimator;

    [SerializeField]
    TextMeshPro upgradeName;

    [SerializeField]
    TextMeshPro upgradeDescription;

    [SerializeField]
    AudioSource SFXAudio;

    [SerializeField]
    AudioClip[] SFXClips;

    [SerializeField]
    AudioClip SFXNoMoney;

    [SerializeField]
    string upgradeNameToAdd = "Default Upgrade";

    [SerializeField]
    string upgradeDescriptionToAdd = "Default Description";

    [SerializeField]
    GameObject _tutorialMenu;

    public float UpgradeMultiplier = 1;

    Animator buttonAnimator;
    SpriteRenderer priceColor;

    private void Start()
    {
        buttonAnimator = gameObject.GetComponent<Animator>();
        upgradesManager = transform.parent.parent.GetComponent<UpgradesManager>();

        priceColor = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    private void OnMouseOver()
    {
        if (_tutorialMenu.activeSelf)
            return;
        if (price <= plantManager.GetScore())
        {
            priceColor.color = new Color(0, 1, 0.5f, 0);
        }
        else
        {
            priceColor.color = new Color(1, 0.5f, 0, 0);
        }
    }

    private void OnMouseEnter()
    {
        if (_tutorialMenu.activeSelf)
            return;
        buttonAnimator.SetBool("isHovering", true);
        upgradeNameAnimator.SetBool("isActive", true);
        costText.text = price.ToString();
        upgradeName.text = upgradeNameToAdd;
        upgradeDescription.text = upgradeDescriptionToAdd;

        CursorChanger.Instance.ChangeCursorHand();
    }

    private void OnMouseExit()
    {
        if (_tutorialMenu.activeSelf)
            return;
        buttonAnimator.SetBool("isHovering", false);
        upgradeNameAnimator.SetBool("isActive", false);

        costText.text = "";

        CursorChanger.Instance.ChangeCursorArrow();
    }

    private void OnMouseDown()
    {
        if (_tutorialMenu.activeSelf)
            return;
        if (price <= plantManager.GetScore())
        {
            plantManager.SubstractFromScore((int)price);

            price = Mathf.Round(price * 1.25f);
            costText.text = price.ToString();

            SFXAudio.PlayOneShot(SFXClips[Random.Range(0, SFXClips.Length)], 0.6f);
            upgradesManager.BuyUpgrade(upgradeID);
        }
        else
        {
            SFXAudio.PlayOneShot(SFXNoMoney, 0.3f);
        }
    }
}
