using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion : MonoBehaviour
{
    public AudioClip clip;
    private AudioSource companionAS;
    private bool clipPlayed;
    private GameObject player;
    public GameObject body;

    // Start is called before the first frame update
    void Start()
    {
        companionAS = this.GetComponent<AudioSource>();
        companionAS.clip = clip;
        clipPlayed = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        body.transform.LookAt(player.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && !clipPlayed)
        {
            clipPlayed = true;
            companionAS.Play();
        }
    }
}
