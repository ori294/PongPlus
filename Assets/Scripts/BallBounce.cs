using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 newVec;
    private float padelLength, dis, newAngle, velX, velZ;
    public float currentSpeed;

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Paddle")
        {
            // gets the padle length.
            padelLength = other.collider.GetComponent<Renderer>().bounds.size.z;

            // gets the partial distance betweem the ball and the middle of the player. 
            dis = (transform.position.z - other.transform.position.z) / padelLength;
            
            // the new angle in Rads.
            newAngle = (dis * 100 + 90) * Mathf.Deg2Rad;

            // calculating the new vector
            velZ = Mathf.Cos(newAngle);
            velX = Mathf.Sin(newAngle);
            if (other.collider.name == "Paddle - Blue")
            {
                newVec = new Vector3(velX, 0, -velZ);
            }
            else if (other.collider.name == "Paddle - Red")
            {
                newVec = new Vector3(-velX, 0, -velZ);    
            }
            currentSpeed = GetComponent<Ball>().speed;
            rb.velocity = Vector3.Normalize(newVec) * currentSpeed;   
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.collider.tag == "Paddle")
        {
        currentSpeed = GetComponent<Ball>().speed;
        rb.velocity = Vector3.Normalize(newVec) * currentSpeed;    
        }
        else
        {
            Vector3 currentVel = rb.velocity;
            currentSpeed = GetComponent<Ball>().speed;
            rb.velocity = Vector3.Normalize(currentVel) * currentSpeed;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = rb.velocity.magnitude;
    }
}
