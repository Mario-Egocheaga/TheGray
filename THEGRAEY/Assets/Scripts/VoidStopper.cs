using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidStopper : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.transform.position = new Vector3(13.4f, 16f, -168.5f);
        }
    }
}
