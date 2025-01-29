// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class CursorImgController : MonoBehaviour
// {
//     public Texture2D cursorTexture;
//     private Vector2 hotSpot = Vector2.zero;
//     private CursorMode cursorMode = CursorMode.Auto;
//     private int interactiveLayer;

//     void Start()
//     {
//         interactiveLayer = LayerMask.NameToLayer("Interactive");
//     }

//     void Update()
//     {
//         // Raycast from the camera to the mouse position
//         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//         RaycastHit hit;

//         if (Physics.Raycast(ray, out hit))
//         {
//             // Check if the hit object is in the Interactive layer
//             if (hit.collider.gameObject.layer == interactiveLayer)
//             {
//                 Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
//             }
//             else
//             {
//                 Cursor.SetCursor(null, Vector2.zero, cursorMode);
//             }
//         }
//         else
//         {
//             Cursor.SetCursor(null, Vector2.zero, cursorMode);
//         }
//     }
// }