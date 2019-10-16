using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    private float fill;
    
    public Image bar;
    public Player player;

    void Start()
    {
        fill = 1f;

        player.GetComponent<Health>().OnHealthPctChanged += HandleHealthPctChanged;
    }

    void LateUpdate()
    {
        bar.fillAmount = fill;
    }

    private void HandleHealthPctChanged(Player p, float pct)
    {
        Debug.Log("Update bar " + bar.ToString() + "with value " + pct.ToString());
        fill = pct;
    }

    public float getFill() => fill;
}
