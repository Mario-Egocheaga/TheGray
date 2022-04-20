using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    private bool playerSpotted;
    private int point;
    private GameObject player; //player object to interact with and orbit around
    private Vector3[] patrolPoints;
    private PlayerController playerController;
    public float moveSpeed;
    public float huntingMoveSpeed;
    public float orbitSpeed;
    public int orbitRange;
    public int chaseRange;
    public int drainRange;
    public Vector3 point1;
    public Vector3 point2;
    public Vector3 point3;
    public Vector3 point4;
    public AudioClip detectedClip;
    private Rigidbody enemyRB;

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
        playerController = player.GetComponent<PlayerController>();
        playerSpotted = false;
        enemyRB = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // add orbitAround to orbit/attack case
        if (Vector3.Distance(player.transform.position, transform.position) < orbitRange)
        {
            orbitAround();
        }
        if(Vector3.Distance(player.transform.position, transform.position) > orbitRange && Vector3.Distance(player.transform.position, transform.position) < chaseRange)
        {
            chase();
        }
        else
        {
            /*transform.LookAt(patrolPoints[point - 1]);
            transform.position += transform.forward * moveSpeed * Time.deltaTime; //Move forward towards position*/
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {/*
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

        if (playerSpotted && (playerController.getPlainSight() == false))
        {
            //Rotate to look at player
            transform.LookAt(player.transform.position);
            //Move towards player
            transform.position += transform.forward * huntingMoveSpeed * Time.deltaTime;
        }
        else
        {
            transform.LookAt(patrolPoints[point - 1]);
            transform.position += transform.forward * moveSpeed * Time.deltaTime; //Move forward towards position
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("skeet");
            playerSpotted = true;
            //AudioSource.PlayClipAtPoint(detectedClip, this.transform.position);
            playerController.addEnemyDraining();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerSpotted = false;
            playerController.subtractEnemyDraining();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //possibly add ability for player to run/jump up and punch an enemy dead
    }

    void orbitAround()
    {
        transform.RotateAround(player.transform.position, Vector3.up, orbitSpeed * Time.deltaTime);
    }

    void chase()
    {
        transform.LookAt(player.transform);
        transform.position += transform.forward * Time.deltaTime * huntingMoveSpeed;
    }
}
