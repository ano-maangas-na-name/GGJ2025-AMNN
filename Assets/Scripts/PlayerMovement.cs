using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(1f * 10f, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(0, 0, 1f * 10f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-1f * 10f, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(0, 0, -1f * 10f);
        }

    }
}
