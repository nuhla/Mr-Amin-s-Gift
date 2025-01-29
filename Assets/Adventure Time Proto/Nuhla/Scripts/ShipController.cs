using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
 
    [SerializeField]
    float CircularSpeed = .6f;
    // [SerializeField]
    // private float _speed = 1.44f;

    private float StartPos = 0;
    private float localRotation = 0;
    [SerializeField]
    private bool _infinitCycle = false;
    [SerializeField]
    private float period = 10;

    [SerializeField]
    private bool clockWise = false;
    [SerializeField]
    private float Radius = 61.9f;

    [SerializeField]
    private Vector3 center;



    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.localPosition.y;
        localRotation = transform.localRotation.x;

        center = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        StartCoroutine(MoveShipCircles());

    }



    private void FixedUpdate()
    {


        // loaclPos = StartPos + Mathf.Sin(Time.time * speed) * _amplitude;
        // transform.localPosition = new Vector3(transform.localPosition.x, loaclPos, transform.localPosition.z);

        // float localRota = localRotation + Mathf.Cos(Time.time) * 200;

        // transform.localRotation = Quaternion.Euler(new Vector3(Mathf.Deg2Rad * localRota, transform.rotation.y, transform.localPosition.z));




    }

    IEnumerator MoveShipCircles()
    {
        // Radius of the circle
        // Speed of the movement                                                             // Time for one full revolution (in seconds)
        float passtime = 0f;         // Time elapsed
        float angle = 0;


        bool looping = true;

        looping = !_infinitCycle ? passtime < period : true;
        while (looping)
        {
            looping = !_infinitCycle ? passtime < period : true;
            passtime += Time.deltaTime;

            if (!clockWise) angle -= CircularSpeed * Time.deltaTime;
            else angle += CircularSpeed * Time.deltaTime;






            // Calculate the x and z position based on the angle
            float x = center.x + Mathf.Cos(angle) * (Radius);
            float z = center.z + Mathf.Sin(angle) * (Radius);

            transform.position = new Vector3(x, center.y, z);

            Vector3 direction;
            if (!clockWise) direction = new Vector3(-Mathf.Sin(-angle), 0f, -Mathf.Cos(-angle));
            else direction = new Vector3(-Mathf.Sin(angle), 0f, Mathf.Cos(angle));

            transform.rotation = Quaternion.LookRotation(direction);
            yield return null;
        }



    }

}

