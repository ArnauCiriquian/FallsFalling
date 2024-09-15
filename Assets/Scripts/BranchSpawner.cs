using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchSpawner : MonoBehaviour
{
    public GameObject branch;
    public float normalSpawnRate = 1f;
    public float diveSpawnRate = 0.5f;

    private float spawnRate;
    private float timer = 0;

    private AntMechanics antMechanics;

    void Start()
    {
        antMechanics = FindObjectOfType<AntMechanics>();

        spawnRate = normalSpawnRate;
    }

    void Update()
    {
        if (antMechanics != null)
        {
            float currentAngle = antMechanics.CurrentDiveAngle;

            float t = Mathf.Clamp(currentAngle / 70f, 0, 1);
            spawnRate = Mathf.Lerp(normalSpawnRate, diveSpawnRate, t);
        }
        else
        {
            spawnRate = normalSpawnRate;
        }

        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnBranch();
            timer = 0;
        }
    }

    void spawnBranch()
    {
        int spawnSpot = Random.Range(1, 9);

        switch (spawnSpot)
        {
            case 1:
                Instantiate(branch, new Vector3(10, -10, 0), Quaternion.Euler(90, 0, 90));
                break;
            case 2:
                Instantiate(branch, new Vector3(0, -10, -10), Quaternion.Euler(90, 90, 90));
                break;
            case 3:
                Instantiate(branch, new Vector3(-10, -10, 0), Quaternion.Euler(90, 180, 90));
                break;
            case 4:
                Instantiate(branch, new Vector3(0, -10, 10), Quaternion.Euler(90, 270, 90));
                break;
            case 5:
                Instantiate(branch, new Vector3(-8, -10, -6), Quaternion.Euler(90, 135, 90));
                break;
            case 6:
                Instantiate(branch, new Vector3(8, -10, -6), Quaternion.Euler(90, 45, 90));
                break;
            case 7:
                Instantiate(branch, new Vector3(8, -10, 6), Quaternion.Euler(90, -45, 90));
                break;
            case 8:
                Instantiate(branch, new Vector3(0, -10, 10), Quaternion.Euler(90, -135, 90));
                break;
        }
    }
}
