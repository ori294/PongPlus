using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int maxHealth = 100;
    public int currentHealth { get; private set; }
    public event Action<Player, float> OnHealthPctChanged = delegate {};
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void ModifyHealth(int amount)
    {
        Player player = gameObject.GetComponent<Player>();
        currentHealth += amount;
        currentHealth = Math.Max(0, Math.Min(currentHealth, maxHealth));

        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(player, currentHealthPct);

        Debug.Log("Player " + player.playerName + ": " + currentHealth.ToString() + "/" + maxHealth.ToString() + "(" + amount.ToString() + ")");
    }
}
