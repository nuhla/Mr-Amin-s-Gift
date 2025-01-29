using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PassageVedioController : MonoBehaviour
{
    [SerializeField]

    private VideoPlayer videoPlaye;
    // Start is called before the first frame update
    void Start()
    {
        videoPlaye = videoPlaye == null ? GameObject.Find("ScreenOfVedio").GetComponent<VideoPlayer>() : videoPlaye;


    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            try
            {
                //if (videoPlaye.isPlaying) videoPlaye.Stop(); else
                videoPlaye.Play();
            }
            catch
            {
                Debug.LogError("Vedio do not Exist or you changed the pakyer name");
            }

        }
    }
}
