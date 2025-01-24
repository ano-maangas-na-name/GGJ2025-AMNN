using UnityEngine;

public class ObjectRotate : MonoBehaviour
{
    // Slider for axis rotation adjustment
    [Range(-1, 1)] public float rotateX = 0;
    [Range(-1, 1)] public float rotateY = 1;
    [Range(-1, 1)] public float rotateZ = 0;

    // Slider for rotation speed adjustment
    [Range(0, 500)] public float rotationSpeed = 100;

    void Update()
    {
        transform.Rotate(rotateX * Time.deltaTime * rotationSpeed, rotateY * Time.deltaTime * rotationSpeed, rotateZ * Time.deltaTime * rotationSpeed);

    }
}