using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    public float speed;
    public Rigidbody2D rb;
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        if(Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(-speed, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(speed, 0);
        }

        else
        {
            rb.velocity = new Vector3(0, 0);
        }
        


        

	}
}
