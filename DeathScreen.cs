//DeathScreen controls what is displayed when a user dies 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    public string mainMenu; //Used to store the mainMenu string
    public Text player1Died; //Used to display player1Died
    public Text player2Died; //Used to display player2Died

    // Start is called before the first frame update
    public void RestartGame() //Called when RestartGame button is clicked
    {
        FindObjectOfType<GameManager>().ResetGame(); //Resets the players to their original starting positions
    }

    //Called if Main Menu option is selected
    public void GoToMainMenu()
    {
        Application.LoadLevel(mainMenu); //Loads the scene we have stores as main Menu
    }
}
