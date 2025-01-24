using Unity.VisualScripting;
using UnityEngine;

public class RandomizerScript
{
    [SerializeField] private bool wheelTurn;
    [SerializeField] private GameObject wheelObject;
    void Start()
    {

    }

    void Update()
    {
        if (wheelTurn)
        {
            wheelObject.transform.Rotate(0f, 0f, +1f);
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            wheelTurn = true;
        }
        else
        {
            wheelTurn = false;
        }
    }
}
