using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//things that contain code use PascalCasing (EveryWordIsCapital)



public class PlayerMovement : MonoBehaviour
{
    //Variables or the data we are manipulating use camelCasing (First word lower case, rest of the worlds upper case)


    [Header("Player Speeds")]
    [Tooltip("The speed applied to the character and what we pass to the animator controller")]
    public float speed = 0.0f;//the speed applied to the charater and what we pass to the animator controller
    //these values bellow are so we have set values to change between
    public float crouchSpeed = 2.5f;//the speed for crouching
    public float walkSpeed = 5.0f;//speed for walking
    public float runSpeed = 10.0f;//speed for running
    public float jumpSpeed = 8.0f;



    [Header("Directions")]
    public float leftRight = 0.0f;
    public float forwardBack = 0.0f;
    public Vector3 moveDirection;//we will use this to move in 3d space
    //we will do this by applying the left right value to our x axis of the world
    //and by applying the forwardBack value to our z axis of the world
    public float isCrouching = 0.0f;//this is what will control our 2 idle states, crouching vs standing
    public float gravity = 12.0f;//character controller does not have inbuilt gravity so we make our own
    public float isJumping = 0.0f; //this is what will control if we are jumping or not


    [Header("Components")]
    //When we create variable that connect to components on object in our game scene
    //we must then tell the component which object to get the component from
    public Animator animator;//this is a reference to the players animator/animator controller
    public CharacterController characterController;
    //this is a reference to the players character controller, this allows us to move the player

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //attaching the Animator on our game object to our reference
        characterController = GetComponent<CharacterController>();




    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(characterController.isGrounded);

        if (characterController.isGrounded)
        {
            leftRight = Input.GetAxis("Horizontal");//get the input value for left and right
            forwardBack = Input.GetAxis("Vertical");

            moveDirection = transform.TransformDirection(new Vector3(leftRight, 0, forwardBack));
            //adjust speed

            //if this condition is met
            //if our value for leftRight isnt equal to 0 we are movign side to side
            //if our value for forwardBack isnt equal to 0 we are move forward and back
            //if our leftRight value is not equal to 0 or our forwardBack value is not equal to 0 then we are moving
            if (leftRight != 0 || forwardBack != 0)
            {

                //if we are sprinting
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    //set our speed to runSpeed
                    speed = runSpeed;
                }

                //else if we are crouching
                else if (Input.GetKey(KeyCode.LeftControl))
                {
                    //set our speed to  crouchSpeed
                    speed = crouchSpeed;
                }




                //we msut be walking
                else
                {
                    speed = walkSpeed;
                }
            }


            else//we are not moving
            {
                //set our speed to 0
                speed = 0;
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    //we are crouching
                    isCrouching = 0;
                }
                else//we are not pressing crouch
                {
                    //so we are standing
                    isCrouching = 1;
                }





            }



            //apply the speed that we set to our direction
            moveDirection *= speed;


            if (Input.GetKey(KeyCode.Space))
            {
                isJumping = 1;
                moveDirection.y = jumpSpeed;

            }

            else
            {
                isJumping = 0;
            }




        }



        //apply a downward force to the character that simulates gravity
        moveDirection.y -= gravity * Time.deltaTime;
        //using the CharacterController, we are utilizing the inbuilt Move function to apply our movement
        characterController.Move(moveDirection * Time.deltaTime);
        //Connect our values to our animations
        //apply speed values to the animator
        animator.SetFloat("Speed", speed);
        //apply leftRight value to the animator
        animator.SetFloat("LeftRight", leftRight);
        //apply forwardBack value to the animator
        animator.SetFloat("ForwardBack", forwardBack);
        //apply IsCrouching value to the animator
        animator.SetFloat("IsCrouching", isCrouching);
        //apply jumpSpeed value to the animator
        animator.SetFloat("IsJumping", isJumping);





    }
}
