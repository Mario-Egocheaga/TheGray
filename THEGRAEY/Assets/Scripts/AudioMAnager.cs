using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMAnager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip SlamIntro;
    public AudioClip WallGrabIntro;
    public AudioClip DashRecallIntro;
    public AudioClip DashIntro;
    public AudioClip DoubleJumpIntro;
    public AudioClip WallRunIntro;
    public AudioClip JumpDashIntro;
    public AudioClip ExtendedDashIntro;
    public AudioClip PlainSightIntro;
    public AudioClip HoverIntro;

    public AudioSource Player;

    // Player SFX - Mario
    public AudioClip[] audioClips;

    public void Start()
    {

    }

    // Calls SFX Name
    public void PlaySFX(string audioName)
    {
        foreach (AudioClip clip in audioClips)
        {
            if (clip.name == audioName)
            {
                Player.volume = 0.24f;
                Player.PlayOneShot(clip);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SlamIntro")
        {
            Player.clip = SlamIntro;
            Player.Play();
        }
        if (other.gameObject.name == "WallGrabIntro")
        {
            Player.clip = WallGrabIntro;
            Player.Play();
        }
        if (other.gameObject.name == "DashIntro")
        {
            Player.clip = DashIntro;
            Player.Play();
        }
        if (other.gameObject.name == "DoubleJumpIntro")
        {
            Player.clip = DoubleJumpIntro;
            Player.Play();
        }
        if (other.gameObject.name == "WallRunIntro")
        {
            Player.clip = WallRunIntro;
            Player.Play();
        }
        if (other.gameObject.name == "JumpDashIntro")
        {
            Player.clip = JumpDashIntro;
            Player.Play();
        }
        if (other.gameObject.name == "ExtendedDashIntro")
        {
            Player.clip = ExtendedDashIntro;
            Player.Play();
        }
        if (other.gameObject.name == "DashRecallIntro")
        {
            Player.clip = DashRecallIntro;
            Player.Play();
        }
        if (other.gameObject.name == "PlainSightIntro")
        {
            Player.clip = PlainSightIntro;
            Player.Play();
        }
        if (other.gameObject.name == "HoverIntro")
        {
            Player.clip = HoverIntro;
            Player.Play();
        }
    }
}

