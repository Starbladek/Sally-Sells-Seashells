using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiverSpawner : MonoBehaviour
{
    public float movementSpeed;
    public int carryCapacity;
    public int farthestCheckpoint = 2;
    public float scroungingTimerLength;
    public float maximumActiveDiverCount;

    [HideInInspector]
    public int currentActiveDiverCount = 0;
    public List<GameObject> checkpointObjects;

    public GameObject diverPrefab;



    public void IncreaseFarthestCheckpoint()
    {
        farthestCheckpoint++;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraHandler>().UpdateMilestonePosition(farthestCheckpoint);
    }

    void OnMouseDown()
    {
        if (currentActiveDiverCount < maximumActiveDiverCount)
        {
            currentActiveDiverCount++;
            IncreaseFarthestCheckpoint();

            GameObject diver = Instantiate(diverPrefab, transform.position, Quaternion.identity);
            Diver diverComp = diver.GetComponent<Diver>();
            diverComp.checkpoints = new List<GameObject>(checkpointObjects);
            diverComp.Initialize(movementSpeed, carryCapacity, farthestCheckpoint, scroungingTimerLength, this);
        }
    }
}