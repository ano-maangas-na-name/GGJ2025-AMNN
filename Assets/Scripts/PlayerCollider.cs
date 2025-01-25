using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public LapScript lapScript;

    public bool hasCrossed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("lap") && !hasCrossed)
        {
            lapScript.increaseLap();
            hasCrossed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        hasCrossed = false;
    }
}
