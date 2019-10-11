using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour, IPlayerBorderListener
{
    public int maxScore = 7;
    public int numPlayers = 2;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Creating game...");
        // create players
        numPlayers = Math.Max(1, numPlayers);

        // assign players to pedals and borders
        GameObject[] playerGameObjects = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < playerGameObjects.Length; i++)
        {
            GameObject playerGameObject = GameObject.Find("Player" + i);

            Player player = playerGameObject.GetComponent<Player>();
            player.playerName = player.playerName != null ? player.playerName : "Player" + i;

            GameObject[] pedalGameObjects = GameObject.FindGameObjectsWithTag("Pedal");
            GameObject pedalGameObject = Array.Find(pedalGameObjects, pgo => pgo.GetComponent<Pedal>().player.playerName == player.playerName);

            if (i < numPlayers)
            {
                player.mode = PlayerMode.Human;
                pedalGameObject.AddComponent<PedalMovement>();
                PedalMovement pedalMovement = pedalGameObject.GetComponent<PedalMovement>();
                // pedalMovement.keyboardInputKey = player.keyboardInputKey;
                Debug.Log("Assign human player #" + i.ToString());
            }
            else
            {
                player.mode = PlayerMode.Computer;
                pedalGameObject.AddComponent<PedalMovementComputer>();
                Debug.Log("Assign computer player #" + i.ToString());
            }
        }
        // get scoreboards for all players


        GameObject[] playerBorderGOs = GameObject.FindGameObjectsWithTag("PlayerBorder");
        foreach (GameObject playerBorderGO in playerBorderGOs)
        {
            PlayerBorder playerBorder = playerBorderGO.GetComponent<PlayerBorder>();
            Debug.Log(playerBorder.listener);
            playerBorder.listener.Add(this); // can cause memory leak should be replaced with wek reference to this object
        }
    }

    public void OnPlayerBorderCollisionEnter(PlayerBorder border, Ball ball)
    {
        ball.transform.position = new Vector3(0f, 1f, 0f);

        UpdateScore(ball.hitter, ball.points);
    }

    void UpdateScore(Player player, int points)
    {
        Debug.Log("Player " + player.playerName + " scored " + points.ToString() + " points!");
        GameObject[] scoresGO = GameObject.FindGameObjectsWithTag("Score");
        
        if (scoresGO == null || scoresGO.Length == 0) {
            Debug.LogError("Score GameObject is missing...");
            return;
        }

        GameObject scoreGO = Array.Find(scoresGO, sgo => sgo.GetComponent<Score>() && sgo.GetComponent<Score>().player.playerName == player.playerName);
        Score score = scoreGO.GetComponent<Score>();
        score.score += points;

        if (score.score == maxScore)
        {
            EndGame(player);
        }
    }

    void ApplyBonus(Bonus bonus, IBonusable component)
    {
        component.ApplyBonus(bonus);
    }

    void EndGame(Player player)
    {
        // todo!!!!
    }
}
