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

    void OnMouseDown()
    {
        if (currentActiveDiverCount < maximumActiveDiverCount)
        {
            GameObject diver = Instantiate(diverPrefab, transform.position, Quaternion.identity);
            diver.GetComponent<Diver>().checkpoints.Add(checkpointObjects[0].transform.position);
            diver.GetComponent<Diver>().checkpoints.Add(checkpointObjects[1].transform.position);
            diver.GetComponent<Diver>().Initialize();
        }
    }
}