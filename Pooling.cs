//The Pooling Class is used to determine if a new platform object needs to be created, and if not we can reuse one that was already created 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class Pooling : MonoBehaviour
{

    //All public variables are public so that we may control/modify them inside of the Unity Game Engine
    public GameObject pooledObjects; //Creates a pooledObjects variable that will be used to create new platforms and add to the List we have 
    public int pooledAmount; //Set inside of the Unity Game Engine - used to determine how big the List<GameObject> poolingList List will be
    public List<GameObject> poolingList; //List that will be used to store all made platforms to help determine if new platforms need to be created or if we can reuse one that was created 
    
    // Start is called before the first frame update
    void Start() //Automatically called when the game is started 
    {
        poolingList = new List<GameObject>(); //Instantiates a new List of GameObjects to store the platforms 
        for(int i = 0; i < pooledAmount; i++) //For the amount of allowed pooled objects set inside of Unity Game Engine 
        {
            GameObject toBePooled = (GameObject) Instantiate(pooledObjects); //Creates a toBePooled object of a platform that was selected
            toBePooled.SetActive(false); //Set's that platform as false, meaning we are not using it yet
            poolingList.Add(toBePooled); //Add's the platform to the List so we can check later if the platform is in use or not
        }
    }

    public GameObject GetPooledObjects() //Created a GetPooledObject function used to get a pooled object if available. If not we create a new one and add it to the List
    {
        for (int i = 0; i < poolingList.Count; i++) //Check the whole size of the List for an available platform
        {
            if (!poolingList[i].activeInHierarchy)
            {
                return poolingList[i]; //If we found an available platform, we return that platform and end the function call 
            }
        }
        GameObject toBePooled = (GameObject)Instantiate(pooledObjects); //If no platform is available in the List, we create a new platform object
        toBePooled.SetActive(false); //Set the platform to false, meaning we are not using it
        poolingList.Add(toBePooled); //Adds the platform to the List
        return toBePooled; //Returns the platform
    }
}
