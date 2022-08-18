//The CameraController Class controlls how the camera moves as the game is played 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //All public variables are public so that we may control/modify them inside of the Unity Game Engine
    public PlayerControl player1; //Creates a PlayerControl to determine where Player1 currently is
    public Player2Control player2; //Creates a Plater2Control to determine where Player2 currently is

    //All private variables are not accessible by the Unity Game Engine and are only controlled/modified by the class
    //Vector3 is used for when we need x, y, and z coordinates
    private Vector3 lastPlayer1Position; //Creates a vector to get the last known position of Player1
    private Vector3 lastPlayer2Position; //Creates a vector to get the last known position of Player2
    private float distanceToMove; //Used to calcualte how far the camera has to move on the next frame

    // Start is called before the first frame update
    void Start() //Automatically called when the game is started 
    {
        player1 = FindObjectOfType<PlayerControl>(); //Find's the Player1 object to have it's coordinates available locally
        player2 = FindObjectOfType<Player2Control>(); //Find's the Player2 object to have it's coordinates available locally
        lastPlayer1Position = player1.transform.position; //Stores the x, y, z coordinates of Player1
        lastPlayer2Position = player2.transform.position; //Stores the x, y, z coordinates of Player2
    }

    // Update is called once per frame. Used to find how far the camera must move on each frame
    void Update()
    {
        if (player1.transform.position.x >= player2.transform.position.x) //Checks to see if Player1 is ahead of Player2
        {
            distanceToMove = player1.transform.position.x - lastPlayer1Position.x; //If Player1 is ahead, then the distance to move the camera is the subtraction of where player1 currently is and where player1 last was 
        }
        else
        {
            distanceToMove = player2.transform.position.x - lastPlayer2Position.x; //If Player2 is ahead, then the distance to move the camerais the subtraction of where player2 currently is and where player2 last was 
        }
        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z); //Set's the camera's new coordinates based of who is in the lead
        lastPlayer1Position = player1.transform.position; //Updates the last know position of player1 to the current position before running this script again on the next frame
        lastPlayer2Position = player2.transform.position; //Updates the last know position of player2 to the current position before running this script again on the next frame
    }
}
