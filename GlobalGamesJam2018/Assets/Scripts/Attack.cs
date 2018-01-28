using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    //private GameObject trigger;
    private BoxCollider2D trigger;
    public GameObject fireBall;
    private int damage = 20;
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

    public void StaffAttack(int rightamount)
    {
        if (gameObject.GetComponentInParent<MyType>())
        {
            if (gameObject.GetComponentInParent<MyType>().mytype == MyType.objectTag.Wizard)
            {
                Debug.Log("Fireball is go");
                //Instantiate(fireBall);
                GameObject foo = Instantiate(fireBall,new Vector2(gameObject.transform.position.x,gameObject.transform.position.y), Quaternion.identity);
                foo.GetComponent<Transform>().localScale = new Vector3(rightamount, transform.localScale.y, transform.localScale.z);
                foo.GetComponent<Rigidbody2D>().velocity = transform.right * rightamount * 10;
                foo.GetComponent<FireBall>().setSource(transform.parent.gameObject);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other1)
    {
        GameObject other = other1.gameObject;
        Debug.Log("Attack Trigger read");
            if (other.GetComponent<IsActivePlayer>() == true)
            {
                if (GetComponentInParent<IsActivePlayer>() == true)
                {
                    if (GetComponentInParent<IsActivePlayer>().getIsActivePlayer() == false)
                    {
                        if (other.GetComponent<IsActivePlayer>().getIsActivePlayer() == true)
                        {
                            other.GetComponent<Player>().takeDamage(damage); //magic number scrub //
                            Debug.Log("Hit");
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
                            other.GetComponent<AI>().takeDamage(damage); // maggic ass damage
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
