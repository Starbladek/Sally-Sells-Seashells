using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmeticSeagull : MonoBehaviour {


    float moveSpeed = 2f;
    public float frequency = 2f;
    float magnitude = 0.5f;
    float destinationX = -5f;

    Vector3 pos;
    

    // Use this for initialization
    void Start () {
        pos = transform.position;

	}
	
	// Update is called once per frame
	void Update () {
        pos -= transform.right * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
        if (transform.position.x < destinationX)
        {
            Destroy(gameObject);
        }
       
    }
}
