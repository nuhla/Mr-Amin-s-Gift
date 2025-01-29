using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AR : MonoBehaviour
{
    [SerializeField] private Transform player;
    float xAxis;
    float yAxis;
    public float cameraSpeed = 10f;
    public float cameraRotationSpeed = 4f;
    float yRotation;
    void LateUpdate()
    {
        transform.position = player.position;
    }

    void Update()
    {
        Vector3 newPosition = new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * cameraSpeed, 0, Input.GetAxis("Vertical") * Time.deltaTime * cameraSpeed);
        transform.position += newPosition;

        xAxis += Input.GetAxis("Mouse X");
        yAxis -= Input.GetAxis("Mouse Y");
        yRotation = Mathf.Clamp(yAxis * cameraRotationSpeed, -90, 90);
        transform.rotation = Quaternion.Euler(yRotation, xAxis * cameraRotationSpeed, 0);
    }


}
