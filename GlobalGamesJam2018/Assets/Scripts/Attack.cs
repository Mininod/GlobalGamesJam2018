using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    //private GameObject trigger;
    private BoxCollider2D trigger;
	// Use this for initialization
	void Start () {
		if(GetComponent<BoxCollider2D>())
        {
            trigger = gameObject.GetComponent<BoxCollider2D>();
            trigger.enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {

	}
 
    void ArrowAttack()
    {

    }

    public void SwordAttack()
    {
        if(gameObject.GetComponentInParent<MyType>())
        {
            if (gameObject.GetComponentInParent<MyType>().mytype==MyType.objectTag.Warrior)
            {
                //play animation 

                // activate hitbox
                trigger.enabled = true;
            }
        }
    }

    void WizardAttack()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<MyType>())
        {
            //if(other.GetComponent<MyType>().mytype == MyType.objectTag.Player)
            //{

            //}
            if (other.GetComponent<IsActivePlayer>() == true)
            {
                if (other.GetComponent<IsActivePlayer>().getIsActivePlayer() == true)
                {
                    other.GetComponent<Player>().takeDamage(5); //magic number scrub //
                    Debug.DrawRay(transform.position, transform.right, Color.red);
                }
            }
        }

        if (GetComponent<IsActivePlayer>().getIsActivePlayer() == true)
        {
            if (other.GetComponent<MyType>())
            {
                if (other.GetComponent<MyType>().mytype != MyType.objectTag.Floor)
                {
                    if(other.GetComponent<AI>())
                    {
                        other.GetComponent<AI>().takeDamage(5); // maggic ass damage
                        Debug.DrawRay(transform.position, transform.right, Color.red);
                    }
                }
            }
        }
    }
}
