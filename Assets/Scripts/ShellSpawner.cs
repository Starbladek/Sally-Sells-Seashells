using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellSpawner : MonoBehaviour
{
    float shellSpawnTimerLength = 5000f;
    float shellSpawnTimer;

    void Start()
    {
        shellSpawnTimer = shellSpawnTimerLength;
    }

    void Update()
    {
        shellSpawnTimer -= Time.deltaTime;
        if (shellSpawnTimer <= 0)
        {

        }
    }
}