using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public float spawnTimerMinLength;
    public float spawnTimerMaxLength;
    float spawnTimerLength;
    float spawnTimer;

    public GameObject[] cloudPrefabs;

    void Start()
    {
        spawnTimerLength = Random.Range(spawnTimerMinLength, spawnTimerMaxLength);
        spawnTimer = spawnTimerLength;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            spawnTimerLength = Random.Range(spawnTimerMinLength, spawnTimerMaxLength);
            spawnTimer += spawnTimerLength;
            Instantiate(cloudPrefabs[Random.Range(0, 2)]);
        }
    }
}