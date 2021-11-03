using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMAnager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip Welcome;
    public AudioClip CrouchIntro;
    public AudioClip SprintIntro;
    public AudioClip DashIntro;
    public AudioClip DoubleJumpIntro;
    public AudioClip WallRunIntro;
    public AudioClip JumpDashIntro;
    public AudioClip ExtendedDashIntro;

    public AudioSource Player;

    private int crouchClipsPlayed;
    private int sprintClipsPlayed;
    private int dashClipsPlayed;
    private int doubleJumpClipsPlayed;
    private int wallRunClipsPlayed;
    private int jumpDashClipsPlayed;
    private int extendedDashClipsPlayed;

    void Start()
    {
        Player.clip = Welcome;
        Player.Play();
        crouchClipsPlayed = 0;
        sprintClipsPlayed = 0;
        dashClipsPlayed = 0;
        doubleJumpClipsPlayed = 0;
        wallRunClipsPlayed = 0;
        jumpDashClipsPlayed = 0;
        extendedDashClipsPlayed = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "CrouchIntro" && crouchClipsPlayed == 0)
        {
            Player.clip = CrouchIntro;
            Player.Play();
            crouchClipsPlayed++;
        }
        if (other.gameObject.name == "EnemyIntro" && sprintClipsPlayed == 0)
        {
            Player.clip = SprintIntro;
            Player.Play();
            sprintClipsPlayed++;
        }
        if (other.gameObject.name == "DashIntro" && dashClipsPlayed == 0)
        {
            Player.clip = DashIntro;
            Player.Play();
            dashClipsPlayed++;
        }
        if (other.gameObject.name == "DoubleJumpIntro" && doubleJumpClipsPlayed == 0)
        {
            Player.clip = DoubleJumpIntro;
            Player.Play();
            dashClipsPlayed++;
        }
        if (other.gameObject.name == "WallRunIntro" && wallRunClipsPlayed == 0)
        {
            Player.clip = WallRunIntro;
            Player.Play();
            dashClipsPlayed++;
        }
        if (other.gameObject.name == "JumpDashIntro" && jumpDashClipsPlayed == 0)
        {
            Player.clip = JumpDashIntro;
            Player.Play();
            dashClipsPlayed++;
        }
        if (other.gameObject.name == "ExtendedDashIntro" && extendedDashClipsPlayed == 0)
        {
            Player.clip = ExtendedDashIntro;
            Player.Play();
            dashClipsPlayed++;
        }
    }
}

