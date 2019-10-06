using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void StartSinglePlayer() {
        SceneManager.LoadScene("SinglePlayer");
    }
    
    public void StartMultiPlayer() {
        Debug.Log("Starting Game");
        SceneManager.LoadScene("MultiPLayer");
    }

    public void GetHighScores() {
        Debug.Log("Going to HighScores");
        SceneManager.LoadScene("HighScores");
    }

    public void ExitGame() {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
