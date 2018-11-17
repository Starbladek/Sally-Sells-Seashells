using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterHandler : MonoBehaviour
{

    Rigidbody2D myRigidbody;
    SpriteRenderer mySpriteRenderer;

    public int speed;

    // Use this for initialization
    void Start ()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void Update ()
    {
        Walk();
        Attacc();
        
    }

    void Walk()
    {
        float hMovement = Input.GetAxis("Horizontal") * speed;
        float vMovement = Input.GetAxis("Vertical") * speed;
        myRigidbody.velocity = new Vector2(hMovement, vMovement);

    }

    void Attacc()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            // ????
            if (Physics2D.Raycast(transform.position, Vector2.right, 10))
            {
                Debug.DrawRay(transform.position, Vector2.right * 10 * 3, Color.red);
                print("Shark");
            }
            else
                print("Miss");
        }
    }
}
