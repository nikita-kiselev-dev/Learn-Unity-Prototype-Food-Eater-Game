using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerCursor : MonoBehaviour
{
    [SerializeField] private Texture2D newCursor;

    private void Start()
    {
        Cursor.SetCursor(newCursor, Vector2.zero, CursorMode.ForceSoftware);
    }
}
