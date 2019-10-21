using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VoiceControlledGame : MonoBehaviour
{
    public static int maxScore = 10;
    public int numPlayers = 2;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Creating game...");
        // create players
        numPlayers = Math.Max(1, numPlayers);
        Time.timeScale = 0.6f;

        // assign players to paddles and borders
        GameObject[] playerGameObjects = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < playerGameObjects.Length; i++)
        {
            GameObject playerGameObject = GameObject.Find("Player" + i);

            Player player = playerGameObject.GetComponent<Player>();
            player.GetComponent<Health>().OnHealthPctChanged += HandleHealthPctChanged;

            GameObject[] paddleGameObjects = GameObject.FindGameObjectsWithTag("Paddle");
            GameObject paddleGameObject = Array.Find(paddleGameObjects, pgo => pgo.GetComponent<Paddle>().player.playerName == player.playerName);

            if (i < numPlayers)
            {
                player.mode = PlayerMode.Human;
                //paddleGameObject.AddComponent<PaddleMovement>();
                //paddleGameObject.AddComponent<PedalMovementSound>();
                //PaddleMovement paddleMovement = paddleGameObject.GetComponent<PaddleMovement>();
                // paddleMovement.keyboardInputKey = player.keyboardInputKey;
                Debug.Log("Assign human player #" + i.ToString());
            }
            else
            {
                player.mode = PlayerMode.Computer;
                paddleGameObject.AddComponent<PaddleMovementComputer>();
                Debug.Log("Assign computer player #" + i.ToString());
            }
        }
    }

    public void HandleHealthPctChanged(Player player, float pct)
    {
        GameObject[] playerGameObjects = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] activePlayers = Array.FindAll(playerGameObjects, pgo => pgo.GetComponent<Health>().currentHealth > 0);
        Player winner = activePlayers.Length == 1 ? activePlayers[0].GetComponent<Player>() : null;
        if (winner != null)
        {
            EndGame(winner);
        }
    }

    public static void EndGame(Player player)
    {
        if (player.playerName == "Red") {
            SceneManager.LoadScene("RedWins");
        } 
        else if (player.playerName == "Blue")
        {
            SceneManager.LoadScene("BlueWins");
        }
        else 
        {
            Debug.LogError("Winner not detected!");
        }
    }
}
