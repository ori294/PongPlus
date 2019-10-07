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
    human,
    computer
}

public class Player : MonoBehaviour
{
    public string playerName;
    public ePlayer side;
    public PlayerMode mode;
    public Color color;
}
