using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BonusType
{
    PointsBonus,
    FireBonus,
    ReverseBonus,
}

public class Bonus : MonoBehaviour
{
    public AudioClip audioClip;

    public int points = -5;
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
            Vector3 pos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(audioClip, pos);

            OnBonusTriggered(other.gameObject);

            Destroy(gameObject);
        }
    }

    public virtual void OnBonusTriggered(GameObject trigger)
    {
        Ball ball = trigger.GetComponent<Ball>();
        Player player = ball.hitter;
        if (player)
        {
            player.GetComponent<Health>().ModifyHealth(points);
        }
    }

    public virtual void Instantiate(Vector3 position)
    {
        Instantiate(this, position, Quaternion.identity);
    }
}
