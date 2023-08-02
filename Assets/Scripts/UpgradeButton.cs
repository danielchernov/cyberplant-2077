using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField]
    int upgradeID;

    [SerializeField]
    int price;

    UpgradesManager upgradesManager;

    [SerializeField]
    PlantManager plantManager;

    [SerializeField]
    TextMeshPro costText;

    Animator buttonAnimator;
    SpriteRenderer priceColor;

    private void Start()
    {
        buttonAnimator = gameObject.GetComponent<Animator>();
        upgradesManager = transform.parent.parent.GetComponent<UpgradesManager>();

        priceColor = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    private void OnMouseEnter()
    {
        if (price <= plantManager.GetScore())
        {
            priceColor.color = new Color(0, 1, 0.5f, 0);
        }
        else
        {
            priceColor.color = new Color(1, 0.5f, 0, 0);
        }

        buttonAnimator.SetBool("isHovering", true);
        costText.text = price.ToString();
    }

    private void OnMouseExit()
    {
        buttonAnimator.SetBool("isHovering", false);
        costText.text = "";
    }

    private void OnMouseDown()
    {
        if (price <= plantManager.GetScore())
        {
            plantManager.SubstractFromScore(price);

            price *= 2;
            costText.text = price.ToString();

            upgradesManager.BuyUpgrade(upgradeID);
        }
    }
}
