using System.Collections;
using UnityEngine;

public class WheelScript : MonoBehaviour
{
    [SerializeField] private bool wheelTurn;
    [SerializeField] private GameObject wheelObject;

    public WheelState wheelState;

    public enum WheelState
    {
        wheelStart,
        wheelEnd
    }
    void Start()
    {

    }

    void Update()
    {
        if (wheelState == WheelState.wheelStart)
        {
            wheelObject.transform.Rotate(0f, 0f, 1f);
        }
        else if (wheelState == WheelState.wheelEnd)
        {
            // wheelObject.transform.Rotate(0f, 0f, Mathf.Lerp(5f, 0f, 5 * Time.deltaTime));
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            wheelState = WheelState.wheelStart;
            // wheelTurn = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            wheelState = WheelState.wheelEnd;
        }

        // {
        //     wheelTurn = false;
        // }
    }
}
