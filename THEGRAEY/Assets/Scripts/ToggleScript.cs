using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleScript : MonoBehaviour
{
    public GameObject skillTree;

    // Start is called before the first frame update
    void Start()
    {
        skillTree.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            skillTree.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            skillTree.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
