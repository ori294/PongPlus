using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    private float pointsPerHit;
    private float fill;
    public Image bar;

    void Start()
    {
        fill = 1f;
        pointsPerHit = 1 / Game.maxScore;
    }

    public void ReduceHP(int howMuch) 
    {
        fill = fill - 0.1f * howMuch;
    }

    void LateUpdate()
    {
        bar.fillAmount = fill;
    }

    public float getFill() => fill;
}
