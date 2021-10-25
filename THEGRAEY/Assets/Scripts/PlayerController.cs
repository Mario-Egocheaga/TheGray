using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public variables
    public float moveSpeed;
    public float jumpForce;
    public float mouseSensitivity;
    public GameObject playerCam;
    //private variables
    private int jumpsLeft;
    private int jumpMax;
    private bool isCrouching;
    private bool dashUnlocked;
    private bool isGrounded;
    private Rigidbody playerRB;
    private CapsuleCollider playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = this.GetComponent<CapsuleCollider>();
        playerRB = this.GetComponent<Rigidbody>();
        moveSpeed = 10f;
        jumpForce = 80f;
        mouseSensitivity = 5f;
        isCrouching = false;
        dashUnlocked = false;
        jumpsLeft = 1;
        jumpMax = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Crouch Toggle
        if (Input.GetKeyDown(KeyCode.C) && !isCrouching)
        {
            moveSpeed = 20f;
            jumpForce = 40f;
            playerCam.transform.localPosition = new Vector3(0, 0, 0);
            playerCollider.height = 1;
            playerCollider.center = new Vector3(0, -.5f, 0);
            isCrouching = true;
        }
        else if (Input.GetKeyDown(KeyCode.C) && isCrouching)
        {
            moveSpeed = 10f;
            jumpForce = 80f;
            playerCam.transform.localPosition = new Vector3(0, .5f, 0);
            playerCollider.height = 2;
            playerCollider.center = new Vector3(0, 0, 0);
            isCrouching = false;
        }

        //Sprint Hold
        if (Input.GetKey(KeyCode.LeftShift) && !isCrouching)
        {
            moveSpeed = 5f;
        }
        else if(!isCrouching)
        {
            moveSpeed = 10f;
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0)
        {
            playerRB.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            jumpsLeft--;
        }

        //Dash
        if (Input.GetKeyDown(KeyCode.Q) && dashUnlocked && isGrounded)
        {
            playerRB.AddForce(transform.forward * 100f, ForceMode.Impulse);
        }

        //Camera rotation
        playerCam.transform.rotation = playerCam.transform.rotation * Quaternion.Euler(new Vector3(Input.GetAxis("Mouse Y") * -mouseSensitivity, 0, 0));
        playerRB.MoveRotation(playerRB.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * mouseSensitivity, 0)));
        //Player walk
        playerRB.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") / moveSpeed) + (transform.right * Input.GetAxis("Horizontal") / moveSpeed));
        Cursor.lockState = CursorLockMode.Locked; //Hide cursor
    }
    private void FixedUpdate()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DashUnlock"))
        {
            dashUnlocked = true;
            collision.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isGrounded = true;
        jumpsLeft = jumpMax;
    }

    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }
}
