using System;
using UnityEngine;

public class TerrainCollideScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collider other)
    {
        if (other.CompareTag("Player 1") || other.CompareTag("Player 2") || other.CompareTag("Player 3"))
        {
            Debug.Log("Collided");
        }
    }
}
