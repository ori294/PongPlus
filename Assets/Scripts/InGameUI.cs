using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour
{
    public static bool GameIsPaused = false;
    private static float defaultTimeScale;
    public GameObject pauseMenuUI;
    public GameObject scoreUI;

    // Start is called before the first frame update
    void Start()
    {
        defaultTimeScale = Time.timeScale;
    }
    //Pausing the game
    public void Pause() 
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    //Resuming the game
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = defaultTimeScale;
        GameIsPaused = false;
    }
    //Restarting the game will re-load the scene
    public void RestartGame() 
    {
        Time.timeScale = defaultTimeScale;
        GameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    //Start Main Menu scene (And close playing scene)
    public void BackToMenu() 
    {
        Time.timeScale = defaultTimeScale;
        GameIsPaused = false;
        SceneManager.LoadScene("MainMenu");
    }
}
