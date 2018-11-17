using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmeticCrab : MonoBehaviour {

    Vector2 startPos;
    float velocityX;
    float velocityY;
    float destinationX;
    float destinationY;
    Vector2 endOfPathC;

    public float timerLength = 3;
    float timer;
    bool isWaiting;
    int phase = 0;

	// Use this for initialization
	void Start () {
        startPos = transform.position;
        velocityX = -0.05f;
        velocityY = 0.05f;
        destinationX = transform.position.x - 5;
        destinationY = transform.position.y + 3;
	}
	
	// Update is called once per frame
	void Update () {
        
        {
            switch (phase)
            {
                case 0:
                    transform.Translate(new Vector2(velocityX, velocityY));

                    if (transform.position.y > destinationY)
                    {
                        transform.Translate(new Vector2(velocityX, 0));
                        if (transform.position.x < destinationX)
                        {
                            phase++;
                        }
                    }
                    break;

                case 1:
                    timer += Time.deltaTime;
                    if (timer > timerLength)
                    {
                        phase++;
                        velocityX *= -1;
                        destinationX = transform.position.x + 5;
                    }
                    break;

                case 2:
                    transform.Translate(new Vector2(velocityX, 0));
                    if (transform.position.x > destinationX)
                        Destroy(gameObject);
                    break;
            }
        }
	}
}
