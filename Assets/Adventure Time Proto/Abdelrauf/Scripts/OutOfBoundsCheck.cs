using UnityEngine;

public class OutOfBoundsCheck : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        other.transform.position = new Vector3(other.transform.position.x, 100, other.transform.position.z);
    }

}
