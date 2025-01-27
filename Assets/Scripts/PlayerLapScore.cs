using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PlayerLapScore : MonoBehaviour
{
    [SerializeField] WinnerHandlerScript whs;
    public int player1Lap = 1;
    public int player2Lap = 1;
    public int player3Lap = 1;

    public string winner = "";

    public GameObject player1Lap1, player1Lap2, player1Lap3, player2Lap1, player2Lap2, player2Lap3, player3Lap1, player3Lap2, player3Lap3, bubble;

    public GameObject player1Win, player2Win, player3Win;
    public GameObject player1Splash, player2Splash, player3Splash; // Splash screens for players

    public GameObject playAgain;

    private bool player1SplashShown = false;
    private bool player2SplashShown = false;
    private bool player3SplashShown = false;

    void Update()
    {
        UpdateLapIndicators();

        CheckForWinner();

        ShowSplashScreen();
    }

    private void UpdateLapIndicators()
    {
        // Update player 1 lap indicators
        player1Lap1.SetActive(player1Lap == 1);
        player1Lap2.SetActive(player1Lap == 2);
        player1Lap3.SetActive(player1Lap == 3);

        // Update player 2 lap indicators
        player2Lap1.SetActive(player2Lap == 1);
        player2Lap2.SetActive(player2Lap == 2);
        player2Lap3.SetActive(player2Lap == 3);

        // Update player 3 lap indicators
        player3Lap1.SetActive(player3Lap == 1);
        player3Lap2.SetActive(player3Lap == 2);
        player3Lap3.SetActive(player3Lap == 3);
    }

    private void CheckForWinner()
    {
        if (player1Lap > 3 && player2Lap <= 3 && player3Lap <= 3)
        {
            winner = "Player 1";
            BubblePop();
        }
        else if (player2Lap > 3 && player1Lap <= 3 && player3Lap <= 3)
        {
            winner = "Player 2";
            BubblePop();
        }
        else if (player3Lap > 3 && player1Lap <= 3 && player2Lap <= 3)
        {
            winner = "Player 3";
            BubblePop();
        }

        if (winner == "Player 1")
        {
            player1Win.SetActive(true);
            player2Win.SetActive(false);
            player3Win.SetActive(false);
            playAgain.SetActive(true);
        }
        else if (winner == "Player 2")
        {
            player2Win.SetActive(true);
            player1Win.SetActive(false);
            player3Win.SetActive(false);
            playAgain.SetActive(true);
        }
        else if (winner == "Player 3")
        {
            player3Win.SetActive(true);
            player2Win.SetActive(false);
            player1Win.SetActive(false);
            playAgain.SetActive(true);
        }


    }

    private void ShowSplashScreen()
    {
        if (player1Lap > 3 && !player1SplashShown)
        {
            ShowSplash(player1Splash);
            player1SplashShown = true;
        }

        if (player2Lap > 3 && !player2SplashShown)
        {
            ShowSplash(player2Splash);
            player2SplashShown = true;
        }

        if (player3Lap > 3 && !player3SplashShown)
        {
            ShowSplash(player3Splash);
            player3SplashShown = true;
        }
    }

    private void ShowSplash(GameObject splashScreen)
    {
        splashScreen.SetActive(true);
        splashScreen.transform.localScale = Vector3.zero;

        CanvasGroup canvasGroup = splashScreen.GetComponent<CanvasGroup>();
        if (!canvasGroup)
        {
            canvasGroup = splashScreen.AddComponent<CanvasGroup>();
        }

        canvasGroup.alpha = 0;

        // Animate the splash screen
        splashScreen.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutBack);
        canvasGroup.DOFade(1, 1f).OnComplete(() =>
        {
            StartCoroutine(HideSplashScreen(splashScreen, canvasGroup));
        });
    }

    private IEnumerator HideSplashScreen(GameObject splashScreen, CanvasGroup canvasGroup)
    {
        yield return new WaitForSeconds(3f);

        canvasGroup.DOFade(0, 1f);
        splashScreen.transform.DOScale(Vector3.zero, 1f).OnComplete(() =>
        {
            splashScreen.SetActive(false);
        });
    }

    private void BubblePop()
    {
        bubble.SetActive(false);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("CharacterSelectionScreen");
    }
}
