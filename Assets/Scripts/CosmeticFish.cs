using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmeticFish : MonoBehaviour {
    Vector2 startPos;
    Vector2 velocity;
    float gravity = 0.5f;

	// Use this for initialization
	void Start () {
        startPos = transform.position;//new Vector2(0, 0);//Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        velocity = new Vector2(-5, 5);
        print("hi start");
        
	}
	
	// Update is called once per frame
	void Update () {
        velocity.y -= gravity;
        transform.Translate(velocity * Time.deltaTime);
        if (transform.position.y < startPos.y)
        {
            Destroy(gameObject);
        }
	}
}
