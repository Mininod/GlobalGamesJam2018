﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour {

    public string textForSign;

    public GameObject sign;
    public Text UIText;
    private bool playerInsideBox;
	// Use this for initialization
	void Start () {

     
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInsideBox)
        {
            sign.GetComponentInChildren<Text>().text = textForSign;
            Debug.Log(textForSign);
            UIText.gameObject.SetActive(false);
            LookAtSign();

        }
        UIText.transform.position = Camera.main.WorldToScreenPoint(new Vector2(transform.position.x + 0.5f, transform.position.y + 1.5f));   	
	} 
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject != null)
        {
            if (other.GetComponentInParent<IsActivePlayer>() == true)
            {
                if (other.GetComponentInParent<IsActivePlayer>().getIsActivePlayer() == true)
                {
                    playerInsideBox = true;
                    other.GetComponent<Player>().SetTimePause(true);
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject != null)
        {
            if (other.GetComponentInParent<IsActivePlayer>() == true)
            {
                if (other.GetComponentInParent<IsActivePlayer>().getIsActivePlayer() == true)
                {
                    Debug.Log("SHIT");
                    playerInsideBox = false;
                    sign.SetActive(false);
                    other.GetComponent<Player>().SetTimePause(false);
                }
            }
        }
    }


    void LookAtSign()
    {
        sign.SetActive(!sign.activeSelf);
    }
}
