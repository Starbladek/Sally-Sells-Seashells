using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiverSpawner : MonoBehaviour
{
    public int farthestCheckpoint = 1;
    public float maximumActiveDiverCount;
    int currentActiveDiverCount = 0;
    public GameObject[] checkpointObjects;

    public GameObject diverPrefab;

    void Start()
    {
        for (int i = 0; i < checkpointObjects.Length; i++)
        {
            diverPrefab.GetComponent<Diver>().checkpoints.Add(checkpointObjects[i]);
        }
    }

    void OnMouseDown()
    {
        if (currentActiveDiverCount < maximumActiveDiverCount)
        {
            Instantiate(diverPrefab, transform.position, Quaternion.identity);
        }
    }
}