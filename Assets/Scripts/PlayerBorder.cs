using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBorder : MonoBehaviour
{
    public List<IPlayerBorderListener> listener = new List<IPlayerBorderListener>();
    // public ePlayer player;
    // public ScoreUI score;
    public Player player;

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
            foreach (IPlayerBorderListener lstnr in listener)
            {
                lstnr.OnPlayerBorderCollisionEnter(this, ball);
            }
        }
    }
}

public interface IPlayerBorderListener
{
    void OnPlayerBorderCollisionEnter(PlayerBorder border, Ball ball);
}
