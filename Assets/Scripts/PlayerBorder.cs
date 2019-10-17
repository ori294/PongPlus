using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBorder : MonoBehaviour
{
    private AudioSource sfx;
    public Player player;

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

            player.GetComponent<Health>().ModifyHealth(ball.points);
        }
    }
}
