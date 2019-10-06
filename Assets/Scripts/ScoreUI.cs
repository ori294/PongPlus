using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public int scorePlayerRed;
    public int scorePlayerBlue;
    public GUIStyle style;

    void OnGUI()
    {
        float x = Screen.width / 2f;
        float y = 30f;
        float width = 300f;
        float height = 20f;
        string text = scorePlayerRed + " / " + scorePlayerBlue;

        GUI.Label(new Rect(x-(width/2f), y, width, height), text, style);
    }
}
