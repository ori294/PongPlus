using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedal : MonoBehaviour
{
    public Player player;
    public bool temp = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collider)
    {
        Ball ball = collider.gameObject.GetComponent<Ball>();

        if (temp && ball != null && player.playerName == "Red")
        {
            ball.ApplyBonus(null);
            temp= false;
        }
    }
}
