using UnityEngine;

public class MapWheel : MonoBehaviour
{
    public float rotatePower;
    public float stopPower;
    public bool rotated = false;
    private Rigidbody2D rb;
    float t;
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
            rb.AddTorque(rotatePower);
            rotated = true;
        }

        if (rb.angularVelocity > 0 && rotated)
        {
            rb.angularVelocity -= stopPower * Time.deltaTime;

            rb.angularVelocity = Mathf.Clamp(rb.angularVelocity, 1, 1440);
        }

        if (rb.angularVelocity == 0 && rotated)
        {
            GetMap();
        }
        // else
        // {
        //     if (rb.angularVelocity < 5)
        //     {
        //         rb.AddTorque(0.1f);

        //     }
        // }

        // if (!rotated)
        // {
        //     if (rb.angularVelocity < 5)
        //     {
        //         rb.AddTorque(0.1f);
        //     }

        // }


    }

    public void GetMap()
    {
        Debug.Log("Get Map");
        float rot = transform.eulerAngles.z;

        if (rot > -60 && rot < 60)
        {
            Debug.Log("Map 1");
        }
        else if (rot > -180 && rot < -60)
        {
            Debug.Log("Map 2");
        }
        else if (rot < 180 && rot > 60)
        {
            Debug.Log("Map 3");
        }

        // else if (rot > -60 && rot < 60)
        // {
        //     Debug.Log("Map 1");
        // }
    }

    // public void GetReward()
    // {
    //     float rot = transform.eulerAngles.z;

    //     if (rot > 0 && rot <= 120)
    //     {
    //         // GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 120);
    //         Debug.Log("Map 1");
    //     }
    //     else if (rot > 120 && rot <= 240)
    //     {
    //         // GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 240);
    //         Debug.Log("Map 3");

    //     }
    //     else if (rot > 240 && rot <= 360)
    //     {
    //         // GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 0);
    //         Debug.Log("Map 2");

    //     }
    // }

    public void Rotate()
    {
        if (!rotated)
        {

        }
    }
}
