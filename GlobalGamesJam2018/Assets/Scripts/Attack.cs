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
        trigger.enabled = false;
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
            if (other.GetComponent<IsActivePlayer>() == true)
            {
                if (GetComponentInParent<IsActivePlayer>() == true)
                {
                    if (GetComponentInParent<IsActivePlayer>().getIsActivePlayer() == false)
                    {
                        if (other.GetComponent<IsActivePlayer>().getIsActivePlayer() == true)
                        {
                            other.GetComponent<Player>().takeDamage(5); //magic number scrub //
                        }
                    }
                }
            }

        if (GetComponentInParent<IsActivePlayer>() == true)     
        {
            if (GetComponentInParent<IsActivePlayer>().getIsActivePlayer() == true)
            {
                if (other.GetComponent<MyType>())
                {
                    if (other.GetComponent<MyType>().mytype != MyType.objectTag.Floor)
                    {
                        if (other.GetComponent<AI>())
                        {
                            Debug.Log("GET");
                            other.GetComponent<AI>().takeDamage(5); // maggic ass damage
                            GetComponentInParent<Player>().SetEnemyLastHit(other.gameObject);
                            GetComponentInParent<Player>().hitIndicator.SetActive(true);
                            GetComponentInParent<Player>().hitIndicator.GetComponent<lastHitIndicator>().lastHit = other.gameObject;
                        }
                    }
                }
            }
        }
        trigger.enabled = false;
    }
}
