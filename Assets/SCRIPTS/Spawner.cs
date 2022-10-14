using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //Create a public array of objects to spawn, we will fill this up using the Unity Editor
    public GameObject[] objectsToSpawn;
    float timeToNextSpawn; //Tracks how long we should wait before spawniing a new object
    float timeSinceLastSpawn = 0.0f; //Tracks the time since we last spawned something

    public float minSpawnTime = 0.5f; //Minimum amount of time between spawning objects
    public float maxSpawnTime = 3.0f; //Maximum amount of time between spawning objects

    void Start()
    {
        //Random.Range returns a random float between to values
        timeToNextSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }

    void Update()
    {
        //Add Time.deltaTime returns the amount of time passed since the last frame.
        //This will create a float that counts up in seconds
        timeSinceLastSpawn = timeSinceLastSpawn + Time.deltaTime;

        //If we've counted past the amount of time we need to wait...
        if (timeSinceLastSpawn > timeToNextSpawn)
        {
            //Use Random.Range to pick a number between 0 and the amount of items we have on our object list
            int selection = Random.Range(0, objectsToSpawn.Length);

            Instantiate(objectsToSpawn[selection], transform.position, Quaternion.identity);

            timeToNextSpawn = Random.Range(minSpawnTime, maxSpawnTime);
            timeSinceLastSpawn = 0.0f;
        }
    }
}
