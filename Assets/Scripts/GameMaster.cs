using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;
    [HideInInspector]
    public int shellCount;
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
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Main_Menu");
        }
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
