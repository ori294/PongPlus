using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BonusType
{
    PointsBonus,
    FireBonus,
}

public class Bonus : MonoBehaviour
{
    public AudioClip audioClip;

    public int points = 1;
    public BonusType type;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 3, 0, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ball")
        {
            AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
//this.gameObject.transform.position
