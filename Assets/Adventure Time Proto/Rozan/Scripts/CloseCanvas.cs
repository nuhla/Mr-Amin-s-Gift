using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloseCanvas : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    void Update()
    {
        if ((Input.GetKey(KeyCode.E) || Input.GetMouseButtonUp(0)) && canvas.gameObject.activeSelf)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
                canvas.gameObject.SetActive(false);
        }
    }
}
