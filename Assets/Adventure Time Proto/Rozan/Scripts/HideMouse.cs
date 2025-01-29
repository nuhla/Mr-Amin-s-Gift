using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HideMouse : MonoBehaviour
{

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

}