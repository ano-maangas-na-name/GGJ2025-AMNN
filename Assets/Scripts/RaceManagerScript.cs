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

        RaceStart();
    }
    private void RaceStart()
    {
        if (countDown > 0)
        {
            countDown -= 1 * Time.deltaTime;
        }
        else
        {
            gameState = GameState.MidGame;
        }
    }
}

