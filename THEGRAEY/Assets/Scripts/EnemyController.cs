using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    private GameObject player;
    private bool playerSpotted;
    private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 5f;
        player = GameObject.FindGameObjectWithTag("Player");
        playerSpotted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerSpotted)
        {   
            //rotate to look at player
            transform.LookAt(player.transform.position);
            //move towards player
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        else
        {
            
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
