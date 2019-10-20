using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    public Vector3 pointA = new Vector3(0, 0, 0);
    public Vector3 pointB = new Vector3(0, 0, 0);
    public float len = 10f;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(pointA, pointB, Mathf.PingPong(Time.time / 2, len));

        if (Time.time % (2 * len) == 0) 
        {
            len = Random.Range(2f, 10f);
        }
    }
}
