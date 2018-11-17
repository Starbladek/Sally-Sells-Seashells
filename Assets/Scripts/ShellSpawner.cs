using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellSpawner : MonoBehaviour
{
    public float shellSpawnTimerLength;
    float shellSpawnTimer;

    public GameObject[] shellPrefabs;

    void Start()
    {
        shellSpawnTimer = shellSpawnTimerLength;
    }

    void Update()
    {
        shellSpawnTimer -= Time.deltaTime;
        if (shellSpawnTimer <= 0)
        {
            int shellNum = 0;
            float randomValue = Random.Range(0f, 100f);

            if (randomValue < 90)
                shellNum = 0;
            else if (randomValue >= 90 && randomValue < 95)
                shellNum = 1;
            else if (randomValue >= 95 && randomValue < 99)
                shellNum = 2;
            else
                shellNum = 3;

            GameObject newShell = Instantiate(shellPrefabs[shellNum],
                new Vector2(-2.15f + Random.Range(0, 0.5f), 0.75f - Random.Range(0, 0.3f)),
                Quaternion.identity);
            shellSpawnTimer += shellSpawnTimerLength;
        }
    }
}