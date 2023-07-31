using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesManager : MonoBehaviour
{
    [SerializeField]
    Animator upgradeDropdownAnimator;

    void OnMouseDown()
    {
        if (!upgradeDropdownAnimator.GetBool("isOpen"))
        {
            upgradeDropdownAnimator.SetBool("isOpen", true);
        }
        else
        {
            upgradeDropdownAnimator.SetBool("isOpen", false);
        }
    }
}
