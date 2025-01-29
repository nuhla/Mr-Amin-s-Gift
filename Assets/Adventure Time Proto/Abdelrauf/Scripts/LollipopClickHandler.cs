using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class LollipopClickHandler : MonoBehaviour
{
    public delegate void LollipopClicked();
    public event LollipopClicked OnLollipopClicked;
    [SerializeField] private Transform LoliPivot;
    private Vector3 leverColliderA;
    private Vector3 leverColliderB;
    private bool rotatingForward = true;
    private bool isRotating = false;

    void OnMouseDown()
    {
        // Trigger the click event
        OnLollipopClicked?.Invoke();
    }
    void Start()
    {
        leverColliderA = transform.position;
        leverColliderB = new Vector3(24.6f, 66.19f, 351f);
        // Subscribe the rotation handler to the click event
        OnLollipopClicked += HandleLollipopClick;
    }

    void HandleLollipopClick()
    {
        if (!isRotating)
        {
            StartCoroutine(RotateOverTime(rotatingForward ? 30f : -30f));
            rotatingForward = !rotatingForward;

            transform.position = !rotatingForward ? leverColliderB : leverColliderA; // Controls the leverCollider's position
        }
    }

    IEnumerator RotateOverTime(float targetAngle)
    {
        isRotating = true;
        float duration = 1.0f;
        float elapsedTime = 0.0f;

        Quaternion initialRotation = LoliPivot.transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(targetAngle, LoliPivot.transform.rotation.eulerAngles.y, LoliPivot.transform.rotation.eulerAngles.z);

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            LoliPivot.transform.rotation = Quaternion.Lerp(initialRotation, targetRotation, t);
            yield return null;
        }

        isRotating = false;
    }
}
