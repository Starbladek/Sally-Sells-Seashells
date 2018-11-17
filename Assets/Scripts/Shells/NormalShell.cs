using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalShell : MonoBehaviour
{
    public int shellValue;
    bool clicked;

    void OnMouseDown()
    {
        if (!clicked)
        {
            clicked = true;
            GameMaster.instance.IncrementShellCount(shellValue);
            LeanTween.alpha(gameObject, 0, 1);
            LeanTween.scale(gameObject, transform.localScale * 3, 1).setEase(LeanTweenType.easeOutExpo).setOnComplete(() =>
            {
                Destroy(gameObject);
            });
        }
    }
}