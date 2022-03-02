using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            other.transform.position = new Vector3(23f, 10f, 0f);
        }
    }
}
