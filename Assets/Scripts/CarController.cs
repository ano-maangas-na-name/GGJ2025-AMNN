using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    private float currentSteerAngle, currentbreakForce;
    private bool isBreaking;

    [SerializeField] GameObject stun, sodaEffect;

    private Rigidbody rb;

    PlayerInput playerInput;
    InputAction moveAction;

    Vector2 direction;

    // Settings
    [SerializeField] private float motorForce, breakForce, maxSteerAngle;

    // Wheel Colliders
    [SerializeField] private WheelCollider frontLeftWheelCollider, frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider, rearRightWheelCollider;

    // Wheels
    [SerializeField] private Transform frontLeftWheelTransform, frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform, rearRightWheelTransform;

    //PowerUp
    public bool speedIncrease = false;
    public bool stunned = false;

    //Scripts
    // [SerializeField] private RaceManagerScript rms;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0f, -1f, 0f);
        moveAction = playerInput.actions.FindAction("Move");
    }

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        //UpdateWheels();
        //Debug.Log("Current Speed: " + rb.linearVelocity.x);
        // RigidbodyFreezeCheck();
    }

    private void GetInput()
    {
        direction = moveAction.ReadValue<Vector2>();
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = direction.y * motorForce * 2;
        frontRightWheelCollider.motorTorque = direction.y * motorForce * 2;
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();

        if (!speedIncrease)
        {
            rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, 25f);
        }

        else
        {
            rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, 30f);
            rb.linearVelocity = rb.linearVelocity.normalized * 30f;
        }

        if (stunned)
        {
            stun.SetActive(true);
            StartCoroutine(stunnedFalse());
        }
        else
        {
            stun.SetActive(false);
        }
    }

    IEnumerator stunnedFalse()
    {
        yield return new WaitForSeconds(2f);
        stunned = false;
    }

    private void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * direction.x;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

    // private void RigidbodyFreezeCheck()
    // {
    //     if (rms != null)
    //     {
    //         if (rms.gameState == RaceManagerScript.GameState.PreGame)
    //         {
    //             rb.isKinematic = true;
    //         }
    //         else
    //         {
    //             rb.isKinematic = false;
    //         }
    //     }

    // }
}