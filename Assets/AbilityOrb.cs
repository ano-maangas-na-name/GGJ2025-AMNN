using System.Xml.Serialization;
using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;

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
            player2Controller.slowed = true;
            player3Controller.slowed = true;
        }

        if (other.CompareTag("Player 3"))
        {
            Debug.Log("Bubblegum Ability");
            carController.stunned = true;
            player2Controller.stunned = true;
        }

        if (other.CompareTag("Player 2"))
        {
            Debug.Log("Coke Ability");
            player2Controller.ability = true;
            StartCoroutine(abilityFalse());
        }

        IEnumerator abilityFalse()
        {
            yield return new WaitForSeconds(6f);
            player2Controller.ability = false;
            Debug.Log("Speed Boost False");
        }


    }
}