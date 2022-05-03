using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuControl : MonoBehaviour
{
    bool Paused = false;
    public GameObject PauseMenu;
    public GameObject MapUI;
    public GameObject SettingUI;
    public GameObject LogTab;
    public GameObject SkillTab;

    
    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        MapUI.SetActive(false);
        SettingUI.SetActive(false);

        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
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
            Cursor.visible = true;
            Time.timeScale = 0f;
        }
        else
        {
            PauseMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1f;
        }
    }

    public void Play()
    {
        Paused = false;
    }
    
    public void Settings()
    {
        SettingUI.SetActive(true);
        MapUI.SetActive(false);
        PauseMenu.SetActive(false);
        LogTab.SetActive(false);
        SkillTab.SetActive(false);
    }

    public void Skills()
    {
        Debug.Log("YOYOYOYO IT WORKED BIOIIIIII");
        SettingUI.SetActive(false);
        MapUI.SetActive(false);
        PauseMenu.SetActive(false);
        LogTab.SetActive(false);
        SkillTab.SetActive(true);
    }

    public void Map()
    {
        MapUI.SetActive(true);
        SettingUI.SetActive(false);
        PauseMenu.SetActive(false);
        LogTab.SetActive(false);
        SkillTab.SetActive(false);
    }

    public void Logs()
    {
        MapUI.SetActive(false);
        SettingUI.SetActive(false);
        PauseMenu.SetActive(false);
        LogTab.SetActive(true);
        SkillTab.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
