using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;
    int shellCount;



    void Start()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {

    }



    public void IncrementShellCount(int amount)
    {
        shellCount += amount;
        print(shellCount);
    }

    public void DecrementShellCount(int amount)
    {
        shellCount -= amount;
        print(shellCount);
    }
}
