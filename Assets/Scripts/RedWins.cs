using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedWins : MonoBehaviour
{
   public void GoBack() {
        Debug.Log("Going back to MainMenu");
        SceneManager.LoadScene("MainMenu");
    }
}
