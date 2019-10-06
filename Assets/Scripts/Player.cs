using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ePlayer
{
    Left,
    Right,
    Single
}

public class Player : MonoBehaviour
{
    public string playerName;
    public AudioSource sfx;
    public float speed = 15f;
    public ePlayer side;

    // Start is called before the first frame update
    void Start()
    {
        sfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputSpeed = 0f;
        if (side == ePlayer.Left)
        {
            inputSpeed = Input.GetAxisRaw("PlayerLeft");
        }
        else if (side == ePlayer.Right)
        {
            inputSpeed = Input.GetAxisRaw("PlayerRight");
        } 
        else if (side == ePlayer.Single) 
        {
            inputSpeed = (-1)*Input.GetAxisRaw("Horizontal");
        }

        transform.position += new Vector3(0f, 0f, inputSpeed * speed * Time.deltaTime);
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
