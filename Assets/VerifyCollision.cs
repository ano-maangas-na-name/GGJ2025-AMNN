using UnityEngine;

public class VerifyCollision : MonoBehaviour
{
    [SerializeField] LapCollision lapCollision;

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
        if (other.CompareTag("Player 1"))
        {
            lapCollision.player1Verify = true;
        }

        if (other.CompareTag("Player 2"))
        {
            lapCollision.player2Verify = true;
        }
    }
}
