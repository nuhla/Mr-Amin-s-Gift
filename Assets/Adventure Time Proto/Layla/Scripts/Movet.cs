using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movet : MonoBehaviour
{
    public Transform[] targets;
    int index = 0;
    float step = 0f;

    Vector3 source;
    Vector3 dest;

    void Start()
    {
        transform.position += Vector3.one * 2;
        source = transform.position;
    }

    void Update()
    {
       
        
            step += Time.deltaTime;
            if (step >= 1 && index < targets.Length)
            {
                index++;
                source = targets[index - 1].position;
                step = 0f;
            }

            if (index < targets.Length)
            {
                dest = targets[index].position;
                transform.position = Vector3.Slerp(source, dest, step );
                
            }
            if(index >= targets.Length)
            {
                index = 0;
            }

           
        
            
        
    }
}
