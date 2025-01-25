using System.Collections;
using UnityEngine;

public class PowerUp2 : MonoBehaviour
{
    Player3Controller Player3Controller;

    private void Start()
    {
        Player3Controller = GetComponent<Player3Controller>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpeedIncrease"))
        {
            Player3Controller.speedIncrease = true;
            Debug.Log("Speed Boost true");
            StartCoroutine(PowerUpDelay());
        }
    }

    IEnumerator PowerUpDelay()
    {
        yield return new WaitForSeconds(2.5f);
        Player3Controller.speedIncrease = false;
        Debug.Log("Speed Boost False");
    }
}