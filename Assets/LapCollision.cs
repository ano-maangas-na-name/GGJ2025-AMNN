using UnityEngine;

public class LapCollision : MonoBehaviour
{
    [SerializeField] private PlayerLapScore playerLap;
    public bool player1Verify;
    public bool player2Verify;
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
            playerLap.player1Lap++;
            player1Verify = false;
        }

        else if (other.CompareTag("Player 2") && player2Verify)
        {
            playerLap.player2Lap++;
            player2Verify = false;
        }
    }



}
