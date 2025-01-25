using UnityEditor.Callbacks;
using UnityEngine;

public class CarAudioScript : MonoBehaviour
{
    Rigidbody rb;
    AudioSource engineAudio;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        engineAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current speed of the car
        float speed = rb.linearVelocity.magnitude;

        // Calculate the volume based on speed
        float normalizedSpeed = Mathf.Clamp01(speed / 30); // Normalize speed (0 to 1)
        engineAudio.volume = Mathf.Lerp(0, 0.5f, normalizedSpeed);
    }
}
