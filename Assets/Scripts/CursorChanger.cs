using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChanger : MonoBehaviour
{
    private static CursorChanger _instance;
    public static CursorChanger Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("AudioManager is Null");
            }

            return _instance;
        }
    }

    [SerializeField]
    Texture2D[] cursorTextures;

    CursorMode cursorMode = CursorMode.Auto;
    Vector2 hotSpot = Vector2.zero;

    private void Awake()
    {
        _instance = this;
    }

    public void ChangeCursorArrow()
    {
        Cursor.SetCursor(cursorTextures[0], hotSpot, cursorMode);
    }

    public void ChangeCursorHand()
    {
        Cursor.SetCursor(cursorTextures[1], hotSpot, cursorMode);
    }
}
