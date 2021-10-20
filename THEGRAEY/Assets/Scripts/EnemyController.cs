using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    private GameObject player;
    private bool playerSpotted;
    private float moveSpeed;
    private int patrolTimer;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 2f;
        patrolTimer = 500;
        player = GameObject.FindGameObjectWithTag("Player");
        playerSpotted = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(playerSpotted)
        {
            moveSpeed = 7.5f;
            //Rotate to look at player
            transform.LookAt(player.transform.position);
            //Move towards player
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        else
        {
            if(patrolTimer < 0)
            { 
                transform.LookAt(new Vector3(Random.Range(-40, 41), 10, Random.Range(-40, 41))); //Patrol a 40x40 area
                patrolTimer = 500;
            }
            else
            {
                moveSpeed = 2f;
                transform.position += transform.forward * moveSpeed * Time.deltaTime; //Move to position
                patrolTimer--;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerSpotted = true;
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
            SceneManager.LoadScene("SampleScene");
            Debug.Log("Bruh");
        }
    }
}
