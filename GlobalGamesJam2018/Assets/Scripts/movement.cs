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
        if (gameObject.GetComponent<MyType>().mytype == MyType.objectTag.Player)
        {
            if (Input.GetKey(KeyCode.A))
            {
                Movement(false);
            }

            if (Input.GetKey(KeyCode.D))
            {
                Movement(true);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
            }
        }
        

	}

    internal void Movement(bool direction)
    {
        if (direction == false)
        {
            rb.velocity = new Vector3(-speed, rb.velocity.y);
        }
        else if (direction == true)
        {
            rb.velocity = new Vector3(speed, rb.velocity.y);
        }

    }

    internal void Jump()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, 0.5f); //Change "10" to change range;
        Debug.DrawRay(transform.position, -transform.up, Color.red);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.tag);
            if (hit.collider.gameObject.tag == "Floor")
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            }
        }
       
    }
}
