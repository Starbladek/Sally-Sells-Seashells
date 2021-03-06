﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StandMenuHandler : MonoBehaviour {

    public GameObject hut;

    public Text movementSpeedText;
    public Text carryCapacityText;
    public Text farthestCheckpointText;
    public Text scroungingTimerLengthText;
    public Text maximumActiveDiverCountText;

    // Use this for initialization
    void Start () {
        movementSpeedText.text = hut.GetComponent<DiverSpawner>().movementSpeed.ToString();
        carryCapacityText.text = hut.GetComponent<DiverSpawner>().carryCapacity.ToString();
        farthestCheckpointText.text = hut.GetComponent<DiverSpawner>().farthestCheckpoint.ToString();
        scroungingTimerLengthText.text = hut.GetComponent<DiverSpawner>().scroungingTimerLength.ToString();
        maximumActiveDiverCountText.text = hut.GetComponent<DiverSpawner>().maximumActiveDiverCount.ToString();

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnClickFlipper()
    {
        if (GameMaster.instance.shellCount >= 1)
        {
            GameMaster.instance.DecrementShellCount(1);
            hut.GetComponent<DiverSpawner>().movementSpeed += 0.1f;
            movementSpeedText.text = hut.GetComponent<DiverSpawner>().movementSpeed.ToString();
        }
    }

    public void OnClickBag()
    {
        if (GameMaster.instance.shellCount >= 1)
        {
            GameMaster.instance.DecrementShellCount(1);
            hut.GetComponent<DiverSpawner>().carryCapacity += 1;
            carryCapacityText.text = hut.GetComponent<DiverSpawner>().carryCapacity.ToString();
        }
    }

    public void OnClickFarther()
    {
        if (GameMaster.instance.shellCount >= 1)
        {
            GameMaster.instance.DecrementShellCount(1);
            hut.GetComponent<DiverSpawner>().farthestCheckpoint += 1;
            farthestCheckpointText.text = hut.GetComponent<DiverSpawner>().farthestCheckpoint.ToString();
        }
    }

    public void OnClickTimer()
    {
        if (GameMaster.instance.shellCount >= 1)
        {
            GameMaster.instance.DecrementShellCount(1);
            hut.GetComponent<DiverSpawner>().scroungingTimerLength += 1;
            scroungingTimerLengthText.text = hut.GetComponent<DiverSpawner>().scroungingTimerLength.ToString();
        }
    }

    public void OnClickBeds()
    {
        if (GameMaster.instance.shellCount >= 1)
        {
            GameMaster.instance.DecrementShellCount(1);
            hut.GetComponent<DiverSpawner>().maximumActiveDiverCount += 1;
            maximumActiveDiverCountText.text = hut.GetComponent<DiverSpawner>().maximumActiveDiverCount.ToString();
        }
    }
}