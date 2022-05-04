using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillTreeScript : MonoBehaviour
{
    //UI Mouse position VAriable
    public Vector2 moveInput;

    public Image CanvasImageUpLeft;
    public Image CanvasImageDLeft;
    public Image CanvasImageUpRight;
    public Image CanvasImageDRight;
   
    public Sprite Empty;
    public Sprite Red;
    public Sprite Yellow;
    //public Sprite Purple;
    public Sprite Green;
    public Sprite Blue;

    public Text skillType;
    public Text skillName;
    public Text skillDescript;

    public Sprite DashGrey;
    public Sprite DashColor;
    public Button DashButton;
    public Sprite Dash_2_Color;
    public Sprite Dash_2_Grey;
    public Button Dash_2_Button;
    public Sprite Dash_3_Color;
    public Sprite Dash_3_Grey;
    public Button Dash_3_Button;
    public Sprite Dash_4_Color;
    public Sprite Dash_4_Grey;
    public Button Dash_4_Button;

    public Sprite jumpColor;
    public Sprite jumpGrey;
    public Button jumpButton;
    public Sprite jump_2_Color;
    public Sprite jump_2_Grey;
    public Button jump_2_Button;
    public Sprite jump_3_Color;
    public Sprite jump_3_Grey;
    public Button jump_3_Button;


    //public Sprite slideColor;
    //public Sprite slideGrey;
   // public Button slideButton;
   // public Sprite slide_2_Color;
    //public Sprite slide_2_Grey;
    //public Button slide_2_Button;

    public Sprite crouchColor;
    public Sprite crouchGrey;
    public Button crouchButton;


    public Sprite WallColor;
    public Sprite WallGrey;
    public Button WallButton;
    public Sprite Wall_2_Color;
    public Sprite Wall_2_Grey;
    public Button Wall_2_Button;

    // Start is called before the first frame update
    void Start()
    {
        DashButton.image.sprite = DashGrey;
        Dash_2_Button.image.sprite = Dash_2_Grey;
        Dash_3_Button.image.sprite = Dash_3_Grey;
        Dash_4_Button.image.sprite = Dash_4_Grey;

        jumpButton.image.sprite = jumpGrey;
        jump_2_Button.image.sprite = jump_2_Grey;
        jump_3_Button.image.sprite = jump_3_Grey;
        
        

        //slideButton.image.sprite = slideGrey;
        //slide_2_Button.image.sprite = slide_2_Grey;
        

       crouchButton.image.sprite = crouchGrey;
        

        WallButton.image.sprite = WallGrey;
        Wall_2_Button.image.sprite = Wall_2_Grey;

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
            if (angle > 0 && angle < 1.5)
            {

                Debug.Log("Top Left");
                CanvasImageUpLeft.sprite = Red;
                
                CanvasImageUpRight.sprite = Empty;
                CanvasImageDRight.sprite = Empty;
                CanvasImageDLeft.sprite = Empty;

                jumpButton.SetActive(false);

                skillType.text = "Dash";

                if(PlayerController.dashUnlocked == true)
                {
                    DashButton.image.sprite = DashColor;

                }
                if (PlayerController.jumpDashUnlocked == true)
                {
                    Dash_3_Button.image.sprite = Dash_3_Color;

                }
                if (PlayerController.extendedDashUnlocked == true)
                {
                    Dash_2_Button.image.sprite = Dash_2_Color;

                }
                //if (PlayerController.dashRecallUnlocked == true)
                //{
                    //Dash_4_Button.image.sprite = Dash_4_Color;

                //}
                //else
                //{
                   // DashButton.image.sprite = DashGrey;
                   // Dash_2_Button.image.sprite = Dash_2_Grey;
                   // Dash_3_Button.image.sprite = Dash_3_Grey;
                    //Dash_4_Button.image.sprite = Dash_4_Grey;
               //}

            }
            else if (angle > 1.5 && angle < 3)
            {
                CanvasImageUpLeft.sprite = Empty;
                
                CanvasImageUpRight.sprite = Yellow;
                CanvasImageDRight.sprite = Empty;
                CanvasImageDLeft.sprite = Empty;
                Debug.Log("Top Right");

                skillType.text = "Porple";

                if (PlayerController.doubleJumpUnlocked == true)
                {
                    jumpButton.image.sprite = jumpColor;

                }
                if (PlayerController.slamUnlocked == true)
                {
                    jump_2_Button.image.sprite = jump_2_Color;

                }
                if (PlayerController.slamUnlocked == true)
                {
                    jump_3_Button.image.sprite = jump_3_Color;

                }
                //else
                //{
                //jumpButton.image.sprite = jumpGrey;
                //jump_2_Button.image.sprite = jump_2_Grey;
                //jump_3_Button.image.sprite = jump_3_Grey;
                //jump_4_Button.image.sprite = jump_4_Grey;
                //}
                //if (PlayerController.# == true)
                //{
                //jump_3_Button.image.sprite = jump_3_Color;

                //}
                //if (PlayerController.# == true)
                //{
                //jump_4_Button.image.sprite = jump_4_Color;

                //}

            }
            else if (angle < -1.5 && angle > -3 )
            {
                CanvasImageUpLeft.sprite = Empty;
                
                CanvasImageUpRight.sprite = Empty;
                CanvasImageDRight.sprite = Blue;
                CanvasImageDLeft.sprite = Empty;
                Debug.Log("right");

                skillType.text = "crouching";

                //if (PlayerController.slideUnlocked == true)
                //{
                    //slideButton.image.sprite = slideColor;

                //}
                //if (PlayerController.# == true)
                //{
                   // slide_2_Button.image.sprite = slide_2_Color;

                //}
                //else
                //{
                    //slideButton.image.sprite = slideGrey;
                    //slide_2_Button.image.sprite = slide_2_Grey;
                    
                //}
            }
            //else if (angle > -2.5 && angle < -.64)
            //{
                //CanvasImageUpLeft.sprite = Empty;
                //CanvasImagebottom.sprite = Green;
                //CanvasImageUpRight.sprite = Empty;
                //CanvasImageRight.sprite = Empty;
                //CanvasImageLeft.sprite = Empty;
                //Debug.Log("bottom");


                //skillType.text = "Crouching";

                //if (PlayerController.# == true)
                //{
                    //crouchButton.image.sprite = crouchColor;

                //}
                //if (PlayerController.plainSightUnlocked == true)
                //{
                    //crouch_2_Button.image.sprite = crouch_2_Color;

                //}
                //else
                //{
                    //crouchButton.image.sprite = crouchGrey;
                    //crouch_2_Button.image.sprite = crouch_2_Grey;
                    
                //}
            //}
            else if (angle > -.64 && angle < .63)
            {
                CanvasImageUpLeft.sprite = Empty;
                
                CanvasImageUpRight.sprite = Empty;
                CanvasImageDRight.sprite = Empty;
                CanvasImageDLeft.sprite = Green;
                Debug.Log("Left");

                skillType.text = "Jump";

                //if (PlayerController.wallGrabUnlocked == true)
                //{
                    //WallButton.image.sprite = WallColor;

                //}
                if (PlayerController.wallRunUnlocked == true)
                {
                    Wall_2_Button.image.sprite = Wall_2_Color;

                }
                //else
                //{
                    //WallButton.image.sprite = DashGrey;
                    //Wall_2_Button.image.sprite = Dash_2_Grey;
                    
                //}
            }
            
        }
        
        
    }


    //Skill descriptions
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
    public void Dash4()
    {
        skillName.text = "Dash Recall";
        skillDescript.text = "Allows the player to 'Recall' their dash soon after completing it and be returned to  the previous position.";
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
        skillName.text = "Wall Grab";
        skillDescript.text = "Allows the player to Grab on to the wall and hold their position.";
    }
    public void wall2()
    {
        skillName.text = "Wall Run";
        skillDescript.text = "Allows the player to jump and run along a wall while holding on to it.";
    }

}
