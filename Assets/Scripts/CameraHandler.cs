using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    GameObject followTarget;
    float smoothTime = 0.15f;
    Vector2 velocity = Vector2.zero;

    void Start()
    {

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
}