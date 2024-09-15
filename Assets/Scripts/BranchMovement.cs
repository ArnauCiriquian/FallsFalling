using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchMovement : MonoBehaviour
{
    public float baseMoveSpeed = 10;
    public float maxMoveSpeed = 20;
    public float deadZone = 40;

    private AntMechanics antMechanics;

    private void Start()
    {
        antMechanics = FindObjectOfType<AntMechanics>();
    }

    void Update()
    {
        if (antMechanics != null)
        {
            float diveAngle = antMechanics.CurrentDiveAngle;

            float speedFactor = Mathf.Lerp(baseMoveSpeed, maxMoveSpeed, diveAngle / 70f);

            transform.position += (Vector3.up * speedFactor) * Time.deltaTime;
        }
        else
        {
            transform.position += (Vector3.up * baseMoveSpeed) * Time.deltaTime;
        }

        if (transform.position.y > deadZone)
        {
            Destroy(gameObject);
        }
    }
}
