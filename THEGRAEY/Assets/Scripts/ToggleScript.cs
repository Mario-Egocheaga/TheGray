using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleScript : MonoBehaviour
{
    public GameObject skillTree;
    public GameObject HUD;
    public GameObject MiniMap;
    public GameObject Camera;

    private bool DisplayHUD = false;
    
    // Start is called before the first frame update
    void Start()
    {
        skillTree.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (DisplayHUD == true)
            {
                DisplayHUD = false;
            }
            else if (DisplayHUD == false)
            {
                DisplayHUD = true;
            }
        }

        if(DisplayHUD == true)
        {
            skillTree.SetActive(true);
            Cursor.lockState = CursorLockMode.None;

            HUD.SetActive(false);
            MiniMap.SetActive(false);
           Camera.GetComponent<CameraController>().enabled = false;
        
        }   
        else
        {
            
            skillTree.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            HUD.SetActive(true);
            MiniMap.SetActive(true);
            Camera.GetComponent<CameraController>().enabled = true;
        }
    }
}
