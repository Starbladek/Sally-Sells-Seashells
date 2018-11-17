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
    public Sprite normalSprite;
    public Sprite hoverSprite;



    public void IncreaseFarthestCheckpoint()
    {
        if (farthestCheckpoint < checkpointObjects.Count - 2)
        {
            farthestCheckpoint++;
            GameMaster.instance.farthestCheckpoint = farthestCheckpoint;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraHandler>().SetToMilestonePosition(farthestCheckpoint);
        }
    }

    void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().sprite = hoverSprite;
    }

    void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().sprite = normalSprite;
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