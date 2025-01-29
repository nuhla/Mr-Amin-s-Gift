using UnityEngine;

public class SafinaMovement : MonoBehaviour
{
    private float StartPos = 0;
    private float localRotation = 0;
    void Start()
    {
        StartPos = transform.localPosition.y;
        localRotation = transform.rotation.x;
    }

    private void FixedUpdate()
    {
        //loaclPos = StartPos + Mathf.Sin(Time.time * _speed) * _amplitude;
        //transform.localPosition = new Vector3(transform.localPosition.x, loaclPos, transform.localPosition.z);
        float localRota = localRotation + Mathf.Cos(Time.time) * 200;
        transform.rotation = Quaternion.Euler(new Vector3(Mathf.Deg2Rad * localRota, transform.rotation.y, transform.rotation.z));
    }
}

