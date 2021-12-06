using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuControl : MonoBehaviour
{
    bool Paused = false;
    public GameObject PauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (Paused == true)
            {
                Paused = false;
            }
            else if (Paused == false)
            {
                Paused = true;
            }
        }




        if(Paused == true)
        {
            PauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;     
        }
        else
        {
            PauseMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void Play()
    {
        PauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    public void Settings()
    {
        
    }

    public void Map()
    {

    }

    public void Quit()
    {

    }
}
