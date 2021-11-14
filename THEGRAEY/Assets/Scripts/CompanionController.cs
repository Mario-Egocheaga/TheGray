using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionController : MonoBehaviour
{
    public Vector3 location1;
    public Vector3 location2;
    public Vector3 location3;
    public Vector3 location4;
    public Vector3 location5;

    private bool isDipping;

    // Start is called before the first frame update
    void Start()
    {
        isDipping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDipping == true)
        {
            transform.position = transform.position + transform.up * Time.deltaTime * 10;
            transform.Rotate(0, 1, 0);
        }

        if(Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine(moveToNewSpot(location1));
        }
    }

    private IEnumerator moveToNewSpot(Vector3 pos)
    {
        isDipping = true;
        yield return new WaitForSeconds(10);
        isDipping = false;
        transform.position = pos;
    }
}
