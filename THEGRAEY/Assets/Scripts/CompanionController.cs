using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionController : MonoBehaviour
{
    public Vector3 startLocation;
    public float startRotation;
    public Vector3 location1;
    public float rotation1;
    public Vector3 location2;
    public float rotation2;
    public Vector3 location3;
    public float rotation3;
    public Vector3 location4;
    public float rotation4;
    public Vector3 location5;
    public float rotation5;
    public Vector3 location6;
    public float rotation6;
    public Vector3 location7;
    public float rotation7;
    public Vector3 location8;
    public float rotation8;
    public Vector3 location9;
    public float rotation9;
    public GameObject interactionText;
    public AudioSource companionAudioSource;
    public AudioClip clip1;
    public int clip1Length;
    public AudioClip clip2;
    public int clip2Length;
    public AudioClip clip3;
    public int clip3Length;
    public AudioClip clip4;
    public int clip4Length;
    public AudioClip clip5;
    public int clip5Length;
    public AudioClip clip6;
    public int clip6Length;
    public AudioClip clip7;
    public int clip7Length;
    public AudioClip clip8;
    public int clip8Length;
    public AudioClip clip9;
    public int clip9Length;
    public AudioClip clip10;
    public int clip10Length;
    public AudioClip clip11;
    public int clip11Length;
    public AudioClip clip12;
    public int clip12Length;
    public AudioClip clip13;
    public int clip13Length;
    public AudioClip clip14;
    public int clip14Length;

    private bool canInteract;
    private bool isDipping;
    private bool isWithinRange;
    private Vector3[] locations;
    private float[] rotations;
    private AudioClip[] audioClips;
    private int[] audioClipLengths;
    private int locationNumber;
    private int clipNumber;

    // Start is called before the first frame update
    void Start()
    {
        canInteract = false;
        isDipping = false;
        isWithinRange = false;
        interactionText.SetActive(false);
        locationNumber = 0;
        clipNumber = 0;
        locations = new Vector3[10];
        rotations = new float[10];
        audioClips = new AudioClip[14];
        audioClipLengths = new int[14];
        audioClips[0] = clip1;
        audioClips[1] = clip2;
        audioClips[2] = clip3;
        audioClips[3] = clip4;
        audioClips[4] = clip5;
        audioClips[5] = clip6;
        audioClips[6] = clip7;
        audioClips[7] = clip8;
        audioClips[8] = clip9;
        audioClips[9] = clip10;
        audioClips[10] = clip11;
        audioClips[11] = clip12;
        audioClips[12] = clip13;
        audioClips[13] = clip14;
        audioClipLengths[0] = clip1Length;
        audioClipLengths[1] = clip2Length;
        audioClipLengths[2] = clip3Length;
        audioClipLengths[3] = clip4Length;
        audioClipLengths[4] = clip5Length;
        audioClipLengths[5] = clip6Length;
        audioClipLengths[6] = clip7Length;
        audioClipLengths[7] = clip8Length;
        audioClipLengths[8] = clip9Length;
        audioClipLengths[9] = clip10Length;
        audioClipLengths[10] = clip11Length;
        audioClipLengths[11] = clip12Length;
        audioClipLengths[12] = clip13Length;
        audioClipLengths[13] = clip14Length;
        locations[0] = startLocation;
        locations[1] = location1;
        locations[2] = location2;
        locations[3] = location3;
        locations[4] = location4;
        locations[5] = location5;
        locations[6] = location6;
        locations[7] = location7;
        locations[8] = location8;
        locations[9] = location9;
        rotations[0] = startRotation;
        rotations[1] = rotation1;
        rotations[2] = rotation2;
        rotations[3] = rotation3;
        rotations[4] = rotation4;
        rotations[5] = rotation5;
        rotations[6] = rotation6;
        rotations[7] = rotation7;
        rotations[8] = rotation8;
        rotations[9] = rotation9;
        transform.position = locations[0];
        transform.rotation.Set(0, rotations[0], 0, 0);
        StartCoroutine(playClip(audioClipLengths[clipNumber]));
    }

    // Update is called once per frame
    void Update()
    {
        if(isDipping == true)
        {
            transform.position = transform.position + transform.up * Time.deltaTime * 10;
            transform.Rotate(0, 1, 0);
        }

        if(Input.GetKeyDown(KeyCode.F) && canInteract && isWithinRange)
        {
            canInteract = false;
            StartCoroutine(playClip(audioClipLengths[clipNumber]));
        }

        if (canInteract == false)
        {
            interactionText.SetActive(false);
        }
    }

    private IEnumerator moveToNewSpot(Vector3 pos)
    {
        isDipping = true;
        yield return new WaitForSeconds(10);
        isDipping = false;
        transform.position = pos;
        transform.eulerAngles = new Vector3(0, rotations[locationNumber], 0);
        locationNumber++;
        canInteract = true;
    }

    private IEnumerator playClip(int clipLength)
    {
        AudioSource.PlayClipAtPoint(audioClips[clipNumber], this.transform.position);
        yield return new WaitForSeconds(clipLength);
        if(clipNumber < 3)
        {
            clipNumber++;
            StartCoroutine(playClip(audioClipLengths[clipNumber]));
        }
        else if(clipNumber == 3)
        {
            canInteract = true;
            clipNumber++;
        }
        else if(clipNumber == 4)
        {
            clipNumber++;
            StartCoroutine(playClip(audioClipLengths[clipNumber]));
        }
        else if(clipNumber == 5)
        {
            clipNumber++;
            locationNumber++;
            StartCoroutine(moveToNewSpot(locations[locationNumber]));
        }
        else if(clipNumber == 6)
        {
            clipNumber++;
            StartCoroutine(moveToNewSpot(locations[locationNumber]));
        }
        else if (clipNumber == 7)
        {
            clipNumber++;
            StartCoroutine(moveToNewSpot(locations[locationNumber]));
        }
        else if (clipNumber == 8)
        {
            clipNumber++;
            StartCoroutine(moveToNewSpot(locations[locationNumber]));
        }
        else if (clipNumber == 9)
        {
            clipNumber++;
            StartCoroutine(moveToNewSpot(locations[locationNumber]));
        }
        else if (clipNumber == 10)
        {
            clipNumber++;
            StartCoroutine(moveToNewSpot(locations[locationNumber]));
        }
        else if (clipNumber == 11)
        {
            clipNumber++;
            StartCoroutine(moveToNewSpot(locations[locationNumber]));
        }
        else if (clipNumber == 12)
        {
            clipNumber++;
            StartCoroutine(moveToNewSpot(locations[locationNumber]));
        }
        else if (clipNumber == 13)
        {
            clipNumber++;
            StartCoroutine(moveToNewSpot(locations[locationNumber]));
        }
        else if (clipNumber == 14)
        {
            clipNumber++;
            StartCoroutine(moveToNewSpot(locations[locationNumber]));
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isWithinRange = true;
        }
        if (other.gameObject.CompareTag("Player") && canInteract)
        {
            interactionText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interactionText.SetActive(false);
            isWithinRange = false;
        }
    }
}

