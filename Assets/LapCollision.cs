using UnityEngine;

public class LapCollision : MonoBehaviour
{
    [SerializeField] private PlayerLapScore playerLap;
    public bool player1Verify;
    public bool player2Verify;
    public bool player3Verify;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player 1") && player1Verify)
        {
            if (playerLap.player1Lap < 3)
            {
                playerLap.player1Lap++;
                player1Verify = false;
            }

        }

        else if (other.CompareTag("Player 2") && player2Verify)
        {
            if (playerLap.player2Lap < 3)
            {
                playerLap.player2Lap++;
                player2Verify = false;
            }

        }

        else if (other.CompareTag("Player 3") && player3Verify)
        {
            if (playerLap.player3Lap < 3)
            {
                playerLap.player3Lap++;
                player3Verify = false;
            }

        }
    }



}
