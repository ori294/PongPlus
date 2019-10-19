using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsSpin : MonoBehaviour
{
    public float xSpin = 0f;
    public float ySpin = 3f;
    public float zSpin = 0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xSpin,ySpin,zSpin);
    }
}
