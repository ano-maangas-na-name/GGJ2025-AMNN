using UnityEngine;
using System.Collections;
using DG.Tweening; // Import DoTween namespace

public class RaceCountdown : MonoBehaviour
{
    public int countDownStartNumber; // Starting number for the countdown
    private int countDownCount;     // Current countdown number
    public GameObject[] countDownSprites; // Array of sprites representing countdown numbers
    public float fadeDuration = 0.5f; // Duration for fade-in/out animation
    public float scaleDuration = 0.5f; // Duration for scale animation
    public float holdDuration = 0.5f; // Duration to hold the sprite before fading out
    public float initialDelay = 2f;  // Delay before starting the countdown

    [SerializeField] Rigidbody player1, player2, player3;

    // [SerializeField] private RaceManagerScript rms;

    public void Start()
    {
        StartCountDown();
        player1.isKinematic = true;
        player2.isKinematic = true;
        player3.isKinematic = true;
    }

    public void StartCountDown()
    {
        StartCoroutine(InitialDelayCoroutine());
    }

    private IEnumerator InitialDelayCoroutine()
    {
        // Wait for the initial delay
        yield return new WaitForSeconds(initialDelay);

        // Initialize countdown number and start the countdown coroutine
        countDownCount = countDownStartNumber;
        StartCoroutine(CountDownCoroutine());
    }

    private IEnumerator CountDownCoroutine()
    {
        for (int i = countDownStartNumber; i > 0; i--)
        {
            yield return ShowCountDownSprite(i - 1); // Show the sprite with animation
        }

        if (player1 != null)
        {
            player1.isKinematic = false;

        }
        if (player2 != null)
        {
            player2.isKinematic = false;
        }
        if (player3 != null)
        {
            player3.isKinematic = false;

        }
        // rms.gameState = RaceManagerScript.GameState.MidGame;
        Debug.Log("Countdown Finished");

        // Hide all sprites after countdown
        HideAllSprites();

        // Optionally trigger the start of the race here
    }

    private IEnumerator ShowCountDownSprite(int index)
    {
        HideAllSprites(); // Ensure all sprites are hidden before showing the new one

        if (index >= 0 && index < countDownSprites.Length)
        {
            GameObject sprite = countDownSprites[index];
            sprite.SetActive(true);

            // Reset scale and fade
            sprite.transform.localScale = Vector3.zero;
            CanvasGroup canvasGroup = sprite.GetComponent<CanvasGroup>();
            if (!canvasGroup)
            {
                canvasGroup = sprite.AddComponent<CanvasGroup>(); // Add CanvasGroup if not already present
            }
            canvasGroup.alpha = 0; // Start fully transparent

            // Animate scale and fade-in
            sprite.transform.DOScale(Vector3.one, scaleDuration).SetEase(Ease.OutBack);
            canvasGroup.DOFade(1, fadeDuration);

            // Wait for the hold duration
            yield return new WaitForSeconds(scaleDuration + holdDuration);

            // Animate fade-out and scale-down
            sprite.transform.DOScale(Vector3.zero, scaleDuration).SetEase(Ease.InBack);
            canvasGroup.DOFade(0, fadeDuration);

            // Wait for fade-out to complete
            yield return new WaitForSeconds(fadeDuration);
        }
    }


    private void HideAllSprites()
    {
        foreach (GameObject sprite in countDownSprites)
        {
            sprite.SetActive(false); // Deactivate sprite after fade-out
        }
    }
}
