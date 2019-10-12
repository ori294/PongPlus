using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    // Area to spawn in by X and Z axis
    public float X = 7f;
    public float Z = 5f;

    // Bonuses to instantiate
    public List<Bonus> bonuses = new List<Bonus>();

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
            Random.InitState(System.DateTime.Now.Millisecond);
            whatToSpawn = Random.Range(1, bonuses.Count);
            Bonus bonus = bonuses[whatToSpawn];
            spawnPos = new Vector3(Random.Range(-X, X), 1, Random.Range(-Z, Z));
            bonus.Instantiate(spawnPos);
            Debug.Log("Instantiate new bonus with index " + whatToSpawn);
            
            // Set the next spawn time
            nextSpawn = Time.time + spawnRate;
        }
    }
}
