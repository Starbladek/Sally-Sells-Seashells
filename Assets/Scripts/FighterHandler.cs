using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterHandler : MonoBehaviour
{
    enum State { Idle, Active };
    State state;

    public int speed;
    public Vector2 idleStart;
    public Vector2 activeStart;

    Rigidbody2D myRigidbody;
    public LayerMask sharkMask;

    Camera mainCamera;
    float cameraIdleSize;
    public float cameraActiveSize;



    void Start ()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        cameraIdleSize = mainCamera.orthographicSize;
	}
	
	void Update ()
    {
        switch(state)
        {
            case State.Idle:
                break;

            case State.Active:
                Walk();
                Attacc();
                CheckIfBackOnShore();
                break;
        }
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
            int direction = (int)Mathf.Sign(myRigidbody.velocity.x);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * direction, 1, sharkMask);
            Debug.DrawRay(transform.position, Vector2.right * direction, Color.red);

            if (hit)
            {
                print("Boink??");
            }
        }
    }

    void CheckIfBackOnShore()
    {
        if (transform.position.x <= -2.75f && transform.position.y >= 7.85f)
        {
            LeanTween.value(mainCamera.orthographicSize, cameraIdleSize, 1).setEase(LeanTweenType.easeOutQuad).setOnUpdate((float val) =>
            {
                mainCamera.orthographicSize = val;
            });

            myRigidbody.bodyType = RigidbodyType2D.Kinematic;
            LeanTween.moveX(gameObject, idleStart.x, 1f);
            LeanTween.moveY(gameObject, idleStart.y + 0.5f, 0.5f).setEase(LeanTweenType.linear).setOnComplete(() =>
            {
                LeanTween.moveY(gameObject, idleStart.y, 0.5f).setEase(LeanTweenType.linear).setOnComplete(() =>
                {
                    state = State.Idle;
                });
            });
        }
    }

    void OnMouseDown()
    {
        if (state == State.Idle)
        {
            LeanTween.value(mainCamera.orthographicSize, cameraActiveSize, 1).setEase(LeanTweenType.easeOutQuad).setOnUpdate((float val) =>
            {
                mainCamera.orthographicSize = val;
            });
            mainCamera.GetComponent<CameraHandler>().ChangeFollowTarget(gameObject);

            LeanTween.moveX(gameObject, activeStart.x, 1.5f);
            LeanTween.moveY(gameObject, idleStart.y + 1f, 0.5f).setEase(LeanTweenType.easeOutCubic).setOnComplete(() =>
            {
                LeanTween.moveY(gameObject, activeStart.y, 1f).setEase(LeanTweenType.easeInOutCubic).setOnComplete(() =>
                {
                    state = State.Active;
                    myRigidbody.bodyType = RigidbodyType2D.Dynamic;
                });
            });
        }
    }
}