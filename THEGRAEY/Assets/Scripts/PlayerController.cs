using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject playerCam;
    public float moveSpeed;
    public float jumpForce;
    public float mouseSensitivity;
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
        moveSpeed = .1f;
        jumpForce = 50f;
        dashUnlocked = false;
        mouseSensitivity = 5f;
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
            moveSpeed = .2f;
        }
        else
        {
            moveSpeed = .1f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRB.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Q) && dashUnlocked)
        {
            playerRB.AddForce(transform.forward * 100f, ForceMode.Impulse);
        }

        playerCam.transform.rotation = playerCam.transform.rotation * Quaternion.Euler(new Vector3(Input.GetAxis("Mouse Y") * -mouseSensitivity, 0, 0));
        playerRB.MoveRotation(playerRB.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * mouseSensitivity, 0)));
        playerRB.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * moveSpeed) + (transform.right * Input.GetAxis("Horizontal") * moveSpeed));
    }
    private void FixedUpdate()
    {
        Debug.Log(moveSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DashUnlock"))
        {
            dashUnlocked = true;
        }
    }
}
