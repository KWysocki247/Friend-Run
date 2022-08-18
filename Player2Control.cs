//The PlayerControl Class controls Player1 through the use of variables and the Start() and Update() functions

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Control : MonoBehaviour
{
    //All public variables are public so that we may control/modify them inside of the Unity Game Engine
    public float speed; //Controls player's movement speed
    public float jumpForce; //Controls how high a player can jump
    public float airTime; //Sets a static number for how long a player can be in the air for
    public bool AmIgrounded; //Boolean value use to detect if a player is touching the ground
    public LayerMask ground; //Used inside of the Unity Engine to set a Ground layer to help determine when we are on the ground
    public Transform groundDetection; //Used for better ground detection 
    public float groundDetectionRadius; //Used for better ground detection 
    public GameManager GM; //Used to restart the game if player 2 died

    //All private variables are not accessible by the Unity Game Engine and are only controlled/modified by the class
    private Rigidbody2D rigidBody; //Used to give the character physics in a 2D plane
    private Collider2D collider; //Used to help detect if a collision has been made
    private Animator animator; //Used to determine which animation should be displayed on the screen
    private float airTimeCounter; //Used to keep track how long we have been in the air for so that the character cannot fly forever 

    // Start is called before the first frame update
    void Start() //Automatically called when the game is started 
    {
        rigidBody = GetComponent<Rigidbody2D>(); //Set's the rigidBody value to the one's provided by the Unity Engine
        collider = GetComponent<Collider2D>(); //Set's the collider value to the one's provided by the Unity Engine
        animator = GetComponent<Animator>(); //Set's the animator value to the one's provided by the Unity Engine
        airTimeCounter = airTime; //Set's airTimeCounter to the set allowed time we can be in the air
    }

    // Update is called once per frame
    void Update() //Script that runs once per frame to determine how the character should be updated, in terms of position and whether they are jumping.
    {
        rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y); //Use a vector2 because we only need x,y values. Sets the x velocity of the rigidBody to the default speed and the y velocity to where the character's current y velocity. 
        //AmIgrounded = Physics2D.IsTouchingLayers(collider, ground); //Boolean function call to determine if the character is on the ground
        AmIgrounded = Physics2D.OverlapCircle(groundDetection.position, groundDetectionRadius, ground);

        if (Input.GetKeyDown(KeyCode.UpArrow)) //Determines if player presses the W key
        {
            if (AmIgrounded) //Check to see if we are on the ground, we are only allowed to jump if we are on the ground
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce); //Update the player's y velocity with the jumpForce
            }
        }
        if (Input.GetKey(KeyCode.UpArrow)) //Determines if the W key is being held down
        {
            if (airTimeCounter > 0) //Checks to see if we have reached the max allowed time to be in the air
            { //If we can still be in the air
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce); //Update the player's Y velocity with the jumpForce
                airTimeCounter -= Time.deltaTime; //Decrement the counter for how long we are allowed to be in the air
            }

        }
        if (Input.GetKeyUp(KeyCode.UpArrow)) //Determins when the player let's go of the W key
        {
            airTimeCounter = 0; //Reset's the airTimeCounter so when the player hits the floor we can jump again
        }
        if (AmIgrounded) //Checks to see when the player is touching the ground
        {
            airTimeCounter = airTime; //Set the airTimeCounter to the max allowed airTime
        }
        animator.SetFloat("Speed", rigidBody.velocity.x); //Checks to see if the character is idle or running and changes the animation of the character if he is running to the running animation 
        animator.SetBool("AmIGrounded", AmIgrounded); //Checks to see if the character is touching the ground, and if not then display the jumping animation
    }

    /*
    void OnCollisionEnter2D(Collision2D other) //Called when the player hits the death box
    {
        if (other.gameObject.tag == "death") //If the user hits the death box
        { 
            GM.RestartPlayer2(); //Stop the game and restart it
        }
    }
    
    */
}
