using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBehaviour : MonoBehaviour
{
    private float timeInGame;
    public float maxTime;

    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    void Start()
    {
        timeInGame = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timeInGame > maxTime) 
        {
            Destroy(gameObject);
        }
    }


}
