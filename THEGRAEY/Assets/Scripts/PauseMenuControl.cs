using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuControl : MonoBehaviour
{
    bool Paused = false;
    public GameObject PauseMenu;
    public GameObject MapUI;
    public GameObject SettingUI;
    
    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        MapUI.SetActive(false);
        SettingUI.SetActive(false);

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
            Time.timeScale = 0f;
        }
        else
        {
            PauseMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }
    }

    public void Play()
    {
        PauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    public void Settings()
    {
        SettingUI.SetActive(true);
        MapUI.SetActive(false);
        PauseMenu.SetActive(false);
    }

    public void Map()
    {
        MapUI.SetActive(true);
        SettingUI.SetActive(false);
        PauseMenu.SetActive(false);
    }

    public void Quit()
    {

    }
}
