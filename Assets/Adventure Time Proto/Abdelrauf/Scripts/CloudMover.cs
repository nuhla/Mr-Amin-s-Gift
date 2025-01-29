using UnityEngine;
using System.Collections;

public class CloudMover : MonoBehaviour
{
    [SerializeField] private LollipopClickHandler lollipopClickHandler;
    [SerializeField] private GameObject player;
    public Transform pointA; // The starting point
    public Transform pointB; // The destination point
    public float speed = 2.0f; // The speed of the cloud movement

    [SerializeField] public bool isMoving = false; // Tracks if the cloud is currently moving

    [SerializeField] private Vector3 playerOffset = new Vector3(0, 3, 0);
    private Rigidbody playerRb;
    private Rigidbody CloudRb;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private bool movingToB = true; // Determines the current direction of movement

    void Start()
    {
        playerRb = player.transform.GetComponent<Rigidbody>();
        CloudRb = transform.GetComponent<Rigidbody>();
        //CloudRb.isKinematic = true;
        // Initialize the start and end positions
        startPosition = pointA.position;
        endPosition = pointB.position;


        lollipopClickHandler.OnLollipopClicked += StartMoving; // subscribe to cloud transit event
    }

    // Start the cloud movement
    private void StartMoving()
    {
        if (!isMoving)
        {
            isMoving = true;
            StartCoroutine(MoveCloud());
        }
    }

    IEnumerator MoveCloud()
    {
        while (isMoving)
        {
            //CloudRb.isKinematic = false; // enable physics on cloud
            player.transform.SetParent(transform);
            playerRb.isKinematic = true;

            float step = speed * Time.deltaTime;
            Vector3 targetPosition = movingToB ? endPosition : startPosition;

            // Use Rigidbody.MovePosition to move towards the target position
            Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, step);
            CloudRb.MovePosition(newPosition);
            playerRb.MovePosition(newPosition + playerOffset);

            // Check if the cloud has reached the target position
            if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
            {
                isMoving = false; // stopped moving
                movingToB = !movingToB; // Switch direction

                player.transform.SetParent(null); //detach player
                playerRb.isKinematic = false;
                //  CloudRb.isKinematic = true; // disable physics on cloud
            }
            yield return null;
        }
    }
}