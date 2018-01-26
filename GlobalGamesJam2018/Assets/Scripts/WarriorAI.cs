using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorAI : MonoBehaviour {
    public float maxMovement;
    private float currentMovement;
    private bool moveRight;
    private bool canJump;
    private bool chase;

    private GameObject me;
   // private CircleCollider2D aggroRadius;
	// Use this for initialization
	void Start ()
    {
        moveRight = true;
        currentMovement = 0;

        //me = GetComponent<Movement>();

        //aggroRadius = gameObject.GetComponent<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right,2.0f);

        if (hit)
        {
            if(hit.collider.GetComponent<MyType>().mytype==MyType.objectTag.Player)
            {
                print("we Are attack");
            }
        }

        if (chase == true)
        {
            //movementScript
        }
        else
        {
            if (currentMovement < maxMovement)
            {
                ++currentMovement;
                // Run movement script
                // GetComponent<movement>();
                //GetComponent<movement>();
                gameObject.GetComponent<movement>().Movement(moveRight);
            }
            else
            {
                currentMovement = 0;
                moveRight = !moveRight;
            }
        }

	}

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<MyType>())
        {
            if (other.GetComponent<MyType>().mytype ==MyType.objectTag.Player)
            {
                chase = true;
                print("In Chase");
                
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<MyType>())
        {
            if (other.GetComponent<MyType>().mytype == MyType.objectTag.Player)
            {
                chase = true;

                if(gameObject.transform.position.x < other.transform.position.x)
                {
                    moveRight = true;
                    print("In Chase right");
                }
                //if player is jumping jump;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<MyType>())
        {
            if (other.GetComponent<MyType>().mytype != MyType.objectTag.Player)
            {
                chase = false;
            }
        }
    }
}
