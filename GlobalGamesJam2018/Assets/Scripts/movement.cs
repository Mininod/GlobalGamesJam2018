using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    public float speed;
    public Rigidbody2D rb;
    public float jumpSpeed;
    private bool isInput;
    
    
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down/*DISTANCE*/);

        if(Input.GetKey(KeyCode.A))
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
            isInput = true;
        }

        if (isInput == false)
        {
                       
        }

        isInput = false;
        


        

	}

    void Movement(bool direction)
    {
        if (direction == false)
        {
            rb.velocity = new Vector3(-speed, rb.velocity.y);
        }
        else if (direction == true)
        {
            rb.velocity = new Vector3(speed, rb.velocity.y);
        }

        isInput = true;
    }

    void Jump()
    {
        rb.velocity = new Vector2(transform.position.x, jumpSpeed);
    }
}
