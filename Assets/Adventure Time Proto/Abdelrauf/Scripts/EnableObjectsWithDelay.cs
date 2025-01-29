using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObjectsWithDelay : MonoBehaviour
{
    public List<GameObject> objectsToEnable; // List of objects to enable
    public float initialDelay = 10f; // Delay for the first object
    public float subsequentDelay = 2f; // Delay for the subsequent objects

    void Start()
    {
        StartCoroutine(EnableObjectsCoroutine());
    }

    IEnumerator EnableObjectsCoroutine()
    {
        if (objectsToEnable.Count > 0)
        {
            // Enable the first object after initial delay
            objectsToEnable[0].SetActive(true);
            yield return new WaitForSeconds(initialDelay);

            // Enable the rest with subsequent delay
            for (int i = 1; i < objectsToEnable.Count; i++)
            {
                objectsToEnable[i].SetActive(true);
                yield return new WaitForSeconds(subsequentDelay);
            }
        }
    }
}
