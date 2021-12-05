using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRunner : MonoBehaviour
{
    public bool touchingWall;

    // Start is called before the first frame update
    void Start()
    {
        touchingWall = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("WallRunable"))
        {
            touchingWall = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("WallRunable"))
        {
            touchingWall = false;
        }
    }

    public bool getWallStatus()
    {
        return touchingWall;
    }
}
