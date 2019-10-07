using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedalMovementComputer : MonoBehaviour
{
    public Ball ball;
    public float speed;
    public Vector3 offSet;
    public Transform leftBoundry;
    public Transform rightBoundry;
    float x;
    float y;

    // Start is called before the first frame update
    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
        speed = 0.25f; //the lesser the easier the CPU.
        offSet = ball.transform.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 vect = new Vector3(x, y, ball.transform.position.z - offSet.z);

        Debug.LogError("Ball position: " + ball.transform.position.z.ToString());
        Debug.LogError("vect position z = " + vect.z.ToString());
        Debug.LogError("Right boundry position z = " + rightBoundry.position.z.ToString());
        Debug.LogError("Left boundry position z = " + leftBoundry.position.z.ToString());
        if ((vect.z <= rightBoundry.position.z - 2.2) && (vect.z >= leftBoundry.position.z + 2.2))
        {
            Debug.LogError("Move pedal computer");
            transform.position = Vector3.MoveTowards(transform.position, vect, speed);
        }
    }
}
