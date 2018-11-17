using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    DiverHandler diverHandler;
    ShellHandler shellHandler;

    void Start()
    {
        diverHandler = GetComponent<DiverHandler>();
        shellHandler = GetComponent<ShellHandler>();
    }

    void Update()
    {

    }
}
