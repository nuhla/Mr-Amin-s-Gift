using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    public Transform player;       // Reference to the player
    public Transform targetObject; // The object to focus on
    public float focusDistance = 5f; // Distance to start focusing
    public float smoothSpeed = 2f;  // Speed of camera movement
    float xAxis;
    float yAxis;
    public float cameraSpeed = 10f;
    public float cameraRotationSpeed = 5f;
    
    void Start(){
        // targetObject = GameObject.FindGameObjectWithTag<>("");
    }
    void Update()
    {
        // Check the distance between the player and the target object
        float distance = Vector3.Distance(player.position, targetObject.position);
        if (distance <= focusDistance)
        {
            FocusOnTarget();
        }
        else
        {
            ResetCamera();
        }
    }

    void LateUpdate()
    {
        transform.position = player.position;
    }
    private void FocusOnTarget()
    {
        // Smoothly move the camera towards the target position
        Vector3 targetPosition = targetObject.position + new Vector3(0, 2, -5); // Adjust offset as needed
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothSpeed);

        // Smoothly rotate the camera to look at the target object
        Quaternion targetRotation = Quaternion.LookRotation(targetObject.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * smoothSpeed);
    }

    private void ResetCamera()
    {
        // Reset the camera's position and rotation (implement logic to return to default state)
        Vector3 newPosition = new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * cameraSpeed, 0, Input.GetAxis("Vertical") * Time.deltaTime * cameraSpeed);
        transform.position += newPosition;

        xAxis += Input.GetAxis("Mouse X");
        yAxis -= Input.GetAxis("Mouse Y");
        transform.rotation = Quaternion.Euler(yAxis, xAxis * cameraRotationSpeed, 0);
        // Example: Implement your default camera behavior here
    }
}
