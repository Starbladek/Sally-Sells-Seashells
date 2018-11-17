using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    GameObject followTarget;
    float smoothTime = 0.15f;
    Vector2 velocity = Vector2.zero;
    public Vector2[] milestonePositions;
    public float[] milestoneSizes;
    Camera cameraRef;

    void Start()
    {
        cameraRef = GetComponent<Camera>();
    }

    void Update()
    {
        if (followTarget != null)
        {
            Vector2 targetPosition = new Vector2(followTarget.transform.position.x, followTarget.transform.position.y);
            transform.position = Vector2.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }
    }

    public void ChangeFollowTarget(GameObject newTarget)
    {
        followTarget = newTarget;
    }

    public void UpdateMilestonePosition(int newFarthestCheckpoint)
    {
        LeanTween.value(cameraRef.orthographicSize, milestoneSizes[newFarthestCheckpoint], 1).setOnUpdate((float val) =>
        {
            cameraRef.orthographicSize = val;
        });
        LeanTween.move(gameObject, milestonePositions[newFarthestCheckpoint], 1);
    }
}