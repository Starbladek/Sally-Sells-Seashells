using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starfish : MonoBehaviour
{
    bool clicked;
    public int shellValue;

    public float minLifeLength;
    public float maxLifeLength;
    float lifeTimerLength;
    float lifeTimer;

    [HideInInspector]
    public ShellSpawner shellSpawner;



    void Start()
    {
        lifeTimerLength = Random.Range(minLifeLength, maxLifeLength);
        lifeTimer = lifeTimerLength;

        transform.localScale = new Vector2(0.2f, 0.2f);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);

        LeanTween.scale(gameObject, new Vector2(0.4f, 0.4f), 0.5f).setEase(LeanTweenType.easeOutExpo);
        LeanTween.alpha(gameObject, 1, 0.5f).setEase(LeanTweenType.easeOutExpo);
    }

    void Update()
    {
        if (!clicked)
        {
            lifeTimer -= Time.deltaTime;
            if (lifeTimer <= 0)
            {
                lifeTimer = 999;    //bluh
                LeanTween.moveY(gameObject, transform.position.y - 0.25f, 2).setEase(LeanTweenType.easeInCubic);
                LeanTween.alpha(gameObject, 0, 2).setEase(LeanTweenType.easeInCubic).setOnComplete(() =>
                {
                    shellSpawner.currentNumberOfShells--;
                    Destroy(gameObject);
                });
            }
        }
    }

    void OnMouseDown()
    {
        if (!clicked)
        {
            LeanTween.cancel(gameObject);
            clicked = true;
            GameMaster.instance.IncrementShellCount(shellValue);
            LeanTween.alpha(gameObject, 0, 1);
            LeanTween.scale(gameObject, transform.localScale * 3, 1).setEase(LeanTweenType.easeOutExpo).setOnComplete(() =>
            {
                shellSpawner.currentNumberOfShells--;
                Destroy(gameObject);
            });
        }
    }
}
