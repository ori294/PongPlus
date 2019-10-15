using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    public Player player;

    void ReduceHp(int howMany)
    {
        if (player.playerName == "Blue")
        {
            howMany *= -1;
        }
        transform.localScale += new Vector3(0.1f * howMany, 0, 0);
    }
}
