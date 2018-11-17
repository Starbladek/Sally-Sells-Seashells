using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{
    public float minVelocityX;
    public float maxVelocityX;
    float velocityX;
    bool escaping;

    void Start()
    {
        velocityX = Random.Range(minVelocityX, maxVelocityX);
        transform.Translate(new Vector2(0, Random.Range(0f, 10.5f)));
    }

    void Update()
    {
        transform.Translate(new Vector2(velocityX * Time.deltaTime, 0));
        if (escaping)
        {
            if (transform.position.x > 32f)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Diver")
        {
            Destroy(other.gameObject);
            GetComponent<SpriteRenderer>().flipX = true;
            velocityX = 20f;
            escaping = true;
        }
        if (other.gameObject.tag == "Sand")
        {
            GetComponent<SpriteRenderer>().flipX = true;
            velocityX = 20f;
            escaping = true;
        }
    }
}