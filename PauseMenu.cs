//PauseMenu controls what happens when a player pauses the game
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public string mainMenu; //string to store the mainMenu option
    public GameObject pauseMenu; //pauseMenu object used to set pause menu as active or not

    //Called when the user selects the Restart Game option
    public void RestartGame()
    {
        Time.timeScale = 1f; //Unfreezes the game
        gameObject.SetActive(false); //Sets the scene as false
        FindObjectOfType<GameManager>().ResetGame(); //Resets all players and platforms
    }

    //Called when the user selects the Main Menu option
    public void GoToMainMenu()
    {
        Time.timeScale = 1f; //Unfreezes the game
        gameObject.SetActive(false); //Sets the scene as false
        Application.LoadLevel(mainMenu); //Loads to the Main Menu
    }

    //Called when the user presses the Escape key
    public void PauseGame()
    {
        pauseMenu.SetActive(true); //Sets the pauseMenu object to be active
        Time.timeScale = 0f; //Freezes all objects in the game
    }

    //Called when the user selects the Resume button
    public void UnPauseGame()
    {
        gameObject.SetActive(false); //Sets the scene as false
        Time.timeScale = 1f; //Unfreezes all objects 
        
    }
}
