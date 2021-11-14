using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //public variables
    public float moveSpeed;
    public float jumpForce;
    public float mouseSensitivity;
    public GameObject playerCam;
    //private variables
    private int jumpsLeft;
    private float xRotation;
    //private int jumpDashesLeft;
    private int jumpMax;
    private float dashForce;
    private bool isCrouching;
    private bool isGrounded;
    private bool isWallRunning;
    private Rigidbody playerRB;
    private CapsuleCollider playerCollider;
    //Unlock Bools
    private bool dashUnlocked;
    private bool extendedDashUnlocked;
    private bool doubleJumpUnlocked;
    private bool jumpDashUnlocked;
    private bool wallRunUnlocked;
    //Cooldowns
    private float dashCooldown;
    private float jumpDashCooldown;
    //UI Shit
    public Text dashText;
    public Text jumpDashText;

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = this.GetComponent<CapsuleCollider>();
        playerRB = this.GetComponent<Rigidbody>();
        moveSpeed = 10f;
        jumpForce = 70f;
        mouseSensitivity = 100f;
        xRotation = 0f;
        isCrouching = false;
        isWallRunning = false;
        dashUnlocked = false;
        extendedDashUnlocked = false;
        doubleJumpUnlocked = false;
        jumpDashUnlocked = false;
        wallRunUnlocked = false;
        jumpsLeft = 1;
        //jumpDashesLeft = 2;
        jumpMax = 1;
        dashCooldown = 0f;
        jumpDashCooldown = 0f;
        dashForce = 75f;
        dashText.text = "Dash: Unavailable";
        jumpDashText.text = "Jump Dash: Unavailable";
    }

    // Update is called once per frame
    void Update()
    {
        //Crouch Toggle
        if (Input.GetKeyDown(KeyCode.C) && !isCrouching)
        {
            moveSpeed = 20f;
            jumpForce = 25f;
            playerCam.transform.localPosition = new Vector3(0, 0, 0);
            playerCollider.height = 1;
            playerCollider.center = new Vector3(0, -.5f, 0);
            isCrouching = true;
        }
        else if (Input.GetKeyDown(KeyCode.C) && isCrouching)
        {
            moveSpeed = 10f;
            jumpForce = 60f;
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

        //JumpForce Controller
        if(jumpsLeft == jumpMax && !isCrouching)
        {
            jumpForce = 60f;
        }
        else if(jumpsLeft == 1 && !isCrouching)
        {
            jumpForce = 40f;
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0)
        {
            playerRB.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            jumpsLeft--;
            //jumpDashesLeft--;
        }

        /*
        //Wall Jump
        if(isWallRunning)
        {
            if (Physics.Raycast(transform.position, transform.right, 1f))
            {
                playerRB.velocity = new Vector3(0, jumpForce/2, 0) + transform.right * -40;
            }
            if (Physics.Raycast(transform.position, -transform.right, 1f))
            {
                playerRB.velocity = new Vector3(0, jumpForce/2, 0) + transform.right * 40;
            }
            if (Physics.Raycast(transform.position, transform.forward, 1f))
            {
                playerRB.velocity = new Vector3(0, jumpForce/2, 0) + transform.forward * -40;
            }
        }

        if (isWallRunning)
        {
            playerCam.GetComponent<Camera>().fieldOfView = 96;
            if (Physics.Raycast(transform.position, transform.right, 1f))
            {
                playerRB.velocity += transform.right * 0.1f;
                if (playerCam.transform.localEulerAngles.z < 15f || playerCam.transform.localEulerAngles.z > 345f)
                {
                    playerCam.transform.localEulerAngles += new Vector3(0, 0, 100f * Time.deltaTime);
                }
            }
            if (Physics.Raycast(transform.position, -transform.right, 1f))
            {
                if (playerCam.transform.localEulerAngles.z > 345f)
                {
                    playerCam.transform.localEulerAngles += new Vector3(0, 0, -100f * Time.deltaTime);
                }
                playerCam.transform.localEulerAngles += new Vector3(0, 0, -10f * Time.deltaTime);
                playerRB.velocity += transform.right * -0.1f;
            }
        }
        else
        {
            playerCam.GetComponent<Camera>().fieldOfView = 90;
        }
        */

        //Double Jump
        if (doubleJumpUnlocked)
        {
            jumpMax = 2;
        }

        //Jump Dash
        if (Input.GetKeyDown(KeyCode.Q) && jumpDashUnlocked && !isGrounded /*&& jumpDashesLeft > 0 */&& jumpDashCooldown == 0f)
        {
            playerRB.AddForce(playerCam.transform.forward * 75f, ForceMode.Impulse);
            //jumpDashesLeft--;
            jumpDashCooldown = 5f;
            jumpDashText.text = "Jump Dash: Cooling Down";
        }

        //Dash Force
        if (extendedDashUnlocked)
        {
            dashForce = 125f;
        }
        else
        {
            dashForce = 75f;
        }

        //Dash
        if (Input.GetKeyDown(KeyCode.Q) && dashUnlocked && isGrounded && dashCooldown == 0f)
        {
            playerRB.AddForce(transform.forward * dashForce, ForceMode.Impulse);
            dashCooldown = 5f;
            dashText.text = "Dash: Cooling Down";
        }

        //Player walk
        playerRB.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") / moveSpeed) + (transform.right * Input.GetAxis("Horizontal") / moveSpeed));
        //Cursor.lockState = CursorLockMode.Locked; //Hide cursor

        //Cooldown Timers
        //Dash Cooldown
        if (dashCooldown > 0f)
        {
            dashCooldown -= Time.deltaTime;
        }
        else if((dashCooldown > 0f && dashCooldown < .5f) || dashCooldown < 0f)
        {
            dashCooldown = 0f;
            dashText.text = "Dash: Ready";
        }

        //JumpDashCooldown
        if (jumpDashCooldown > 0f)
        {
            jumpDashCooldown -= Time.deltaTime;
        }
        else if ((jumpDashCooldown > 0f && jumpDashCooldown < .5f) || jumpDashCooldown < 0f)
        {
            jumpDashCooldown = 0f;
            jumpDashText.text = "Jump Dash: Ready";
        }

        //Wall Run
        /*
        if(isWallRunning && isGrounded)
        {
            isWallRunning = false;
        }
        if(isWallRunning && playerRB.velocity.magnitude <= 30)
        {
            playerRB.velocity += transform.forward * 100 * Time.deltaTime + transform.up * -0.1f;
        }
        */
        
        if (isWallRunning && Input.GetKey(KeyCode.E) && wallRunUnlocked)
        {
            playerRB.constraints = RigidbodyConstraints.FreezePositionY;
            playerRB.constraints = RigidbodyConstraints.FreezeRotation;
            jumpsLeft = 1;
        }
        else if(!isWallRunning)
        {
            playerRB.constraints = RigidbodyConstraints.None;
            playerRB.constraints = RigidbodyConstraints.FreezeRotation;
        }
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
            dashText.text = "Dash: Ready";
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
            jumpDashText.text = "Jump Dash: Ready";
        }

        //Wall Run Unlock Pickup
        if (collision.gameObject.CompareTag("WallRunUnlock"))
        {
            wallRunUnlocked = true;
            collision.gameObject.SetActive(false);
        }

        //Extended Dash Unlock Pickup
        if (collision.gameObject.CompareTag("ExtendedDashUnlock"))
        {
            extendedDashUnlocked = true;
            collision.gameObject.SetActive(false);
        }

        //Wall Run
        /*
        if(Mathf.Abs(Vector3.Dot(collision.GetContact(0).normal, Vector3.up)) <0.1f && wallRunUnlocked)
        {
            playerRB.velocity = new Vector3(0, 20, 0) + transform.forward * 50;
            isWallRunning = true;
        }
        */
    }

    private void OnCollisionExit(Collision collision)
    {
        isWallRunning = false;
        //StartCoroutine(WallRunCooldown());
    }

    private void OnTriggerEnter(Collider other)
    {
        jumpsLeft = jumpMax;
        //jumpDashesLeft = 2;
    }

    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }

    private void OnTriggerStay(Collider other)
    {
        isGrounded = true;
    }
    
    /*
    private IEnumerator WallRunCooldown()
    {
        wallRunUnlocked = false;
        yield return new WaitForSeconds(0.3f);
        wallRunUnlocked = true;
    }*/
}
