using UnityEngine;

public class MapWheel : MonoBehaviour
{
    public float rotatePower;
    public float stopPower;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rotate();
        }

        if (rb.angularVelocity > 0)
        {
            rb.angularVelocity -= stopPower * Time.deltaTime;

            rb.angularVelocity = Mathf.Clamp(rb.angularVelocity, 0, 1440);
        }
    }

    public void Rotate()
    {
        rb.AddTorque(rotatePower);
    }
}
