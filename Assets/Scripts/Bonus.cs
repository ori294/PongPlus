using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public AudioClip audio;

    public int points;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 3, 0, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ball")
        {
            AudioSource.PlayClipAtPoint(audio, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
//this.gameObject.transform.position
