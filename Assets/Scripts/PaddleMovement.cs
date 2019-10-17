using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PaddleMovement : MonoBehaviour
{
    public float speed = 15f;
    // public ePlayer side;
    private string keyboardInputKey;
    public bool isAxisReversed;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        Paddle paddle = gameObject.GetComponent<Paddle>();
        keyboardInputKey = paddle.player.keyboardInputKey;
        isAxisReversed = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (keyboardInputKey != null)
        {
            if (isAxisReversed) {
                float direction = -Input.GetAxisRaw(keyboardInputKey);
                transform.position += new Vector3(0f, 0f, direction * speed * Time.deltaTime);
            } 
            else 
            {
                float direction = Input.GetAxisRaw(keyboardInputKey);
                transform.position += new Vector3(0f, 0f, direction * speed * Time.deltaTime);
            }
            
        }
        else
        {
            Debug.LogError("keyboardInputKey = " + keyboardInputKey);
        }
        // todo: update material color according to color
    }
}
