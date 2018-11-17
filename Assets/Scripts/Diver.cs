using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diver : MonoBehaviour
{
    public float speedOfMovement;
    public float populationCapacity;
    public int carryCapacity;

    Vector2 startPos;
    Vector2 checkpointOne;
    Vector2 checkpointTwo;
    int phase = 0;

    Vector2 prevCheckpoint;
    Vector2 currentTargetCheckpoint;
    float lerpTime = 0;

    bool isScrounging;
    public float scroungingTimerLength;
    float scroungingTimer;



    void Start()
    {
        startPos = transform.position;
        checkpointOne = new Vector2(transform.position.x - 5f, transform.position.y - 1f);
        checkpointTwo = new Vector2(checkpointOne.x - 1f, checkpointTwo.y - 8f);

        prevCheckpoint = startPos;
        currentTargetCheckpoint = checkpointOne;

        scroungingTimer = scroungingTimerLength;
    }

    void Update()
    {
        if (!isScrounging)
        {
            transform.position = Vector2.Lerp(prevCheckpoint, currentTargetCheckpoint, lerpTime);
            lerpTime += speedOfMovement * Time.deltaTime;
        }

        if (lerpTime > 1)
        {
            lerpTime = 0;
            phase++;

            switch(phase)
            {
                case 1:
                    prevCheckpoint = checkpointOne;
                    currentTargetCheckpoint = checkpointTwo;
                    break;

                case 2:
                    isScrounging = true;
                    break;

                case 3:
                    prevCheckpoint = checkpointOne;
                    currentTargetCheckpoint = startPos;
                    break;

                case 4:
                    GameMaster.instance.IncrementShellCount((int)carryCapacity);
                    Destroy(gameObject);
                    break;
            }
        }

        if (isScrounging)
        {
            scroungingTimer -= Time.deltaTime;
            if (scroungingTimer <= 0)
            {
                isScrounging = false;
                prevCheckpoint = checkpointTwo;
                currentTargetCheckpoint = checkpointOne;
            }
        }

        /*LeanTween.delayedCall(gameObject, meteorSmoke.length, () =>
        {
            Destroy(gameObject);
        });*/
    }
}
 