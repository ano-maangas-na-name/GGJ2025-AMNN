using System.Collections;
using UnityEngine;

public class PowerUp1 : MonoBehaviour
{
    Player2Controller Player2Controller;

    private void Start()
    {
        Player2Controller = GetComponent<Player2Controller>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpeedIncrease"))
        {
            Player2Controller.speedIncrease = true;
            Debug.Log("Speed Boost true");
            StartCoroutine(PowerUpDelay());
        }
    }

    IEnumerator PowerUpDelay()
    {
        yield return new WaitForSeconds(2.5f);
        Player2Controller.speedIncrease = false;
        Debug.Log("Speed Boost False");
    }
}