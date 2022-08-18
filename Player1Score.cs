//Player1Score is used to display the score of player 1
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1Score : MonoBehaviour 
{

    public Text showScore; //Text box that is placed in Unity Game Engine
    public float countScore; //Count to keep track of the score
    public bool increaseScore; //Boolean to stop incrementing the score when a player died

    // Start is called before the first frame update
    void Start()
    {
        increaseScore = true; //Sets the incrementor to true upon start
    }

    // Update is called once per frame
    void Update()
    {
        if (increaseScore == true) //While no player has died yet
        {
            countScore += 10 * Time.deltaTime; //Add score to the player's score
            showScore.text = "Player 1 Score: " + Mathf.Round(countScore); //Display the score to the user 
        }
    }
}
