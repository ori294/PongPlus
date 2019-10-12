using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ePlayer
{
    Left,
    Right,
    Single
}

public enum PlayerMode
{
    Human,
    Computer
}

public class Player : MonoBehaviour
{
    public string playerName;
    public PlayerMode mode;
    public Color color;
    public string keyboardInputKey;


    // public ePlayer side; // temp - to remove, since this object is associated with a pedal
}
