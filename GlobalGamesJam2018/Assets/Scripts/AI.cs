using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {
    public float maxMovement;
    private float currentMovement;
    private bool moveRight;
    private bool canJump;
    private bool chase;
    private float soulTimer;
    private float hp;



    // Use this for initialization
    void Start ()
    {
        soulTimer = 10; 
        hp = 10;
        Debug.Log("SOUL TIME AND HP SET TO 10 IN START FOR DEBUGGING");
        moveRight = true;
        currentMovement = 0;
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right,2.0f);
        
        if (hit)
        {
            if (hit.collider.GetComponent<MyType>() == true)
            {
                if (hit.collider.GetComponent<MyType>().mytype == MyType.objectTag.Player)
                {
                    print("we Are attack");
                }
            }
        }

        if (chase == true)
        {
            //movementScript
            gameObject.GetComponent<movement>().Movement(moveRight);
        }
        else
        {
            if (currentMovement < maxMovement)
            {
                ++currentMovement;
                gameObject.GetComponent<movement>().Movement(moveRight);
            }
            else
            {
                currentMovement = -maxMovement;
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
                    
                }
                if (gameObject.transform.position.x > other.transform.position.x)
                {
                    moveRight = false;
                    
                }
                //if player is jumping jump;
                if (other.GetComponent<movement>())
                {
                    if (other.GetComponent<movement>().OnFloor() == false)
                    {
                        gameObject.GetComponent<movement>().Jump();
                    }
                }

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

    public float GetSoulTimer()
    {
        return soulTimer;
    }

    public float GetHp()
    {
        return hp;
    }
}
