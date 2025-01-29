using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    void OnMouseDown()
    {
        // Trigger the click event
        Debug.Log("clicked!!!!!!!!!!!!: " + transform.name);
    }
}
