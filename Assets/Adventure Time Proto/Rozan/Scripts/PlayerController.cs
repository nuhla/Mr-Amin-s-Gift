using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.Video;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform cameraTransform;
    private Transform player;
    [SerializeField] private CloudMover cloudMover;

    [SerializeField] private Transform VideoScreen;
    [SerializeField] private Sprite[] messageSprites;
    private Rigidbody rb;
    private Vector3 movement;
    public GameObject messageCanvas;
    public GameObject poles;
    public GameObject pointerCanvas;
    public Canvas ScreenCursore;
    private VideoPlayer videoPlayer;
    public float showPointerDistance = 15f;

    void Awake()
    {
        ScoreManager.totalScore = messageSprites.Length;
    }
    void Start()
    {
        player = gameObject.transform;
        rb = GetComponent<Rigidbody>();
        videoPlayer = VideoScreen.GetComponent<VideoPlayer>();
    }

    void Update()
    {
        MovePlayer();
        DetectMouseClick();
        ShowPointerForScreen();
        ShowPointer();

    }

    void FixedUpdate()
    {
        if (!cloudMover.isMoving)
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void DetectMouseClick()
    {
        if (Input.GetMouseButtonUp(0))
        {
            bool isRayCast = Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)), out RaycastHit hit, 1000f);
            if (isRayCast)
            {
                if (hit.collider.name == "minusVolum")
                {

                    try
                    {
                        float volum = videoPlayer.GetDirectAudioVolume(0);
                        if (volum > 0) videoPlayer.SetDirectAudioVolume(0, volum - .1f);
                    }
                    catch
                    {
                        Debug.Log("mute");
                    }
                }
                else if (hit.collider.name == "PlussVolum")
                {
                    try
                    {
                        float volum = videoPlayer.GetDirectAudioVolume(0);
                        if (volum < 1) videoPlayer.SetDirectAudioVolume(0, volum + .1f);
                    }
                    catch
                    {
                        Debug.Log("maximum");
                    }
                }
                else
                {
                    GetStudentName(hit);
                }

            }

           

        }
    }

    private void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        movement = (cameraTransform.forward * moveZ + cameraTransform.right * moveX).normalized;
        movement.y = 0;
    }
    private void ShowPointer()
    {
        Image pointerImage = pointerCanvas.GetComponentsInChildren<Image>(true).First();
        pointerImage.gameObject.SetActive(CheckIfNearPoles() || IsNearElevatorCloud());
    }


    private bool CheckIfNearPoles()
    {
        foreach (Transform child in poles.transform)
            if (Vector3.Distance(player.position, child.position) <= showPointerDistance) return true;
        return false;
    }

    private void ShowPointerForScreen()
    {
        Image screenCursoreImage = ScreenCursore.GetComponentsInChildren<Image>(true).First();
        screenCursoreImage.gameObject.SetActive(CheckIfNearVedioScreen());
    }
    private bool CheckIfNearVedioScreen()
    {

        if (Vector3.Distance(transform.position, VideoScreen.position) <= showPointerDistance) { return true; }
        else
        {

            return false;
        }
    }
    private bool IsNearElevatorCloud()
    {
        float cloudDistance = Vector3.Distance(player.position, cloudMover.transform.position);
        return cloudDistance <= showPointerDistance && !cloudMover.isMoving;
    }
    private void GetStudentName(RaycastHit hit)
    {
        Image messageImage = messageCanvas.GetComponentsInChildren<Image>(true).Last();
        foreach (Sprite nameOfStudent in messageSprites)
        {
            if (hit.collider.gameObject.tag == nameOfStudent.name)
            {
                List<Sprite> filterdImage = messageSprites.Where(imgSprite => imgSprite == nameOfStudent).ToList();
                messageImage.sprite = filterdImage.First();
                messageCanvas.SetActive(true);
                ScoreManager.onScoreAdded(1, hit.collider.gameObject);
            }
        }

    }
}