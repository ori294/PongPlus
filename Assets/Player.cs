using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ePlayer
{
    Left,
    Right
}

public class Player : MonoBehaviour
{
    public AudioSource sfx;
    public float speed = 15f;
    public ePlayer player;

        // Start is called before the first frame update
    void Start()
    {
        sfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputSpeed = 0f;
        if (player == ePlayer.Left)
        {
            inputSpeed = Input.GetAxisRaw("PlayerLeft");
        }
        else if (player == ePlayer.Right)
        {
            inputSpeed = Input.GetAxisRaw("PlayerRight");
        }

        transform.position += new Vector3(0f, 0f, inputSpeed * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other)
    {
        Ball ball = other.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            sfx.Play();
        }
    }
}
