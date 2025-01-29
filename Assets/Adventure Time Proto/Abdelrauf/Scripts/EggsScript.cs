using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassageAudioController : MonoBehaviour
{
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            try
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }
            catch
            {
                Debug.LogError("Audio source component is missing or there was an error playing the audio.");
            }
        }
    }
}
