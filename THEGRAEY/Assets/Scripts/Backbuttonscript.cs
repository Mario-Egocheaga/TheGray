using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Backbuttonscript : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("Title");
    }
}
