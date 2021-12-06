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

    public Image DashGrey;
    public Image DashColor;
    public GameObject DashButton;

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

        //Button selection
       

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

                if(PlayerController.dashUnlocked == true)
                {
                    var img = DashButton.GetComponent<Image>();
                    img = DashColor;

                }
                else
                {
                    var img = DashButton.GetComponent<Image>();
                    img = DashGrey;
                }

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

    public void Dash1()
    {
        skillName.text = "Dash";
        skillDescript.text = "Allows the player to be propelled forward by pressing 'Q'.";
    }
    public void Dash2()
    {
        skillName.text = "Extended Dash";
        skillDescript.text = "Allows the player to be propelled forward 50% farther by pressing 'Q'.";
    }
    public void Dash3()
    {
        skillName.text = "Jump Dash";
        skillDescript.text = "Allows the player to be propelled forward through the air after a single jump by pressing 'Q' while in the air.";
    }
    public void Jump1()
    {
        skillName.text = "Double Jump";
        skillDescript.text = "Allows the player to double jump by pressing space in the air to preform a second jump.";
    }
    public void Jump2()
    {
        skillName.text = "Slam";
        skillDescript.text = "Allows the player to double jump and slam down into the ground by pressing '#'.";
    }
    public void jump3()
    {
        skillName.text = "Dangle";
        skillDescript.text = "Allows the player to be suspend themselves in the air for 'x' amount of seconds.";
    }
    public void jump4()
    {
        skillName.text = "Hover";
        skillDescript.text = "Allows the player to be freeze themselves in the air for 'x' amount of seconds.";
    }
    public void slide1()
    {
        skillName.text = "Slide";
        skillDescript.text = "Allows the player to be slide through small gaps. Press 'C' while sprinting to slide.";
    }
    public void slide2()
    {
        skillName.text = "Extended Slide";
        skillDescript.text = "Allows the player to slide greater distances by criouching after sprinting.";
    }
    public void crouch1()
    {
        skillName.text = "Low Profile";
        skillDescript.text = "Allows the player to be less detectable to enemies while crouching.";
    }
    public void crouch2()
    {
        skillName.text = "Plain Sight";
        skillDescript.text = "Allows the player to go undetectable to enemies while crouching for X seconds.";
    }
    public void wall1()
    {
        skillName.text = "Grab";
        skillDescript.text = "Allows the player to Grab shit";
    }
    public void wall2()
    {
        skillName.text = "Grab 2";
        skillDescript.text = "Allows the player to do more grabbing of shit";
    }

}
