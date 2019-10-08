using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PedalMovement : MonoBehaviour
{
    public float speed = 15f;
    // public ePlayer side;
    public string keyboardInputKey;


    // Update is called once per frame
    void Update()
    {
        if (keyboardInputKey != null)
        {
            float direction = Input.GetAxisRaw(keyboardInputKey);
            transform.position += new Vector3(0f, 0f, direction * speed * Time.deltaTime);
        }
        else
        {
            Debug.LogError("keyboardInputKey = " + keyboardInputKey);
        }
        // todo: update material color according to color
    }
}
