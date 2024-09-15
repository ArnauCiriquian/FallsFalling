using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class AntMechanics : MonoBehaviour
{
    // Add smoth vertical rotation for normal movement. Not working, needs fixing!

    private Rigidbody myRigidbody; // Reference to the Rigidbody component

    [Header("Ant movement")]
    public float maxRotation = 10.0f;  // Maximum rotation angle
    public float rotationSpeed = 20.0f; // Speed of rotation
    public float maxVerticalSpeed = 5;
    public float maxSpeed = 5;

    [Header("Camera settings")]
    public CinemachineVirtualCamera virtualCamera;
    public float diveFOV = 70f;
    public float normalFOV = 60f;
    public float fovTransitionSpeed = 5f;

    private PlayerActions inputActions;
    private bool IsDiving = false;

    private void OnEnable()
    {
        if (inputActions == null)
        {
            inputActions = new PlayerActions();

            inputActions.Ant.Dive.performed += ctx => IsDiving = true;
            inputActions.Ant.Dive.canceled += ctx => IsDiving = false;
        }

        inputActions.Enable();
    }

    private void OnDisable()
    {
        if (inputActions != null)
        {
            inputActions.Disable();
        }
    }

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();

        if (virtualCamera != null)
        {
            virtualCamera.m_Lens.FieldOfView = normalFOV;
        }
    }

    private void Update()
    {
        AntLateralMovement();
        AntVerticalMovement();

        if (IsDiving)
        {
            Dive();
        }
        else
        {
            ResetDiveRotation();
        }
    }

    private void AntLateralMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate desired velocity
        Vector3 desiredVelocity = new Vector3(horizontalInput * maxSpeed, myRigidbody.velocity.y, myRigidbody.velocity.z);

        // Calculate new position based on desired velocity
        Vector3 newPosition = transform.position + desiredVelocity * Time.deltaTime;

        // Limit the X and Y positions
        newPosition.x = Mathf.Clamp(newPosition.x, -3, 3);

        // Set the new position
        transform.position = newPosition;

        // Rotate the ant smoothly
        if (transform.position.x < 3)
        {
            if (transform.position.x > -3)
            {
                AntLateralRotation(horizontalInput);
            }
            else
            {
                ResetLateralRotation();
            }
        }
        else if (transform.position.x > -3)
        {
            if (transform.position.x < 3)
            {
                AntLateralRotation(horizontalInput);
            }
            else
            {
                ResetLateralRotation();
            }
        }
    }

    private void AntVerticalMovement()
    {
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate desired velocity
        Vector3 desiredVelocity = new Vector3(myRigidbody.velocity.x, myRigidbody.velocity.y, verticalInput * maxSpeed);

        // Calculate new position based on desired velocity
        Vector3 newPosition = transform.position + desiredVelocity * Time.deltaTime;

        // Limit the X and Y positions
        newPosition.z = Mathf.Clamp(newPosition.z, -1, 1);

        // Set the new position
        transform.position = newPosition;

        // Rotate the ant smoothly
        if (transform.position.z < 1)
        {
            if (transform.position.z > -1)
            {
                AntVerticalRotation(verticalInput);
            }
            else
            {
                ResetVerticalRotation();
            }
        }
        else if (transform.position.z > -1)
        {
            if (transform.position.z < 1)
            {
                AntVerticalRotation(verticalInput);
            }
            else
            {
                ResetVerticalRotation();
            }
        }
    }

    private void ResetLateralRotation()
    {
        float newZRotation = Mathf.MoveTowardsAngle(transform.rotation.eulerAngles.z, 0, Time.deltaTime * rotationSpeed);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, newZRotation);
    }

    private void AntLateralRotation(float HorizontalInput)
    {
        float newZRotation = Mathf.MoveTowardsAngle(transform.rotation.eulerAngles.z, -HorizontalInput * maxRotation, Time.deltaTime * rotationSpeed);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, newZRotation);
    }

    private void ResetVerticalRotation()
    {
        float newXRotation = Mathf.MoveTowardsAngle(transform.rotation.eulerAngles.x, 0, Time.deltaTime * rotationSpeed);
        transform.rotation = Quaternion.Euler(newXRotation, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }

    private void AntVerticalRotation(float VerticalInput)
    {
        float newXRotation = Mathf.MoveTowardsAngle(transform.rotation.eulerAngles.x, -VerticalInput * maxRotation, Time.deltaTime * rotationSpeed);
        transform.rotation = Quaternion.Euler(newXRotation, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }

    private void ResetDiveRotation()
    {
        float newXRotation = Mathf.MoveTowardsAngle(transform.rotation.eulerAngles.x, 0, Time.deltaTime * rotationSpeed);
        transform.rotation = Quaternion.Euler(newXRotation, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        if (virtualCamera != null)
        {
            float currentFOV = virtualCamera.m_Lens.FieldOfView;
            virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(currentFOV, normalFOV, Time.deltaTime * fovTransitionSpeed);
        }
    }

    private void Dive()
    {
        float targetXRotation = 70f;
        float newXRotation = Mathf.MoveTowardsAngle(transform.rotation.eulerAngles.x, targetXRotation, Time.deltaTime * rotationSpeed * 10);
        transform.rotation = Quaternion.Euler(newXRotation, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        if (virtualCamera != null)
        {
            float currentFOV = virtualCamera.m_Lens.FieldOfView;
            virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(currentFOV, diveFOV, Time.deltaTime * fovTransitionSpeed);
        }
    }

    public float CurrentDiveAngle
    {
        get { return transform.rotation.eulerAngles.x; }
    }
}