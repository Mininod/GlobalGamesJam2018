using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


     // transfer code 
    public float hp;
    public float soulTimer;
    private bool soulTimerActive;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {   
        if(soulTimerActive == true)
        {
            soulTimer -= Time.deltaTime;
            if(soulTimer<0)
            {
                soulTimerActive = false;
            }
            if (Input.GetKey(KeyCode.A))
            {
                GetComponent<movement>().Movement(false);
            }

            if (Input.GetKey(KeyCode.D))
            {
                GetComponent<movement>().Movement(true);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                GetComponent<movement>().Jump();
            }
        }
        else
        {
            print("rip boi");
        }
    }
}
