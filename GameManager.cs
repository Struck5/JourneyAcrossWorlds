using UnityEngine;
using System.Collections;

public class GameManager
{
    public static GameManager Instance { get { return null; } }

    public int Points { get; private set; }

    public void Reset ()
    {

    }

    public void AddPoints(int points)
    {

    }

    public void Start()
    {
        Screen.showCursor = true;
    }
}
