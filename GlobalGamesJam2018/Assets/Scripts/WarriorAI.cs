using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorAI : MonoBehaviour {
    public float maxMovement;
    private float currentMovement;
    private bool moveRight;

	// Use this for initialization
	void Start ()
    {
        moveRight = true;
        currentMovement = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(currentMovement<maxMovement)
        {
            ++currentMovement;
            // Run movement script
        }
        else
        {
            currentMovement = 0;
            moveRight = !moveRight;
        }

	}
}
