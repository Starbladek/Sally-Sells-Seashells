using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;
    int shellCount;
    [HideInInspector]
    public int farthestCheckpoint;

    public Text shellText;

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
        shellText.text = shellCount.ToString();
        //print(shellCount);
    }

    public void DecrementShellCount(int amount)
    {
        shellCount -= amount;
        shellText.text = shellCount.ToString();
        //print(shellCount);
    }
}
