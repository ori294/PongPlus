using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUAI : MonoBehaviour
{
    public Ball ball;
    public float moveSpeed;
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
        moveSpeed = 0.25f; //the lesser the easier the CPU.
        offSet = ball.transform.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 vect = new Vector3(x, y, ball.transform.position.z - offSet.z);

        if (vect.z <= rightBoundry.position.z - 2.2 && vect.z >= leftBoundry.position.z + 2.2)
        {
            transform.position = Vector3.MoveTowards(transform.position, vect, moveSpeed);
        }
    }
}
