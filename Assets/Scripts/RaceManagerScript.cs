using System.Threading;
using UnityEngine;

public class RaceManagerScript : MonoBehaviour
{
    public GameState gameState;
    public float countDown = 3;

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

    }

}

