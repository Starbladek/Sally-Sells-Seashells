using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellSpawner : MonoBehaviour
{
    public float shellSpawnTimerMinLength;
    public float shellSpawnTimerMaxLength;
    float shellSpawnTimerLength;
    float shellSpawnTimer;

    public int maxActiveShells;
    [HideInInspector]
    public int currentNumberOfShells;
    public GameObject[] shellPrefabs;

    void Start()
    {
        shellSpawnTimerLength = Random.Range(shellSpawnTimerMinLength, shellSpawnTimerMaxLength);
        shellSpawnTimer = shellSpawnTimerLength;
    }

    void Update()
    {
        shellSpawnTimer -= Time.deltaTime;
        if (shellSpawnTimer <= 0)
        {
            if (currentNumberOfShells < maxActiveShells)
            {
                currentNumberOfShells++;
                float randomValue = Random.Range(0f, 100f);

                if (randomValue < 90)
                {
                    GameObject newShell = Instantiate(shellPrefabs[0],
                    new Vector2(-10f + Random.Range(0, 3f), 7f - Random.Range(0, 4f)),
                    Quaternion.identity);
                    newShell.GetComponent<NormalShell>().shellSpawner = this;
                }
                else if (randomValue >= 90 && randomValue < 95)
                {
                    GameObject newShell = Instantiate(shellPrefabs[1],
                    new Vector2(-10f + Random.Range(0, 3f), 7f - Random.Range(0, 4f)),
                    Quaternion.identity);
                    newShell.GetComponent<HermitShell>().shellSpawner = this;
                }
                else if (randomValue >= 95 && randomValue < 99)
                {
                    GameObject newShell = Instantiate(shellPrefabs[2],
                    new Vector2(-10f + Random.Range(0, 3f), 7f - Random.Range(0, 4f)),
                    Quaternion.identity);
                    newShell.GetComponent<ConchShell>().shellSpawner = this;
                }
                else
                {
                    GameObject newShell = Instantiate(shellPrefabs[3],
                    new Vector2(-10f + Random.Range(0, 3f), 7f - Random.Range(0, 4f)),
                    Quaternion.identity);
                    newShell.GetComponent<Starfish>().shellSpawner = this;
                }
            }

            shellSpawnTimerLength = Random.Range(shellSpawnTimerMinLength, shellSpawnTimerMaxLength);
            shellSpawnTimer += shellSpawnTimerLength;
        }
    }
}