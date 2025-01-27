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
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            player1.transform.position = spawnSoap.transform.position;
            player1.transform.localEulerAngles = spawnSoap.transform.localEulerAngles;
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            player2.transform.position = spawnSoda.transform.position;
            player2.transform.localEulerAngles = spawnSoda.transform.localEulerAngles;

        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            player3.transform.position = spawnGum.transform.position;
            player3.transform.localEulerAngles = spawnGum.transform.localEulerAngles;

        }
    }
}
