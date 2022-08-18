//The PlatformDeletion Class is used to set objects as false when we no longer see them on screen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDeletion : MonoBehaviour
{

    //All public variables are public so that we may control/modify them inside of the Unity Game Engine
    public GameObject deletionPoint; //Creates a deletionPoint object to check when we should remove platform's from memory


    // Start is called before the first frame update
    void Start() //Automatically called when the game is started 
    {
        deletionPoint = GameObject.Find("PlatformDeletionPoint");  //Set's the deletionPoint variable equal to where we have placed it inside of the Unity Game Engine
    }

    // Update is called once per frame. Checks to see when an object should be removed from memory
    void Update()
    {
        if(transform.position.x < deletionPoint.transform.position.x) //Checks to see if the platform is past the deletionPoint
        {
            gameObject.SetActive(false); //If the platform is passed the deletionPoint, we remove it from the memory and make it available in the Pooling system we have created
        }
    }
}
