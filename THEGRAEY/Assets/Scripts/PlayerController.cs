using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject playerCam;
    public float moveSpeed;
    public float jumpForce;
    private CapsuleCollider playerCollider;
    private bool isCrouching;
    private bool dashUnlocked;
    private Rigidbody playerRB;

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = this.GetComponent<CapsuleCollider>();
        isCrouching = false;
        playerRB = this.GetComponent<Rigidbody>();
        moveSpeed = 5f;
        jumpForce = 50f;
        dashUnlocked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && !isCrouching)
        {
            playerCam.transform.localPosition = new Vector3(0, 0, 0);
            playerCollider.height = 1;
            playerCollider.center = new Vector3(0, -.5f, 0);
            isCrouching = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl) && isCrouching)
        {
            playerCam.transform.localPosition = new Vector3(0, .5f, 0);
            playerCollider.height = 2;
            playerCollider.center = new Vector3(0, 0, 0);
            isCrouching = false;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 10f;
        }
        else
        {
            moveSpeed = 5f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRB.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Q) && dashUnlocked)
        {
            playerRB.AddForce(transform.forward * 100f, ForceMode.Impulse);
        }
    }
    private void FixedUpdate()
    {
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        playerRB.MovePosition(transform.position + m_Input * Time.deltaTime * moveSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DashUnlock"))
        {
            dashUnlocked = true;
        }
    }
}
