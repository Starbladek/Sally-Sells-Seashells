using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diver : MonoBehaviour
{
    float movementSpeed;
    int carryCapacity;

    Vector2 startPos;
    public List<GameObject> checkpoints;
    int farthestCheckpoint;
    int checkpointNum = 0;

    Vector2 prevCheckpoint;
    Vector2 currentTargetCheckpoint;
    float lerpTime = 0;
    bool divingDown = true;

    bool isScrounging;
    float scroungingTimerLength;
    float scroungingTimer;

    Animator animator;
    DiverSpawner diverSpawner;



    void Start()
    {
        animator = GetComponent<Animator>();
        startPos = transform.position;
        prevCheckpoint = startPos;
        //currentTargetCheckpoint = checkpoints[checkpointNum].transform.position;
        scroungingTimer = scroungingTimerLength;
    }

    public void Initialize(float movementSpeed, int carryCapacity, int farthestCheckpoint, float scroungingTimerLength, DiverSpawner diverSpawner)
    {
        this.movementSpeed = movementSpeed + Random.Range(-0.25f, 0.25f);
        this.carryCapacity = carryCapacity;
        this.farthestCheckpoint = farthestCheckpoint;
        this.scroungingTimerLength = scroungingTimerLength + Random.Range(-1f, 1f);
        this.diverSpawner = diverSpawner;
        currentTargetCheckpoint = checkpoints[checkpointNum].transform.position;
    }

    void Update()
    {
        if (divingDown)
        {
            lerpTime += movementSpeed * Time.deltaTime;
            transform.position = Vector2.Lerp(prevCheckpoint, currentTargetCheckpoint, lerpTime);

            if (lerpTime >= 1)
            {
                animator.SetBool("isSwimming", true);
                lerpTime = 0;
                if (checkpointNum < farthestCheckpoint)
                {
                    checkpointNum++;
                    prevCheckpoint = currentTargetCheckpoint;
                    currentTargetCheckpoint = checkpoints[checkpointNum].transform.position;
                }
                else
                {
                    //We've reached the last checkpoint
                    //print("Starting to scrounge...");
                    divingDown = false;
                    isScrounging = true;
                    animator.SetBool("isScrounging", true);
                }
            }
        }
        else if (isScrounging)
        {
            scroungingTimer -= Time.deltaTime;
            if (scroungingTimer <= 0)
            {
                isScrounging = false;
                animator.SetBool("isScrounging", false);
                GetComponent<SpriteRenderer>().flipX = false;
                checkpointNum--;
                prevCheckpoint = checkpoints[farthestCheckpoint].transform.position;
                currentTargetCheckpoint = checkpoints[farthestCheckpoint - 1].transform.position;
            }
        }
        else
        {
            lerpTime += movementSpeed * Time.deltaTime;
            transform.position = Vector2.Lerp(prevCheckpoint, currentTargetCheckpoint, lerpTime);

            if (lerpTime >= 1)
            {
                lerpTime = 0;
                if (checkpointNum > 0)
                {
                    checkpointNum--;
                    if (checkpointNum == 0)
                    {
                        animator.SetBool("isSwimming", true);
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
                    diverSpawner.currentActiveDiverCount--;
                    Destroy(gameObject);
                }
            }
        }
    }
}
 