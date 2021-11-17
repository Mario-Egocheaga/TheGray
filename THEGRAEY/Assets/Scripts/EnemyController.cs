using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    private bool playerSpotted;
    private int patrolTimer;
    private int point;
    private GameObject player;
    private Rigidbody enemyRB;
    private Vector3[] patrolPoints;
    //private Vector3 newVec;
    public float moveSpeed;
    public Vector3 point1;
    public Vector3 point2;
    public Vector3 point3;
    public AudioClip detectedClip;

    // Start is called before the first frame update
    void Start()
    {
        point = 1;
        player = GameObject.FindGameObjectWithTag("Player");
        playerSpotted = false;
        enemyRB = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerSpotted)
        {
            moveSpeed = 6f;
            //Rotate to look at player
            transform.LookAt(player.transform.position);
            //Move towards player
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        else
        {
            if (patrolTimer < 0)
            {
                transform.LookAt(patrolPoints[point]); //Patrol a 40x40 area
            }
            else
            {
                moveSpeed = 2f;
                //enemyRB.MovePosition(newVec * Time.deltaTime * moveSpeed);
                transform.position += transform.forward * moveSpeed * Time.deltaTime; //Move forward towards position
                patrolTimer--;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerSpotted = true;
            AudioSource.PlayClipAtPoint(detectedClip, this.transform.position);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerSpotted = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Tristans Scene");
        }
    }
}
