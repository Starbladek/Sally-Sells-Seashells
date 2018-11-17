using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    ShellHandler shellHandler;

    void Start()
    {
        shellHandler = GetComponent<ShellHandler>();
    }

    void Update()
    {

    }
}
