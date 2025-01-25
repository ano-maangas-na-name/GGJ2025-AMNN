using System.Collections;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    CarController CarController;
    Player2Controller Player2Controller;
    Player3Controller Player3Controller;

    private void Start()
    {
        CarController = GetComponent<CarController>();
        Player2Controller = GetComponent<Player2Controller>();
        Player3Controller = GetComponent<Player3Controller>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpeedIncrease"))
        {
            CarController.speedIncrease = true;
            Debug.Log("Speed Boost true");
            StartCoroutine(PowerUpDelay());
        }
    }

    IEnumerator PowerUpDelay()
    {
        yield return new WaitForSeconds(2.5f);
        CarController.speedIncrease = false;
        Debug.Log("Speed Boost False");
    }
}