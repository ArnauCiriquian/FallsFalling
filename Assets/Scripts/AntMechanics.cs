using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntMechanics : MonoBehaviour
{
    // Changes plane (now moving in Y plane - changes ant and camera to Y plane)


    private Rigidbody myRigidbody; // Reference to the Rigidbody component

    [Header("Ant movement")]
    public float maxRotation = 10.0f;  // Maximum rotation angle
    public float rotationSpeed = 20.0f; // Speed of rotation
    public float maxVerticalSpeed = 5;
    public float maxLateralSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component attached to this GameObject
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        AntLateralMovement();
        AntVerticalMovement();
    }

    void AntLateralMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate desired velocity
        Vector3 desiredVelocity = new Vector3(horizontalInput * maxLateralSpeed, myRigidbody.velocity.y, myRigidbody.velocity.z);

        // Calculate new position based on desired velocity
        Vector3 newPosition = transform.position + desiredVelocity * Time.deltaTime;

        // Limit the X and Y positions
        newPosition.x = Mathf.Clamp(newPosition.x, -3, 3);

        // Set the new position
        transform.position = newPosition;

        // Rotate the spaceship smoothly
        if (transform.position.x < 3)
        {
            if (transform.position.x > -3)
            {
                AntRotation(horizontalInput);
            }
            else
            {
                ResetRotation();
            }
        }
        else if (transform.position.x > -3)
        {
            if (transform.position.x < 3)
            {
                AntRotation(horizontalInput);
            }
            else
            {
                ResetRotation();
            }
        }
    }

    void AntVerticalMovement()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float newZVelocity = Mathf.Clamp(verticalInput * maxVerticalSpeed, -1, 1);
        myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, myRigidbody.velocity.y, newZVelocity);

        // Calculate the new Y position based on the current position and velocity
        float newZPosition = Mathf.Clamp(transform.position.z + newZVelocity * Time.deltaTime, -1, 1);

        // Update the Z position
        transform.position = new Vector3(transform.position.x, transform.position.y, newZPosition);
    }

    void ResetRotation()
    {
        float newZRotation = Mathf.MoveTowardsAngle(transform.rotation.eulerAngles.z, 0, Time.deltaTime * rotationSpeed);
        transform.rotation = Quaternion.Euler(0, 0, newZRotation);
    }

    void AntRotation(float HorizontalInput)
    {
        float newZRotation = Mathf.MoveTowardsAngle(transform.rotation.eulerAngles.z, -HorizontalInput * maxRotation, Time.deltaTime * rotationSpeed);
        transform.rotation = Quaternion.Euler(0, 0, newZRotation);
    }
}