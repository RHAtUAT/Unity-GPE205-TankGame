﻿using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public float respawnTime;
    public GameObject powerupPrefab;
    public GameObject spawnedObject;
    public List<Transform> spawnLocations = new List<Transform>();

    private float respawnCountDown;


    // Start is called before the first frame update
    void Start()
    {

        if (spawnLocations.Count > 0)
        {
            //Spawn a powerup in a random location
            int locID = Random.Range(0, spawnLocations.Count);
            spawnedObject = Instantiate<GameObject>(powerupPrefab, spawnLocations[locID].position, spawnLocations[locID].rotation);

            //Reset timer
            respawnCountDown = respawnTime;
        }
        else
            Debug.LogWarning("No Spawn Locations set for PowerupSpawner");
    }

    // Update is called once per frame
    void Update()
    {
        //If no powerup has spawned
        if (spawnedObject == null)
        {
            //Start the timer
            //respawnCountDown -= Time.deltaTime;
            //Debug.Log("RespawnTime: " + respawnTime);
            //Debug.Log("RespawnCountDown: " + respawnCountDown);
            //Debug.Log("Time: " + Time.deltaTime);

            //And its time for one to spawn
            if (respawnCountDown <= 0)
            {
                if (spawnLocations.Count > 0)
                {
                    //Spawn a powerup in a random location
                    int locID = Random.Range(0, spawnLocations.Count);
                    spawnedObject = Instantiate<GameObject>(powerupPrefab, spawnLocations[locID].position, spawnLocations[locID].rotation);

                    //Reset timer
                    respawnCountDown = respawnTime;
                }
                else
                {
                    Debug.LogWarning("No Spawn Locations set for PowerupSpawner");
                }
            }
        }
    }
}
