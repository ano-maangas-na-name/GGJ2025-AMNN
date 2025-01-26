using UnityEngine;

public class spawnPlayer : MonoBehaviour
{
    [SerializeField] Transform spawnGum, spawnSoap, spawnSoda, player1, player2, player3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            player1.transform.position = spawnSoap.transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.RightShift))
        {
            player2.transform.position = spawnSoda.transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            player3.transform.position = spawnGum.transform.position;
        }
    }
}
