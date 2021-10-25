using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip Welcome;
    public AudioClip Crouch;
    public AudioClip Sprint;
    public AudioClip DashPickUp;

    public AudioSource Player;

    private int crouchClipsPlayed;
    private int sprintClipsPlayed;
    private int dashClipsPlayed;

    void Start()
    {
        Player.clip = Welcome;
        Player.Play();
        crouchClipsPlayed = 0;
        sprintClipsPlayed = 0;
        dashClipsPlayed = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "CrouchIntro" && crouchClipsPlayed == 0)
        {
            Player.clip = Crouch;
            Player.Play();
            crouchClipsPlayed++;
        }
        if (other.gameObject.name == "EnemyIntro" && sprintClipsPlayed == 0)
        {
            Player.clip = Sprint;
            Player.Play();
            sprintClipsPlayed++;
        }
        if (other.gameObject.name == "DashIntro" && dashClipsPlayed == 0)
        {
            Player.clip = DashPickUp;
            Player.Play();
            dashClipsPlayed++;
        }
    }
}

