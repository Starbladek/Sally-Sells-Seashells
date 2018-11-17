using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmeticSpawner : MonoBehaviour {

    public float fishTimerLength;
    float fishTimer;

    public float crabTimerLength;
    float crabTimer;

    public float seagullTimerLength;
    float seagullTimer;

    public GameObject cosmeticFish;
    public GameObject cosmeticCrab;
    public GameObject cosmeticSeagull;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        fishTimer += Time.deltaTime;
        if(fishTimer > fishTimerLength)
        {
            fishTimer -= fishTimerLength;
            print("Spawned fish!");
            Instantiate(cosmeticFish, transform.position, Quaternion.identity);
        }

        crabTimer += Time.deltaTime;
        if(crabTimer > crabTimerLength)
        {
            crabTimer -= crabTimerLength;
            print("Spawned crab!");
            Instantiate(cosmeticCrab, transform.position, Quaternion.identity);
        }

        seagullTimer += Time.deltaTime;
        if(seagullTimer > seagullTimerLength)
        {
            seagullTimer -= seagullTimerLength;
            print("Spawned seagull!");
            Instantiate(cosmeticSeagull, transform.position, Quaternion.identity);
        }
            
	}
}
