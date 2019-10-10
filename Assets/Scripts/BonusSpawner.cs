using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    // Area to spawn in by X and Z axis
    public float X = 7f;
    public float Z = 5f;

    // Bonuses to instantiate
    public GameObject bonus1, bonus2, bonus3;

    // Spawn rate per seconds
    public float spawnRate = 5f;

    // Variable to set next spawn time
    float nextSpawn = 5f;

    // Variables with random values
    int whatToSpawn;
    Vector3 spawnPos;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            whatToSpawn = Random.Range (1,4);
            spawnPos = new Vector3(Random.Range (-X, X), 1, Random.Range (-Z, Z));

            // Spawns a bonus depending on the random value
        switch (whatToSpawn)
        {
            case 1:
                Instantiate (bonus1, spawnPos, Quaternion.identity);
                break;
            case 2:
                Instantiate (bonus2, spawnPos, Quaternion.identity);
                break;
            case 3:
                Instantiate (bonus3, spawnPos, Quaternion.identity);
                break;
            default:
            Debug.LogError("No bonus spawned");
            break;
        }

        // Set the next spawn time
        nextSpawn = Time.time + spawnRate;
        }
    }
}
