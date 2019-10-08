using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Player player;
    public int score;
    public Text scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        // scoreText.color = player.color;
    }
    void Update()
    {
        scoreText.text = score.ToString();
    }
}
