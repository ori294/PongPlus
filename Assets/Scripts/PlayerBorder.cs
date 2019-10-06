using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBorder : MonoBehaviour
{
    public IPlayerBorderListener listener;
    // public ePlayer player;
    // public ScoreUI score;
    public ePlayer player;
    
    public AudioSource sfx;
    
    // Start is called before the first frame update
    void Start()
    {
        sfx = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collider)
    {
        Ball ball = collider.gameObject.GetComponent<Ball>();

        if (ball != null) {
            sfx.Play();
            listener.OnPlayerBorderCollisionEnter(player, ball);
            
            //ball.transform.position = new Vector3(0f, 1f, 0f);

            // if (player == ePlayer.Right) score.scorePlayerRed++;
            // else if (player == ePlayer.Left) score.scorePlayerBlue++;
            
        }
    }
}

public interface IPlayerBorderListener {
    void OnPlayerBorderCollisionEnter(ePlayer player, Ball ball);
}
