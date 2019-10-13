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

            OnBonusTriggered(other.gameObject);

            Destroy(gameObject);
        }
    }

    public virtual void OnBonusTriggered(GameObject trigger)
    {
        Game game = GameObject.FindGameObjectWithTag("Game").GetComponent<Game>();
        Ball ball = trigger.GetComponent<Ball>();
        game.IncrementScore(ball.hitter, points);
    }

    public virtual void Instantiate(Vector3 position)
    {
        Instantiate(this, position, Quaternion.identity);
    }
}
