using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropdownDeactivator : MonoBehaviour
{
    public Collider2D[] colliders;

    public void DeactivateDropdown()
    {
        gameObject.SetActive(false);
    }

    public void ActivateColliders()
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].enabled = !colliders[i].enabled;
        }
    }
}
