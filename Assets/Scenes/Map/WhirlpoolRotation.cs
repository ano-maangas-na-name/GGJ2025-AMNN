using UnityEngine;

public class Whirlpool : MonoBehaviour
{
    public float rotationspeed;

    // Update is called once per frame
    void Update()
    {
        // Rotate the object around its Z-axis in place
        transform.Rotate(0, 0, rotationspeed * Time.deltaTime);
    }
}
