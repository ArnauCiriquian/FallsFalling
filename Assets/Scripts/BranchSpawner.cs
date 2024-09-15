using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchSpawner : MonoBehaviour
{
    public GameObject branch;
    public float spawnRate;
    private float timer = 0;

    void Start()
    {
        spawnPipe();
    }

    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }
    }

    void spawnPipe()
    {
        int spawnSpot = Random.Range(1, 5);

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
        }
    }
}
