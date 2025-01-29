using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip mobileSound;
    public AudioSource mobileAudioSource;
    public AudioSource audioPrisonSource;
    public Transform targetGameObject;
    public Transform player;
    public Transform prisonObject;
    public GameObject instructionsCanvas;

    private bool gateIsClosed = true;
    private bool isRead = false;


    void Start()
    {
        StartCoroutine(MakeSound());

    }
    void Update()
    {
        CheckIfNearSkeleton();

    }
    IEnumerator MakeSound()
    {
        yield return new WaitForSeconds(5);
        mobileAudioSource.clip = mobileSound;
        mobileAudioSource?.Play();
    }
    private void CheckIfNearSkeleton()
    {
        float distance = Vector3.Distance(player.position, targetGameObject.position);

        if (distance <= 3f)
        {
            mobileAudioSource?.Stop();
            instructionsCanvas.SetActive(true);
            isRead = true;
        }
        else
        {
            instructionsCanvas.SetActive(false);
        }
        if (isRead && distance > 5f)
        {
            MakePrisonSound();
            OpenPrison();
        }
    }
    public void MakePrisonSound()
    {

        if (!audioPrisonSource.isPlaying && gateIsClosed)
        {
            audioPrisonSource?.Play();
            gateIsClosed = false;
        }
    }
    private void OpenPrison()
    {
        prisonObject.localPosition = Vector3.Lerp(prisonObject.localPosition, new Vector3(prisonObject.localPosition.x, 100f, prisonObject.localPosition.z), Time.deltaTime * 3f);
    }

}
