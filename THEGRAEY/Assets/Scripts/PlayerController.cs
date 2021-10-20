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
        moveSpeed = .1f;
        jumpForce = 50f;
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

        //Sprint Hold
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = .2f;
        }
        else
        {
            moveSpeed = .1f;
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

        //Player walk and camera rotation
        playerCam.transform.rotation = playerCam.transform.rotation * Quaternion.Euler(new Vector3(Input.GetAxis("Mouse Y") * -mouseSensitivity, 0, 0));
        playerRB.MoveRotation(playerRB.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * mouseSensitivity, 0)));
        playerRB.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * moveSpeed) + (transform.right * Input.GetAxis("Horizontal") * moveSpeed));

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
