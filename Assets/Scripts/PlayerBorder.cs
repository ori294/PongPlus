using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBorder : MonoBehaviour
{
    private AudioSource sfx;
    public Player player;
    public event Action<Player, Ball> OnBallCollision = delegate { };

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

            OnBallCollision(player, ball);
        }
    }
}
