using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 initialImpulse = new Vector3(5, 0, 0);
    //public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        //rb.AddForce(initialImpulse, ForceMode.Impulse);
        GetComponent<Rigidbody>().AddForce(initialImpulse, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
