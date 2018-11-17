using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    float velocityX;
    float yAnchor;
    float degs;

    void Start()
    {
        velocityX = Random.Range(-1.5f, -1f);
        yAnchor = transform.position.y;
    }

    void Update()
    {
        transform.Translate(new Vector2(velocityX * Time.deltaTime, 0));

        degs += 100 * Time.deltaTime;
        if (degs >= 360) degs -= 360;
        float ySinOffset = (Mathf.Sin(degs * Mathf.Deg2Rad)) * 0.1f;
        transform.position = new Vector2(transform.position.x, yAnchor + ySinOffset);
    }
}