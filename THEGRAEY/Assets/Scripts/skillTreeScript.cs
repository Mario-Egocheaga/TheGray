using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillTreeScript : MonoBehaviour
{
    //UI Mouse position VAriable
    public Vector2 moveInput;

    public Image CanvasImageUpLeft;
    public Image CanvasImageLeft;
    public Image CanvasImageUpRight;
    public Image CanvasImageRight;
    public Image CanvasImagebottom;
    public Sprite Empty;
    public Sprite Red;
    public Sprite Yellow;
    public Sprite Purple;
    public Sprite Green;
    public Sprite Blue;

    public Text skillType;
    public Text skillName;
    public Text skillDescript;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.mousePosition.x - (Screen.width / 2f);
        moveInput.y = Input.mousePosition.y - (Screen.height / 2f);
        moveInput.Normalize();

        

        //Radial MenuSelection
        if (moveInput != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveInput.y, -moveInput.x);
           

            //Location If's tracking mouse position
            if (angle > .63 && angle < 1.56)
            {

                Debug.Log("Top Left");
                CanvasImageUpLeft.sprite = Red;
                CanvasImagebottom.sprite = Empty;
                CanvasImageUpRight.sprite = Empty;
                CanvasImageRight.sprite = Empty;
                CanvasImageLeft.sprite = Empty;

                skillType.text = "Dashing";

            }
            else if (angle > 1.56 && angle < 2.5)
            {
                CanvasImageUpLeft.sprite = Empty;
                CanvasImagebottom.sprite = Empty;
                CanvasImageUpRight.sprite = Yellow;
                CanvasImageRight.sprite = Empty;
                CanvasImageLeft.sprite = Empty;
                Debug.Log("Top Right");

                skillType.text = "Jumping";
            }
            else if (angle > 2.5 || angle < -2.47)
            {
                CanvasImageUpLeft.sprite = Empty;
                CanvasImagebottom.sprite = Empty;
                CanvasImageUpRight.sprite = Empty;
                CanvasImageRight.sprite = Purple;
                CanvasImageLeft.sprite = Empty;
                Debug.Log("right");

                skillType.text = "Sliding";
            }
            else if (angle > -2.5 && angle < -.64)
            {
                CanvasImageUpLeft.sprite = Empty;
                CanvasImagebottom.sprite = Green;
                CanvasImageUpRight.sprite = Empty;
                CanvasImageRight.sprite = Empty;
                CanvasImageLeft.sprite = Empty;
                Debug.Log("bottom");


                skillType.text = "Crouching";
            }
            else if (angle > -.64 && angle < .63)
            {
                CanvasImageUpLeft.sprite = Empty;
                CanvasImagebottom.sprite = Empty;
                CanvasImageUpRight.sprite = Empty;
                CanvasImageRight.sprite = Empty;
                CanvasImageLeft.sprite = Blue;
                Debug.Log("Left");

                skillType.text = "Wall-Running";
            }
            
        }
        
        
    }
}
