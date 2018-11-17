using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiverSpawner : MonoBehaviour
{
    public float movementSpeed;
    public int carryCapacity;
    public int farthestCheckpoint = 2;
    public float maximumActiveDiverCount;
    int currentActiveDiverCount = 0;
    public List<GameObject> checkpointObjects;

    public GameObject diverPrefab;

    void OnMouseDown()
    {
        if (currentActiveDiverCount < maximumActiveDiverCount)
        {
            GameObject diver = Instantiate(diverPrefab, transform.position, Quaternion.identity);
            diver.GetComponent<Diver>().checkpoints = new List<GameObject>(checkpointObjects);
            diver.GetComponent<Diver>().farthestCheckpoint = farthestCheckpoint;
            diver.GetComponent<Diver>().Initialize();
        }
    }
}