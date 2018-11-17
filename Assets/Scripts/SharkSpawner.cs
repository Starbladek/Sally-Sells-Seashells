using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkSpawner : MonoBehaviour
{
    public Shark sharkPrefab;
    public float spawnTimerLengthMin;
    public float spawnTimerLengthMax;
    float spawnTimer;

    void Start()
    {
        spawnTimer = Random.Range(spawnTimerLengthMin, spawnTimerLengthMax);
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            spawnTimer += Random.Range(spawnTimerLengthMin, spawnTimerLengthMax);
            Instantiate(sharkPrefab);
        }
    }
}