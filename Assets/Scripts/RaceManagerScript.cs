using System.Collections;
using System.Threading;
using TMPro;
using UnityEngine;

public class RaceManagerScript : MonoBehaviour
{
    public GameState gameState;

    public GameObject lapCounter1, lapCounter2, lapCounter3;
    public LapScript lapScript;
    public enum GameState
    {
        PreGame,
        MidGame,
        PostGame
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameState = GameState.PreGame;
    }

    // Update is called once per frame
    void Update()
    {
        if (lapScript.lapCounter == 1)
        {
            lapCounter1.SetActive(true);
            lapCounter2.SetActive(false);
            lapCounter3.SetActive(false);
        }
        else if (lapScript.lapCounter == 2)
        {
            lapCounter1.SetActive(false);
            lapCounter2.SetActive(true);
            lapCounter3.SetActive(false);
        }
        else if (lapScript.lapCounter == 3)
        {
            lapCounter1.SetActive(false);
            lapCounter2.SetActive(false);
            lapCounter3.SetActive(true);
        }
    }

}

