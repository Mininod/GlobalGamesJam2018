using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {


    //internal Collider2D Source;
    private GameObject Source;
    private int damage;
    // Use this for initialization
    void Start ()
    {
        damage = 5;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject != Source) // source is past in when cannonball is created so it can't hit itself
        {
            if (other.GetType() == typeof(BoxCollider2D))
            {

                if (other.GetComponent<IsActivePlayer>() == true)
                {

                    if (other.GetComponent<IsActivePlayer>().getIsActivePlayer() == true)
                    {
                        other.GetComponent<Player>().takeDamage(DealDamage());
                    }
                }

                if (other.GetComponent<IsActivePlayer>() == true)
                {

                    if (other.GetComponent<IsActivePlayer>().getIsActivePlayer() != true)
                    {
                        Source.GetComponent<Player>().SetEnemyLastHit(other.gameObject);
                        Source.GetComponent<Player>().hitIndicator.SetActive(true);
                        Source.GetComponent<Player>().hitIndicator.GetComponent<lastHitIndicator>().lastHit = other.gameObject;
                        other.GetComponent<AI>().takeDamage(DealDamage());
                    }
                }
            }
            
        }

    }
    private int DealDamage()
    {

        Destroy(gameObject);
        return damage;
    }

    //public void setSource(Collider2D other)
    //{
    //    Source = other;
    //}
    public void setSource(GameObject other)
    {
        Source = other;
    }
}
