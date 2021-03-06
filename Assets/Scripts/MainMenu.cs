﻿using System.Collections;
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

    public void GetControls() {
        Debug.Log("Going to Controls");
        SceneManager.LoadScene("Controls");
    }

    public void VoiceGame() {
        Debug.Log("Going to VoiceControlledGame");
        SceneManager.LoadScene("VoiceControlGame");
    }

    public void ExitGame() {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
