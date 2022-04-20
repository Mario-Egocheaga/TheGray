using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToggleScript : MonoBehaviour
{
    public GameObject skillTree;
    public GameObject TogMap;
    public GameObject HUD;
    public GameObject MiniMap;
    public GameObject Camera;
    public GameObject Pause;

    private bool DisplayHUD = false;
    private bool Map = false;
    private bool isPaused = false;
    
    // Start is called before the first frame update
    void Start()
    {
        skillTree.SetActive(false);
        TogMap.SetActive(false);
        Pause.SetActive(false);

        Time.timeScale = 1;
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == true)
            {
                HUD.SetActive(false);
                MiniMap.SetActive(false);
                Pause.SetActive(true);
                TogMap.SetActive(false);
                skillTree.SetActive(false);
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.Confined;

                isPaused = false;
            }
            else if (isPaused == false)
            {
                HUD.SetActive(true);
                MiniMap.SetActive(true);
                Pause.SetActive(false);
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;

                isPaused = true;
            }
        }


        if (DisplayHUD == true)
        {
            HUD.SetActive(false);
            MiniMap.SetActive(false);
            Camera.GetComponent<CameraController>().enabled = false;
            Cursor.lockState = CursorLockMode.None;

            if(Map == true)
            {
                skillTree.SetActive(false);
                TogMap.SetActive(true);

                if (Input.mouseScrollDelta.y > 0 || Input.mouseScrollDelta.y < 0)
                {
                    Map = false;
                }
            }
            else if (Map == false)
            {
                if(Input.mouseScrollDelta.y > 0 || Input.mouseScrollDelta.y < 0)
                {
                    Map = true;
                }
               skillTree.SetActive(true);
               TogMap.SetActive(false); 
            }
            
        
        }   
        else
        {
            TogMap.SetActive(false);
            skillTree.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            HUD.SetActive(true);
            MiniMap.SetActive(true);
            Camera.GetComponent<CameraController>().enabled = true;
        }
    }

    public void Play()
    {
        isPaused = false;
    }

    public void Quit()
    {
        SceneManager.LoadScene("Title");
    }
}
