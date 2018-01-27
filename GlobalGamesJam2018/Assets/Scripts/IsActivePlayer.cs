using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsActivePlayer : MonoBehaviour {

    private bool ActivePlayer;

	// Use this for initialization
	void Start ()
    {
        ActivePlayer = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool getIsActivePlayer()
    {
        return ActivePlayer;
    }
    public void setActivePlayer(bool input)
    {
        ActivePlayer = input;
    }
}
