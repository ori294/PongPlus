using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedalSound : MonoBehaviour
{
    public AudioSource sfx;
    
    // Start is called before the first frame update
    void Start()
    {
        sfx = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collider)
    {
        Ball ball = collider.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            sfx.Play();
        }
    }
}
