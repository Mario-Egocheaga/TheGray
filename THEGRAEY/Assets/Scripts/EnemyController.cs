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
    public AudioClip detectedClip;
    private Rigidbody enemyRB;
    private bool isStunned;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        playerSpotted = false;
        enemyRB = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        int layerMask = LayerMask.GetMask("Enemy", "Player");
        layerMask = ~layerMask;

        Debug.DrawLine(this.transform.position, player.transform.position, Color.red);
        if(Physics.Linecast(this.transform.position, player.transform.position, layerMask))
        {
            Debug.Log("No LOS");
        }
        else
        {
            Debug.Log("LOS");
            if(!isStunned && Vector3.Distance(player.transform.position, transform.position) < drainRange)
            {
                playerController.drainBatteryPerSecond(25);
            }
        }

        /*RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }*/

        // add orbitAround to orbit/attack case
        if (!isStunned && Vector3.Distance(player.transform.position, transform.position) < orbitRange)
        {
            orbitAround();
        }
        if (!isStunned && Vector3.Distance(player.transform.position, transform.position) > orbitRange && Vector3.Distance(player.transform.position, transform.position) < chaseRange)
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
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        //possibly add ability for player to run/jump up and punch an enemy dead
    }

    void orbitAround()
    {
        transform.RotateAround(player.transform.position, Vector3.up, orbitSpeed * Time.deltaTime);
        transform.LookAt(player.transform);
    }

    void chase()
    {
        transform.LookAt(player.transform);
        transform.position += transform.forward * Time.deltaTime * huntingMoveSpeed;
    }

    public bool getStunned()
    {
        return isStunned;
    }

    public IEnumerator Stunned()
    {
        enemyRB.velocity = new Vector3(0,0,0);
        enemyRB.useGravity = true;
        isStunned = true;
        yield return new WaitForSeconds(3);
        enemyRB.useGravity = false;
        isStunned = false;
    }
}
