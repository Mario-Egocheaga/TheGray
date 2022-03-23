using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //public variables
    public float moveSpeed;
    public float jumpForce;
    //public float mouseSensitivity;
    public GameObject playerCam;
    public GameObject dashPlate;
    public GameObject plainSightLight;
    public Transform orientation;
    public AudioMAnager audioManager;
    //private variables
    private int jumpsLeft;
    private int jumpMax;
    private float dashForce;
    private bool isCrouching;
    private bool isGrounded;
    private bool isWallRunning;
    private bool isSprinting;
    private bool plainSightActive;
    private bool isCharging;
    private Rigidbody playerRB;
    private CapsuleCollider playerCollider;
    //Unlock Bools
    static public bool dashUnlocked;
    static public bool extendedDashUnlocked;
    static public bool doubleJumpUnlocked;
    static public bool jumpDashUnlocked;
    static public bool wallRunUnlocked;
    static public bool slamUnlocked;
    static public bool dashRecallUnlocked;
    static public bool plainSightUnlocked;
    static public bool hoverUnlocked;
    static public bool wallGrabUnlocked;
    //Cooldowns
    private float dashCooldown;
    private float jumpDashCooldown;
    private float slamCooldown;
    private float plainSightCooldown;
    private float hoverCooldown;
    private float dashRecallCooldown;
    //Wallrunning
    public LayerMask whatIsWall;
    public float wallrunForce, maxWallrunTime, maxWallSpeed;
    bool isWallRight, isWallLeft;
    public float maxWallRunCameraTilt, wallRunCameraTilt;
    //Checkpoints
    private int checkpointReached;
    private bool t1;
    private bool t2;
    private bool t3;
    //Battery
    private float batteryLife;
    public Slider batterySlider;
    public Image batteryChargeImage;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = this.GetComponent<Rigidbody>();
        t1 = false;
        t2 = false;
        t3 = false;
        playerCollider = this.GetComponent<CapsuleCollider>();
        moveSpeed = 10f;
        jumpForce = 70f;
        //mouseSensitivity = 100f;
        isCrouching = false;
        isSprinting = false;
        isWallRunning = false;
        isCharging = false;
        plainSightLight.SetActive(false);
        dashPlate.SetActive(false);
        jumpsLeft = 1;
        jumpMax = 1;
        dashCooldown = 0f;
        jumpDashCooldown = 0f;
        slamCooldown = 0f;
        plainSightCooldown = 0f;
        hoverCooldown = 0f;
        dashRecallCooldown = 0f;
        dashForce = 75f;
        batteryLife = 1500f;
        batterySlider.value = batteryLife;
        checkpointReached = GetInt("checkpointReached");
        if(checkpointReached == 0)
        {
            dashUnlocked = false;
            doubleJumpUnlocked = false;
            wallRunUnlocked = false;
            extendedDashUnlocked = false;
            jumpDashUnlocked = false;
            slamUnlocked = false;
            dashRecallUnlocked = false;
            plainSightUnlocked = false;
            hoverUnlocked = false;
            wallGrabUnlocked = false;
        }
        if (checkpointReached == 1)
        {
            dashUnlocked = true;
            GameObject.Find("DashIntro").SetActive(false);
            doubleJumpUnlocked = true;
            GameObject.Find("DoubleJumpIntro").SetActive(false);
            wallRunUnlocked = true;
            GameObject.Find("WallRunIntro").SetActive(false);
            extendedDashUnlocked = false;
            jumpDashUnlocked = false;
            slamUnlocked = false;
            dashRecallUnlocked = false;
            plainSightUnlocked = false;
            hoverUnlocked = false;
            wallGrabUnlocked = false;
        }
        if (checkpointReached == 2)
        {
            dashUnlocked = true;
            GameObject.Find("DashIntro").SetActive(false);
            doubleJumpUnlocked = true;
            GameObject.Find("DoubleJumpIntro").SetActive(false);
            wallRunUnlocked = true;
            GameObject.Find("WallRunIntro").SetActive(false);
            extendedDashUnlocked = true;
            GameObject.Find("ExtendedDashIntro").SetActive(false);
            slamUnlocked = true;
            GameObject.Find("SlamIntro").SetActive(false);
            wallGrabUnlocked = true;
            GameObject.Find("WallGrabIntro").SetActive(false);
            jumpDashUnlocked = false;
            dashRecallUnlocked = false;
            plainSightUnlocked = false;
            hoverUnlocked = false;
        }
        if (checkpointReached == 3)
        {
            dashUnlocked = true;
            GameObject.Find("DashIntro").SetActive(false);
            doubleJumpUnlocked = true;
            GameObject.Find("DoubleJumpIntro").SetActive(false);
            wallRunUnlocked = true;
            GameObject.Find("WallRunIntro").SetActive(false);
            extendedDashUnlocked = true;
            GameObject.Find("ExtendedDashIntro").SetActive(false);
            slamUnlocked = true;
            GameObject.Find("SlamIntro").SetActive(false);
            wallGrabUnlocked = true;
            GameObject.Find("WallGrabIntro").SetActive(false);
            jumpDashUnlocked = true;
            GameObject.Find("JumpDashIntro").SetActive(false);
            dashRecallUnlocked = true;
            GameObject.Find("DashRecallIntro").SetActive(false);
            plainSightUnlocked = true;
            GameObject.Find("PlainSightIntro").SetActive(false);
            hoverUnlocked = true;
            GameObject.Find("HoverIntro").SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Checkpoint
        if(dashUnlocked && doubleJumpUnlocked && wallRunUnlocked)
        {
            SetInt("checkpointReached", 1);
            t1 = true;
        }
        if(t1 && extendedDashUnlocked && slamUnlocked && wallGrabUnlocked)
        {
            SetInt("checkpointReached", 2);
            t2 = true;
        }
        if(t1 && t2 && jumpDashUnlocked && dashRecallUnlocked && plainSightUnlocked && hoverUnlocked)
        {
            SetInt("checkpointReached", 3);
            t3 = true;
        }

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

        //Sprint Toggle
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isSprinting)
        {
            isSprinting = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && isSprinting)
        {
            isSprinting = false;
        }

        //Sprint Speeds
        if(isSprinting && !isCrouching)
        {
            moveSpeed = 5f;
        }
        else if(isSprinting && isCrouching)
        {
            moveSpeed = 10f;
        }
        else if(!isSprinting && !isCrouching)
        {
            moveSpeed = 10f;
        }
        else
        {
            moveSpeed = 20f;
        }

        //JumpForce Controller
        if (jumpsLeft == jumpMax && !isCrouching)
        {
            jumpForce = 60f;
        }
        else if (jumpsLeft == 1 && !isCrouching && jumpMax != 1)
        {
            jumpForce = 40f;
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0)
        {
            playerRB.velocity.Set(playerRB.velocity.x, 0, playerRB.velocity.z);
            playerRB.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            jumpsLeft--;
            batteryLife -= 20;
        }

        //Hover
        if (hoverUnlocked && Input.GetKeyDown(KeyCode.LeftControl) && hoverCooldown == 0f && !isGrounded)
        {
            hoverCooldown = 15f;
            playerRB.velocity += -playerRB.velocity;
        }

        if (hoverCooldown > 12f)
        {
            Physics.gravity = new Vector3(0f, 0f, 0f);
        }
        else
        {
            Physics.gravity = new Vector3(0f, -20f, 0f);
        }

        //Slam
        if (Input.GetKeyDown(KeyCode.X) && slamUnlocked && !isGrounded && slamCooldown == 0f)
        {
            playerRB.velocity = new Vector3(0,0,0);
            playerRB.AddForce(-transform.up * jumpForce*2, ForceMode.Impulse);
            slamCooldown = 5f;
        }

        //Double Jump
        if (doubleJumpUnlocked)
        {
            jumpMax = 2;
        }

        //Jump Dash
        if (Input.GetKeyDown(KeyCode.Mouse0) && jumpDashUnlocked && !isGrounded && jumpDashCooldown == 0f)
        {
            batteryLife -= 25;
            playerRB.AddForce(playerCam.transform.forward * 75f, ForceMode.Impulse);
            jumpDashCooldown = 5f;
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
        if (Input.GetKeyDown(KeyCode.Mouse0) && dashUnlocked && isGrounded && dashCooldown == 0f)
        {
            batteryLife -= 10;
            playerRB.AddForce(transform.forward * dashForce, ForceMode.Impulse);
            dashCooldown = 5f;
            if(dashRecallUnlocked)
            {
                dashPlate.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 1f, this.transform.position.z);
            }
        }

        //DashRecall
        if (dashRecallUnlocked && Input.GetKeyDown(KeyCode.R) && dashRecallCooldown == 0f)
        {
            transform.position = new Vector3(dashPlate.transform.position.x, dashPlate.transform.position.y + 1f, dashPlate.transform.position.z);
            dashRecallCooldown = 60f;
        }

        //PlainSight
        if (plainSightUnlocked && Input.GetKeyDown(KeyCode.Z) && plainSightCooldown == 0f)
        {
            plainSightCooldown = 25f;
        }

        if (plainSightCooldown > 20f)
        {
            plainSightActive = true;
        }
        else
        {
            plainSightActive = false;
        }

        if(plainSightActive)
        {
            plainSightLight.SetActive(true);
        }
        else
        {
            plainSightLight.SetActive(false);
        }

        //Wall Grab
        if(Physics.Raycast(this.transform.position, transform.forward, 1.5f) && Input.GetKey(KeyCode.Q) && wallGrabUnlocked)
        {
            playerRB.velocity = new Vector3(0f, 10f, 0f);
        }

        //Wall Run Part 3, Whats goodie
        if(Physics.Raycast(this.transform.position, transform.right, 2f) && Input.GetKey(KeyCode.Mouse1) && wallRunUnlocked)
        {
            Physics.gravity = new Vector3(0f, 0f, 0f);
            playerRB.velocity = new Vector3(0f, 0f, 0f);
        }

        if (Physics.Raycast(this.transform.position, -transform.right, 2f) && Input.GetKey(KeyCode.Mouse1) && wallRunUnlocked)
        {
            Physics.gravity = new Vector3(0f, 0f, 0f);
            playerRB.velocity = new Vector3(0f, 0f, 0f);
        }

        //Player walk
        playerRB.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") / moveSpeed) + (transform.right * Input.GetAxis("Horizontal") / moveSpeed));

        //Cooldown Timers
        //Dash Cooldown
        if (dashCooldown > 0f)
        {
            dashCooldown -= Time.deltaTime;
        }
        else if ((dashCooldown > 0f && dashCooldown < .5f) || dashCooldown < 0f)
        {
            dashCooldown = 0f;
        }

        //JumpDashCooldown
        if (jumpDashCooldown > 0f)
        {
            jumpDashCooldown -= Time.deltaTime;
        }
        else if ((jumpDashCooldown > 0f && jumpDashCooldown < .5f) || jumpDashCooldown < 0f)
        {
            jumpDashCooldown = 0f;
        }

        //PlainSightCooldown
        if (plainSightCooldown > 0f)
        {
            plainSightCooldown -= Time.deltaTime;
        }
        else if ((plainSightCooldown > 0f && plainSightCooldown < .5f) || plainSightCooldown < 0f)
        {
            plainSightCooldown = 0f;
        }

        //HoverCooldown
        if (hoverCooldown > 0f)
        {
            hoverCooldown -= Time.deltaTime;
        }
        else if ((hoverCooldown > 0f && hoverCooldown < .5f) || hoverCooldown < 0f)
        {
            hoverCooldown = 0f;
        }

        //SlamCooldown
        if (slamCooldown > 0f)
        {
            slamCooldown -= Time.deltaTime;
        }
        else if ((slamCooldown > 0f && slamCooldown < .5f) || slamCooldown < 0f)
        {
            slamCooldown = 0f;
        }

        //DashRecallCooldown
        if (dashRecallCooldown > 0f)
        {
            dashRecallCooldown -= Time.deltaTime;
        }
        else if ((dashRecallCooldown > 0f && dashRecallCooldown < .5f) || dashRecallCooldown < 0f)
        {
            dashRecallCooldown = 0f;
        }

        //Battery
        if(isCharging)
        {
            if(batteryLife > 1449f)
            {
                batteryLife = 1500f;
            }
            else
            {
                batteryLife += Time.deltaTime * 50;
                batterySlider.value = batteryLife;
            }
        }
        else if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if(isSprinting)
            {
                batteryLife -= Time.deltaTime * 15;
                batterySlider.value = batteryLife;

            }
            else
            {
                batteryLife -= Time.deltaTime * 5;
                batterySlider.value = batteryLife;
            }
        }
        else
        {
            batteryLife -= Time.deltaTime;
        }

        if(batteryLife <= 300)
        {
            batteryChargeImage.color = new Color(0.6431373f, 0.09019608f, 0.1098039f, 1f);
        }
        else if(batteryLife <= 750)
        {
            batteryChargeImage.color = new Color(0.764151f, 0.7445666f, 0.1766198f, 1f);
        }
        else
        {
            batteryChargeImage.color = new Color(0.09411765f, 0.5960785f, 0.07058824f, 1f);
        }

        if(batteryLife < 0)
        {
            batteryLife = 0;
        }

        //WinCon
        if(audioManager.getRelicCount() == 4 && t1 && t2 && t3)
        {
            SceneManager.LoadScene("Credit scene");
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
        }

        //Double Jump Unlock Pickup
        if (collision.gameObject.CompareTag("DoubleJumpUnlock"))
        {
            doubleJumpUnlocked = true;
            jumpsLeft = 2;
            collision.gameObject.SetActive(false);
        }

        //Jump Dash Unlock Pickup
        if (collision.gameObject.CompareTag("JumpDashUnlock"))
        {
            jumpDashUnlocked = true;
            collision.gameObject.SetActive(false);
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

        //Slam Unlock Pickup
        if (collision.gameObject.CompareTag("SlamUnlock"))
        {
            slamUnlocked = true;
            collision.gameObject.SetActive(false);
        }

        //DashRecall Unlock Pickup
        if (collision.gameObject.CompareTag("DashRecallUnlock"))
        {
            dashRecallUnlocked = true;
            collision.gameObject.SetActive(false);
            dashPlate.SetActive(true);
            dashPlate.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 1f, this.transform.position.z);
        }

        //PlainSight Unlock Pickup
        if (collision.gameObject.CompareTag("PlainSightUnlock"))
        {
            plainSightUnlocked = true;
            collision.gameObject.SetActive(false);
        }

        //Hover Unlock Pickup
        if (collision.gameObject.CompareTag("HoverUnlock"))
        {
            hoverUnlocked = true;
            collision.gameObject.SetActive(false);
        }

        //Wall Grab Unlock Pickup
        if (collision.gameObject.CompareTag("WallGrabUnlock"))
        {
            wallGrabUnlocked = true;
            collision.gameObject.SetActive(false);
        }
    }

    //Checkpoint stuff
    public void SetInt(string KeyName, int Value)
    {
        PlayerPrefs.SetInt(KeyName, Value);
    }

    public int GetInt(string KeyName)
    {
        return PlayerPrefs.GetInt(KeyName);
    }

    private void OnCollisionExit(Collision collision)
    {
        isWallRunning = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        jumpsLeft = jumpMax;
    }
    
    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
        if(other.CompareTag("ChargeStation"))
        {
            isCharging = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        isGrounded = true;
        if(other.CompareTag("ChargeStation"))
        {
            isCharging = true;
        }
    }

    public bool getPlainSight()
    {
        return plainSightActive;
    }
}
