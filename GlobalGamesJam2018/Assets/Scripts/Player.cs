using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


     // transfer code 
    public float hp;
    public float soulTimer;
    public float soulTransmitDistance;
    private bool soulTimerActive;
    public GameObject enemyLastHit;
	// Use this for initialization
	void Start () {
        if (soulTimer > 0)
        {
            soulTimerActive = true; //DELETE ME ONCE YOU NO LONGER NEED ME :,(
        }

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (soulTimerActive == true)
        {
            soulTimer -= Time.deltaTime;
            if (soulTimer < 0)
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

            if (Input.GetKey(KeyCode.F))
            {
                if (enemyLastHit.transform.position.x >= transform.position.x - soulTransmitDistance && enemyLastHit.transform.position.x <= transform.position.x + soulTransmitDistance)
                {
                    Debug.Log("Good to transmit bb"); 
                }
            }
        }
        else
        {
            print("rip boi");
        }
    }
}
