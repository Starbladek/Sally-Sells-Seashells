using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diver : MonoBehaviour
{
    public float speedOfMovement;
    public int carryCapacity;

    Vector2 startPos;
    public List<GameObject> checkpoints;
    int checkpointNum = 0;

    Vector2 prevCheckpoint;
    Vector2 currentTargetCheckpoint;
    float lerpTime = 0;
    bool divingDown = true;

    bool isScrounging;
    public float scroungingTimerLength;
    float scroungingTimer;



    void Start()
    {
        startPos = transform.position;
        prevCheckpoint = startPos;
        currentTargetCheckpoint = checkpoints[checkpointNum].transform.position;
        scroungingTimer = scroungingTimerLength;
    }

    void Update()
    {
        if (divingDown)
        {
            lerpTime += speedOfMovement * Time.deltaTime;
            transform.position = Vector2.Lerp(prevCheckpoint, currentTargetCheckpoint, lerpTime);

            if (lerpTime >= 1)
            {
                lerpTime = 0;
                print(checkpointNum);
                print(checkpoints.Count);
                if (checkpointNum < checkpoints.Count)
                {
                    checkpointNum++;
                    prevCheckpoint = currentTargetCheckpoint;
                    currentTargetCheckpoint = checkpoints[checkpointNum].transform.position;
                }
                else
                {
                    //We've reached the last checkpoint
                    print("Starting to scrounge...");
                    divingDown = false;
                    isScrounging = true;
                }
            }
        }
        else if (isScrounging)
        {
            scroungingTimer -= Time.deltaTime;
            if (scroungingTimer <= 0)
            {
                isScrounging = false;
                prevCheckpoint = checkpoints[checkpoints.Count - 1].transform.position;
                currentTargetCheckpoint = checkpoints[checkpoints.Count - 2].transform.position;
            }
        }
        else
        {
            lerpTime += speedOfMovement * Time.deltaTime;
            transform.position = Vector2.Lerp(prevCheckpoint, currentTargetCheckpoint, lerpTime);

            if (lerpTime >= 1)
            {
                lerpTime = 0;
                if (checkpointNum > 0)
                {
                    checkpointNum--;
                    if (checkpointNum == 0)
                    {
                        prevCheckpoint = currentTargetCheckpoint;
                        currentTargetCheckpoint = startPos;
                    }
                    else
                    {
                        prevCheckpoint = currentTargetCheckpoint;
                        currentTargetCheckpoint = checkpoints[checkpointNum].transform.position;
                    }
                    
                }
                else
                {
                    GameMaster.instance.IncrementShellCount(carryCapacity);
                    Destroy(gameObject);
                }
            }
        }
    }
}
 