using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBorder : MonoBehaviour
{
    public ePlayer player;
    public ScoreUI score;
    public AudioSource sfx;
    
    // Start is called before the first frame update
    void Start()
    {
        sfx = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        Ball ball = other.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            ball.transform.position = new Vector3(0f, 1f, 0f);

            if (player == ePlayer.Right) score.scorePlayerRed++;
            else if (player == ePlayer.Left) score.scorePlayerBlue++;
            sfx.Play();
        }
    }
}
