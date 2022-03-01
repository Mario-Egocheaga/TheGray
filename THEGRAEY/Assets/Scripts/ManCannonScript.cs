using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManCannonScript : MonoBehaviour
{
    private float cannonStrength;
    // Start is called before the first frame update
    void Start()
    {
        cannonStrength = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody cannonTarget = other.GetComponent<Rigidbody>();
        cannonTarget.AddForce(new Vector3(0,2,-1) * cannonStrength, ForceMode.Impulse);
    }
}
