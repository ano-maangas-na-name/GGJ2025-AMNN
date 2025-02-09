using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    CarController CarController;

    private void Start()
    {
        CarController = GetComponent<CarController>();
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