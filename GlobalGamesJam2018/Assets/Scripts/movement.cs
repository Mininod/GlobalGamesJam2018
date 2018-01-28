using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb;
    public float jumpSpeed;
    
    
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        

    }

    internal void Movement(bool direction)
    {
        float speedMulti = 1;
        if (!GetComponent<IsActivePlayer>().getIsActivePlayer())
        {
            speedMulti = 0.5f;
        }
        if (direction == false)
        {
            rb.velocity = new Vector3(-speed * speedMulti, rb.velocity.y);
        }
        else if (direction == true)
        {
            rb.velocity = new Vector3(speed * speedMulti, rb.velocity.y);
        }
        
    }

    internal void StopMovement()
    {
        rb.velocity = new Vector3(0, rb.velocity.y);
    }

    internal void Jump()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + (GetComponent<SpriteRenderer>().bounds.size.x / 2), transform.position.y), -transform.up, (GetComponent<SpriteRenderer>().bounds.size.y / 2)+0.1f); //Change "10" to change range;

        if (hit.collider != null && hit.collider.GetComponent<MyType>().mytype == MyType.objectTag.Floor)
        {
            if (hit.collider.GetComponent<MyType>())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            }
        }
        else
        {
            hit = Physics2D.Raycast(new Vector2(transform.position.x -(GetComponent<SpriteRenderer>().bounds.size.x / 2), transform.position.y) , -transform.up, (GetComponent<SpriteRenderer>().bounds.size.y / 2) + 0.1f);

            if (hit.collider != null && hit.collider.GetComponent<MyType>())
            {
                if (hit.collider.GetComponent<MyType>().mytype == MyType.objectTag.Floor)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                }
            }
        }
       

    }

    internal bool OnFloor()
    {
        Debug.Log("onFloor");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, (GetComponent<SpriteRenderer>().bounds.size.y / 2) + 0.1f); //Change "10" to change range;

        if (hit.collider != null && hit.collider.GetComponent<MyType>())
        {
            if (hit.collider.GetComponent<MyType>().mytype == MyType.objectTag.Floor)
            {
                return true; 
            }
        }
      
        return false;
        
    }


}
