//The PlatformGenerator Class is used to determine when a new platform should be created and which platform to chose from
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    //All public variables are public so that we may control/modify them inside of the Unity Game Engine
    public Transform generationPoint; //Creates a Transform object that will be used to determine if a new platform needs to be created 
    public float distanceBetween; //Calculates the distance between the last platform placed and the new one that is going to be placed
    public float distanceBetweenMin; //Set inside of the Unity Game Engine - used to determine the closest spot we can place another platform
    public float distanceBetweenMax; //Set inside of the Unity Game Engine - used to determine the farthest spot we can place another platform
    public Pooling[] poolingObjects; //An array used to store all available platforms that are currently not in use
    public Transform maxHeightPoint; //Set inside of Unity Game Engine - used to determine the highest point a platform can be placed
    public float maxHeightChange; //Set inside of Unity Game Engine - used to determine the maximum change the next block can be placed 

    //All private variables are not accessible by the Unity Game Engine and are only controlled/modified by the class
    private int randomPlatformSelector; //Used to randomly determine which platform will be placed next
    private float[] arrayPlatformWidth; //Used to store all the Width's of all platforms that may be placaed
    private float minHeight; //Used to determine the minimum height a block can be placed
    private float maxHeight; //Used to determine the maximum height a block can be placed
    private float differenceBetweenHeight; //Used to determine the difference between the last placed platform and the newest one 



    // Start is called before the first frame update
    void Start() //Automatically called when the game is started 
    {
        arrayPlatformWidth = new float[poolingObjects.Length]; //Sets the array to the length specified inside of Unity Game Engine
        for(int i = 0; i < poolingObjects.Length; i++) //For every platform we have in the Unity Game Engine
        {
            arrayPlatformWidth[i] = poolingObjects[i].pooledObjects.GetComponent<BoxCollider2D>().size.x; //Add the width of that platform to the array
        }
        minHeight = transform.position.y; //Set's the minHeight to the lowest position specified inside of Unity Game Engine 
        maxHeight = maxHeightPoint.position.y; //Set's the minHeight to the highest position specified inside of Unity Game Engine by the maxHeightPoint object
    }

    // Update is called once per frame. Used to determine if we have reached the point when a new platform should be generated or not. If so, determines which block will be placed and where
    void Update()
    {
        if(transform.position.x < generationPoint.position.x) //Checks to see if we reached the point when we need to place another platform 
        {
            randomPlatformSelector = Random.Range(0, poolingObjects.Length); //Selects a random number to help determine which platform we will place next
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax); //Calculates the next distance new distance a platform will be placed, between the minumum set distance and the maximum set distance 
            differenceBetweenHeight = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange); //Calculates the height difference between the last placed block and the next block to be placed
            if(differenceBetweenHeight > maxHeight) //Checks to see if the next platform placement will higher than the default ceiling value established in Unity Game Engine 
            {
                differenceBetweenHeight = maxHeight; //Sets the next platform to spawn at the highest point we allow
            }
            else if(differenceBetweenHeight < minHeight) //Checks to see if the next platform placement will lower than the default floor value established in Unity Game Engine
            {
                differenceBetweenHeight = minHeight; //Sets the next platform to spawn at the lowest point we allow
            }
            transform.position = new Vector3(transform.position.x + (arrayPlatformWidth[randomPlatformSelector] / 2) + distanceBetween, differenceBetweenHeight, transform.position.z); //Sets the x, y, and z cooridinates of the new platform to be placed       
            GameObject pooledPlatform = poolingObjects[randomPlatformSelector].GetPooledObjects(); //Grabs the randomly selected platform from the array
            pooledPlatform.transform.position = transform.position; //Sets the position of the new platform to the one we just calculated 
            pooledPlatform.transform.rotation = transform.rotation; //Sets the roration value of the new platform to the one we just calculated 
            pooledPlatform.SetActive(true); //Sets the platform used to be true, meaning that it is currently being used 
            transform.position = new Vector3(transform.position.x + (arrayPlatformWidth[randomPlatformSelector] / 2), transform.position.y, transform.position.z); //Moves the PlatformGenerator object in Unity Game Engine to be further and appropriately spawn the next one after this one is placed
        }
    }
}
