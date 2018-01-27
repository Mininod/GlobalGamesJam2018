using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsActivePlayer : MonoBehaviour {

    public bool ActivePlayer;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool getIsActivePlayer()
    {
        return ActivePlayer;
    }
    public void setActivePlayer()
    {
        ActivePlayer = !ActivePlayer;
    }
}
