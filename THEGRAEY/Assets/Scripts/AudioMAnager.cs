using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMAnager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip Welcome;
    public AudioClip Crouch;
    public AudioClip Sprint;
    public AudioClip SPickUp;

    public AudioSource Player;
    
    

    void Start()
    {
        Player.clip = Welcome;
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void OnTriggerEnter(Collider other)
    {
        Player.Play();

        if(other.gameObject.name == "Pipe")
        {
            Player.clip = Crouch;

        }
        if (other.gameObject.name == "Enemy")
        {
            Player.clip = Sprint;

        }
        if (other.gameObject.name == "Cube (3)")
        {
            Player.clip = SPickUp;

        }
    }
}

