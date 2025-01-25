using System.Collections;
using UnityEngine;

public class PlayerLapScore : MonoBehaviour
{
    WinnerHandlerScript whs;
    public int player1Lap = 1;
    public int player2Lap = 1;
    public int player3Lap = 1;

    public string winner = "";

    public GameObject player1Lap1, player1Lap2, player1Lap3, player2Lap1, player2Lap2, player2Lap3, player3Lap1, player3Lap2, player3Lap3, bubble;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player1Lap == 1)
        {
            player1Lap1.SetActive(true);
            player1Lap2.SetActive(false);
            player1Lap3.SetActive(false);
        }
        else if (player1Lap == 2)
        {
            player1Lap1.SetActive(false);
            player1Lap2.SetActive(true);
            player1Lap3.SetActive(false);
        }
        else if (player1Lap == 3)
        {
            player1Lap1.SetActive(false);
            player1Lap2.SetActive(false);
            player1Lap3.SetActive(true);
        }

        if (player2Lap == 1)
        {
            player2Lap1.SetActive(true);
            player2Lap2.SetActive(false);
            player2Lap3.SetActive(false);
        }
        else if (player2Lap == 2)
        {
            player2Lap1.SetActive(false);
            player2Lap2.SetActive(true);
            player2Lap3.SetActive(false);
        }
        else if (player2Lap == 3)
        {
            player2Lap1.SetActive(false);
            player2Lap2.SetActive(false);
            player2Lap3.SetActive(true);
        }

        if (player3Lap == 1)
        {
            player3Lap1.SetActive(true);
            player3Lap1.SetActive(false);
            player3Lap1.SetActive(false);
        }
        else if (player3Lap == 2)
        {
            player3Lap1.SetActive(false);
            player3Lap1.SetActive(true);
            player3Lap1.SetActive(false);
        }
        else if (player3Lap == 3)
        {
            player3Lap1.SetActive(false);
            player3Lap1.SetActive(false);
            player3Lap1.SetActive(true);
        }

        if (player1Lap > 3 && player2Lap <= 3 && player3Lap <= 3)
        {
            winner = "Player 1";
            whs.winner = WinnerHandlerScript.Winner.Player_1;
            BubblePop();
        }
        else if (player2Lap > 3 && player1Lap <= 3 && player3Lap <= 3)
        {
            winner = "Player 2";
            whs.winner = WinnerHandlerScript.Winner.Player_2;
            BubblePop();
        }
        else if (player3Lap > 3 && player1Lap <= 3 && player2Lap <= 3)
        {
            winner = "Player 3";
            whs.winner = WinnerHandlerScript.Winner.Player_3;
            BubblePop();
        }
    }

    private void BubblePop()
    {
        bubble.SetActive(false);
        StartCoroutine(WinnerTransition());
    }

    IEnumerator WinnerTransition()
    {
        yield return new WaitForSeconds(2f);

    }


}



