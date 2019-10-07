using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedalMovement : MonoBehaviour
{
    public float speed = 15f;
    public ePlayer side;


    // Update is called once per frame
    void Update()
    {
        float direction = 0f;
        if (side == ePlayer.Left)
        {
            direction = Input.GetAxisRaw("PlayerLeft");
        }
        else if (side == ePlayer.Right)
        {
            direction = Input.GetAxisRaw("PlayerRight");
        }
        else if (side == ePlayer.Single)
        {
            direction = (-1) * Input.GetAxisRaw("Horizontal");
        }

        transform.position += new Vector3(0f, 0f, direction * speed * Time.deltaTime);

        // todo: update material color according to color
    }
}
