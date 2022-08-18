//Main Menu class is used to control what happens in the main menu 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public string RunningGame; //String to hold the name of the RunningGame scene inside of unity

    //StartGame is started when the application is first loaded up
    public void StartGame()
    {
        Application.LoadLevel(RunningGame); //When the user clicks on Start Game button, the application will load the next scene that is stored in the string RunningGame
    }

    //ExitGame is started when the user clicks on the Exit Game button
    public void ExitGame()
    {
        Application.Quit(); //When the user clicks on the Exit Game button, the application will close 
    }

}
