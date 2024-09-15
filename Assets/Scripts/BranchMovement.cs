using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = 40;

    void Update()
    {
        transform.position = transform.position + (Vector3.up * moveSpeed) * Time.deltaTime;

        if (transform.position.y > deadZone)
        {
            Destroy(gameObject);
        }
    }
}
