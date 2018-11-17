using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StandHandler : MonoBehaviour {

    public Sprite normalSprite;
    public Sprite hoverSprite;

    public GameObject standMenu;
    bool menu;

    // Use this for initialization
    void Start () {
		menu = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().sprite = hoverSprite;
    }

    void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().sprite = normalSprite;
    }

    void OnMouseDown()
    {
        if (menu) {
            standMenu.SetActive(false);
            menu = false;
        }
        else {
            standMenu.SetActive(true);
            menu = true;
        }

    }
}
