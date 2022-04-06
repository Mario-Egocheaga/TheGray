using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPad : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip logAudioClip;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = logAudioClip;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
        }
    }
}
