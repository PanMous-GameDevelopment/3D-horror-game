using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseState : MonoBehaviour
{
    // Make the mouse visible so it can click on buttons.
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
