using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour, IPlayerBorderListener
{
    private GameObject[] playerBorderGOs;
    private Score leftScore;
    private Score rightScore;
    // Start is called before the first frame update
    void Start()
    {
        playerBorderGOs = GameObject.FindGameObjectsWithTag("PlayerBorder");

        foreach (GameObject playerBorderGO in playerBorderGOs)
        {
            PlayerBorder playerBorder = playerBorderGO.GetComponent<PlayerBorder>();
            playerBorder.listener = this;
        }
        
        leftScore = GameObject.FindGameObjectWithTag("LeftScore").GetComponent<Score>();
        rightScore = GameObject.FindGameObjectWithTag("RightScore").GetComponent<Score>();
    }

    public void OnPlayerBorderCollisionEnter(ePlayer player, Ball ball) {
        ball.transform.position = new Vector3(0f, 1f, 0f);

        Debug.Log("Player side is " + player);
        if (player == ePlayer.Left) {
            leftScore.score++;
        } else {
            rightScore.score++;
        }
    }
}
