using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorAI : MonoBehaviour {
    public float maxMovement;
    private float currentMovement;
    private bool moveRight;
    private bool canJump;
    private bool chase;
    private CircleCollider2D aggroRadius;
	// Use this for initialization
	void Start ()
    {
        moveRight = true;
        currentMovement = 0;
        aggroRadius = gameObject.GetComponent<CircleCollider2D>();
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

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }

    private void OnTriggerStay2D(Collision2D other)
    {

    }

    private void OnTriggerExit2D(Collider2D other)
    {

    }
}
