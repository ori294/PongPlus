using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovementComputer : MonoBehaviour
{
    public float speed = 0.15f; // the lesser the easier the CPU.
    private Vector3 offSet;
    private Ball ball;
    private Vector3 origin;
    private Vector3 previousPosition;
    private bool didCollide;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>();
        origin = transform.position;
        offSet = ball.transform.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float CTS = Time.timeScale; //CTS - Current Time Scale
        Vector3 target = new Vector3(origin.x, origin.y, ball.transform.position.z );

        float currentSpeed = speed * (float)Math.Pow(1 - Math.Abs(ball.transform.position.x - transform.position.x) / Math.Abs(2 * transform.position.x), 2); // speed grows as the ball is closer to the paddle

        bool goingOppositeDirection = (transform.position - previousPosition).z >= 0 && (target - transform.position).z <= 0
            || (transform.position - previousPosition).z <= 0 && (target - transform.position).z >= 0; // check if the sign of vector z has changed since last Update

        if (!didCollide || goingOppositeDirection) // has not hit the wall or going in opposite direction
        {
            transform.position = Vector3.MoveTowards(transform.position, target, currentSpeed * CTS);
            previousPosition = transform.position;
            didCollide = false;
        }
    }

    void OnCollisionEnter(Collision collider)
    {
        didCollide = (collider.gameObject.tag == "Wall");
    }
}
