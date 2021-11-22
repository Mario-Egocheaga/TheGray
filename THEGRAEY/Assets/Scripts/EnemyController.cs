using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    private bool playerSpotted;
    private int point;
    private GameObject player;
    private Vector3[] patrolPoints;
    //private Vector3 newVec;
    public float moveSpeed;
    public float huntingMoveSpeed;
    public Vector3 point1;
    public Vector3 point2;
    public Vector3 point3;
    public Vector3 point4;
    public AudioClip detectedClip;

    // Start is called before the first frame update
    void Start()
    {
        point = 1;
        patrolPoints = new Vector3[4];
        patrolPoints[0] = point1;
        patrolPoints[1] = point2;
        patrolPoints[2] = point3;
        patrolPoints[3] = point4;
        player = GameObject.FindGameObjectWithTag("Player");
        playerSpotted = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if((transform.position.x > point1.x - 2 && transform.position.x < point1.x + 2) && (transform.position.y > point1.y - 2 && transform.position.y < point1.y + 2) && (transform.position.z > point1.z - 2 && transform.position.z < point1.z + 2))
        {
            point = 2;
        }
        if((transform.position.x > point2.x - 2 && transform.position.x < point2.x + 2) && (transform.position.y > point2.y - 2 && transform.position.y < point2.y + 2) && (transform.position.z > point2.z - 2 && transform.position.z < point2.z + 2))
        {
            point = 3;
        }
        if((transform.position.x > point3.x - 2 && transform.position.x < point3.x + 2) && (transform.position.y > point3.y - 2 && transform.position.y < point3.y + 2) && (transform.position.z > point3.z - 2 && transform.position.z < point3.z + 2))
        {
            point = 4;
        }
        if ((transform.position.x > point4.x - 2 && transform.position.x < point4.x + 2) && (transform.position.y > point4.y - 2 && transform.position.y < point4.y + 2) && (transform.position.z > point4.z - 2 && transform.position.z < point4.z + 2))
        {
            point = 1;
        }

        if (playerSpotted)
        {
            //Rotate to look at player
            transform.LookAt(player.transform.position);
            //Move towards player
            transform.position += transform.forward * huntingMoveSpeed * Time.deltaTime;
        }
        else
        {
            Debug.Log(patrolPoints[point - 1]);
            transform.LookAt(patrolPoints[point - 1]);
            transform.position += transform.forward * moveSpeed * Time.deltaTime; //Move forward towards position
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
