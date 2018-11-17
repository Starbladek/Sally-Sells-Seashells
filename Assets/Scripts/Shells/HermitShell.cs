using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HermitShell : MonoBehaviour
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
    }

    void Update()
    {
        if (!clicked)
        {
            lifeTimer -= Time.deltaTime;
            if (lifeTimer <= 0)
            {
                shellSpawner.currentNumberOfShells--;
                Destroy(gameObject);
            }
        }
    }

    void OnMouseDown()
    {
        if (!clicked)
        {
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