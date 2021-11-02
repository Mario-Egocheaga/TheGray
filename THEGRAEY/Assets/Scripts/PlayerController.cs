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
    private int jumpDashesLeft;
    private int jumpMax;
    private bool isCrouching;
    private bool isGrounded;
    private Rigidbody playerRB;
    private CapsuleCollider playerCollider;
    //Unlock Bools
    private bool dashUnlocked;
    private bool doubleJumpUnlocked;
    private bool jumpDashUnlocked;
    //Cooldowns
    private float dashCooldown;

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
        doubleJumpUnlocked = false;
        jumpDashUnlocked = false;
        jumpsLeft = 1;
        jumpDashesLeft = 2;
        jumpMax = 1;
        dashCooldown = 0f;
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
            jumpDashesLeft--;
        }

        //Double Jump
        if(doubleJumpUnlocked)
        {
            jumpMax = 2;
        }

        //Jump Dash
        if (Input.GetKeyDown(KeyCode.Q) && jumpDashUnlocked && !isGrounded && jumpDashesLeft > 0)
        {
            playerRB.AddForce(playerCam.transform.forward * 100f, ForceMode.Impulse);
            jumpDashesLeft--;
        }
    
        //Dash
        if (Input.GetKeyDown(KeyCode.Q) && dashUnlocked && isGrounded && dashCooldown == 0f)
        {
            playerRB.AddForce(transform.forward * 100f, ForceMode.Impulse);
            dashCooldown = 5f;
        }

        //Camera rotation
        playerCam.transform.rotation = playerCam.transform.rotation * Quaternion.Euler(new Vector3(Input.GetAxis("Mouse Y") * -mouseSensitivity, 0, 0));
        playerRB.MoveRotation(playerRB.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * mouseSensitivity, 0)));
        //Player walk
        playerRB.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") / moveSpeed) + (transform.right * Input.GetAxis("Horizontal") / moveSpeed));
        Cursor.lockState = CursorLockMode.Locked; //Hide cursor

        //Cooldown Timers
        if(dashCooldown > 0f)
        {
            dashCooldown -= Time.deltaTime;
        }
        else if((dashCooldown > 0f && dashCooldown < .5f) || dashCooldown < 0f)
        {
            dashCooldown = 0f;
        }
        Debug.Log(dashCooldown);
    }
    private void FixedUpdate()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Dash Unlock Pickup
        if (collision.gameObject.CompareTag("DashUnlock"))
        {
            dashUnlocked = true;
            collision.gameObject.SetActive(false);
        }

        //Double Jump Unlock Pickup
        if (collision.gameObject.CompareTag("DoubleJumpUnlock"))
        {
            doubleJumpUnlocked = true;
            collision.gameObject.SetActive(false);
        }

        //Jump Dash Unlock Pickup
        if (collision.gameObject.CompareTag("JumpDashUnlock"))
        {
            jumpDashUnlocked = true;
            collision.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        jumpsLeft = jumpMax;
        jumpDashesLeft = 2;
    }

    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }

    private void OnTriggerStay(Collider other)
    {
        isGrounded = true;
    }
}
