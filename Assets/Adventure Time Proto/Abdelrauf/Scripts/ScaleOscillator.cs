using UnityEngine;

public class ScaleOscillator : MonoBehaviour
{
    // Exposed variable to control the oscillation period
    [SerializeField]
    private float oscillationPeriod = 2f;

    // Original scale of the GameObject
    private Vector3 originalScale;

    private void Start()
    {
        // Store the original scale at the start
        originalScale = transform.localScale;
    }

    private void Update()
    {
        // Calculate the scale factor using a sine wave to oscillate between 1 and 2
        float scaleFactor = 1.5f + Mathf.Sin(Time.time * Mathf.PI * 2 / oscillationPeriod);

        // Apply the new scale
        transform.localScale = originalScale * scaleFactor;
    }
}
