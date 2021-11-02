using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    private bool playerSpotted;
    private int patrolTimer;
    private GameObject player;
    private Rigidbody enemyRB;
    //private Vector3 newVec;
    public float moveSpeed;
    public int patrolZoneXLow;
    public int patrolZoneXHigh;
    public int patrolZoneZLow;
    public int patrolZoneZHigh;
    public int patrolHeight;
    public AudioClip detectedClip;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 2f;
        patrolTimer = 500;
        player = GameObject.FindGameObjectWithTag("Player");
        playerSpotted = false;
        enemyRB = this.gameObject.GetComponent<Rigidbody>();
        //newVec = new Vector3(Random.Range(patrolZoneXLow, patrolZoneXHigh), 10, Random.Range(patrolZoneZLow, patrolZoneZHigh));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(playerSpotted)
        {
            moveSpeed = 6f;
            //Rotate to look at player
            transform.LookAt(player.transform.position);
            //Move towards player
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        else
        {
            if(patrolTimer < 0)
            {
                //newVec = new Vector3(Random.Range(patrolZoneXLow, patrolZoneXHigh), 10, Random.Range(patrolZoneZLow, patrolZoneZHigh));
                transform.LookAt(new Vector3(Random.Range(patrolZoneXLow,patrolZoneXHigh), 10, Random.Range(patrolZoneZLow, patrolZoneZHigh))); //Patrol a 40x40 area
                patrolTimer = 500;
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
            AudioSource.PlayClipAtPoint(detectedClip,this.transform.position);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerSpotted = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Tristans Scene");
        }
    }
}
