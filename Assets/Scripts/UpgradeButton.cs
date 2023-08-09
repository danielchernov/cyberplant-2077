using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField]
    Upgrades upgradeID;

    [SerializeField]
    long _price;

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
    AudioClip SFXHoverButton;

    [SerializeField]
    string upgradeNameToAdd = "Default Upgrade";

    [SerializeField]
    string upgradeDescriptionToAdd = "Default Description";

    [SerializeField]
    GameObject _tutorialMenu;

    public float UpgradeMultiplier = 1;

    Animator buttonAnimator;
    SpriteRenderer priceColor;

    private void Awake()
    {
        buttonAnimator = gameObject.GetComponent<Animator>();
        upgradesManager = transform.parent.parent.GetComponent<UpgradesManager>();

        priceColor = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    private void OnMouseOver()
    {
        if (_tutorialMenu.activeSelf)
            return;
        if (_price <= plantManager.GetScore())
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
        costText.text = WritePrice(_price);
        upgradeName.text = upgradeNameToAdd;
        upgradeDescription.text = upgradeDescriptionToAdd;

        CursorChanger.Instance.ChangeCursorHand();

        SFXAudio.PlayOneShot(SFXHoverButton, 0.2f);
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

    private void OnDisable()
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
        if (_price <= plantManager.GetScore())
        {
            buttonAnimator.SetTrigger("Clicked");

            plantManager.SubstractFromScore((int)_price);

            _price = (long)Mathf.Round(_price * 1.25f);
            costText.text = WritePrice(_price);

            SFXAudio.PlayOneShot(SFXClips[Random.Range(0, SFXClips.Length)], 0.6f);
            upgradesManager.BuyUpgrade(upgradeID);
        }
        else
        {
            SFXAudio.PlayOneShot(SFXNoMoney, 0.3f);
        }
    }

    private string WritePrice(long price)
    {
        if (price < 100000)
        {
            costText.fontSize = 4;
        }
        else if (price < 100000000)
        {
            costText.fontSize = 3;
        }
        else
        {
            costText.fontSize = 2.2f;
        }

        return price.ToString("N0").Replace(",", ".");
    }
}
