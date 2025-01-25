using System.Xml.Serialization;
using UnityEngine;

public class AbilityOrb : MonoBehaviour
{
    [SerializeField] private GameObject soap;
    [SerializeField] private GameObject coke;
    [SerializeField] private GameObject bubblegum;

    [SerializeField] CarController carController;
    [SerializeField] Player2Controller player2Controller;
    [SerializeField] Player3Controller player3Controller;

    private void Awake()
    {
        soap = GameObject.FindGameObjectWithTag("Player 1");
        coke = GameObject.FindGameObjectWithTag("Player 2");
        bubblegum = GameObject.FindGameObjectWithTag("Player 3");
    }
    private void Start()
    {
        carController = soap.GetComponent<CarController>();
        player2Controller = coke.GetComponent<Player2Controller>();
        player3Controller = bubblegum.GetComponent<Player3Controller>();
 

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player 1"))
        {
            Debug.Log("Soap Ability");

            
        }

        if (other.CompareTag("Player 3"))
        {
            Debug.Log("Bubblegum Ability");

        }

        if (other.CompareTag("Player 2"))
        {
            Debug.Log("Coke Ability");

        }
    }
}