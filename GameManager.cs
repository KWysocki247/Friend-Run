//The GameManager class is used to handle restart's of the game when a player dies
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform platformGenerator; //Used to get the beginning positions of the platforms
    public PlayerControl player1; //Used to get the beginning positions of player1
    public Player2Control player2; //Used to get the beginning positions of player2
    public DeathScreen deathScreen; //Used to bring up the death screen after a player dies

    private Vector3 platformStartPoint; //Used to save the startpoint of the platform
    private Vector3 player1StartPoint; //Used to save the startpoint of the Player1
    private Vector3 player2StartPoint; //Used to save the startpoint of the Player2
    private PlatformDeletion[] list; //Used to gather all platforms currently in play to delete later
    private Player1Score player1score; //Used to store the player1Score
    private Player2Score player2score; //Used to store the player2Score

    // Start is called before the first frame update
    void Start()
    {
        platformStartPoint = platformGenerator.position; //Saves the platform x, y, and z positions
        player1StartPoint = player1.transform.position; //Saves the players x, y, and z positions
        player2StartPoint = player2.transform.position; //Saves the players x, y, and z positions
        player1score = FindObjectOfType<Player1Score>(); //Finds the players current score object
        player2score = FindObjectOfType<Player2Score>(); //Finds the players current score object 
    }


    public void RestartPlayer1() //If player1 died this function is called
    {
        player1.music.Stop(); //Stops the music
        player1score.increaseScore = false; //Sets the score to stop incrementing 
        player2score.increaseScore = false; //Sets the score to stop incrementing
        player1.gameObject.SetActive(false); //Sets the player1 object to be false
        player2.gameObject.SetActive(false); //Sets the player2 object to be false
        deathScreen.gameObject.SetActive(true); //Activates the Death Screen
        deathScreen.transform.GetChild(0).gameObject.SetActive(true); //Sets the player1Died text box to be true
        deathScreen.player1Died.text = "Player 1 Died"; //Displays that Player 1 Died
    }

    public void RestartPlayer2() //If player2 died this function is called
    {
        player1.music.Stop(); //Stops the music
        player1score.increaseScore = false; //Sets the score to stop incrementing 
        player2score.increaseScore = false; //Sets the score to stop incrementing
        player1.gameObject.SetActive(false); //Sets the player1 object to be false
        player2.gameObject.SetActive(false); //Sets the player2 object to be false
        deathScreen.gameObject.SetActive(true); //Activates the Death Screen
        deathScreen.transform.GetChild(1).gameObject.SetActive(true);  //Sets the player2Died text box to be true
        deathScreen.player1Died.text = "Player 2 Died"; //Displays that Player 2 Died
    } 

    public void ResetGame() //When the users click to Restart Game this function is called to reset all objects
    {
        deathScreen.gameObject.SetActive(false); //Sets the death screen to be inactive 
        list = FindObjectsOfType<PlatformDeletion>(); //creates a list of all platforms currently in use by the current session
        for (int i = 0; i < list.Length; i++) //for every object set them all to false to delete them and and not have them visible when the game starts up again
        {
            list[i].gameObject.SetActive(false);
        }
        player1.transform.position = player1StartPoint; //Puts player 1 to its origin point
        player2.transform.position = player2StartPoint; //Puts player 2 to its origin point 
        platformGenerator.position = platformStartPoint; //Puts the platform generator point back to its origin point
        player1.gameObject.SetActive(true); //Sets the player 1 object back to be true and visible
        player2.gameObject.SetActive(true); //Sets the player 2 object back to be true and visible
        player1score.countScore = 0; //Resets the score
        player2score.countScore = 0; //Resets the score
        player1score.increaseScore = true; //Sets the score incrementer back on
        player2score.increaseScore = true; //Sets the score incrementer back on
        deathScreen.player1Died.gameObject.SetActive(false); //Sets the message of who died to false
        deathScreen.player2Died.gameObject.SetActive(false); //Sets the message of who died to false
        player1.music.Play(); //Starts the music one more time
    }

}
