using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusFire : Bonus
{
    void Start()
    {
        points = 2;
    }
    public override void OnBonusTriggered(GameObject trigger)
    {
        Ball ball = trigger.GetComponent<Ball>();
        ball.points = points;
        ball.SetInFlames();
    }

    public override void Instantiate(Vector3 position)
    {
        Instantiate(this, position, Quaternion.identity);
    }
}
