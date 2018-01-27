﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {
    public float maxMovement;
    private float currentMovement;
    private bool moveRight;
    private bool canJump;
    public bool chase;
    public bool inAttackRange;
    private float soulTimer;
    private float hp;
    private int facingMultiplier;
    private GameObject player;



    // Use this for initialization
    void Start ()
    {
        soulTimer = 1000; 
        hp = 10;
        Debug.Log("SOUL TIME AND HP SET TO 10 IN START FOR DEBUGGING");
        moveRight = true;
        currentMovement = 0;
        inAttackRange = false;
        facingMultiplier = 1;
    }
    void OnEnable()
    {
        moveRight = true;
        currentMovement = 0;
        inAttackRange = false;
        facingMultiplier = 1;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (player != null)
        {
            if (player.GetComponent<IsActivePlayer>().getIsActivePlayer() == true && chase == true)
            {
                Debug.Log("Run555");
                chase = true;

                if (gameObject.transform.position.x < player.transform.position.x)
                {
                    facingMultiplier = 1;
                    gameObject.GetComponent<movement>().Movement(true);

                }
                if (gameObject.transform.position.x > player.transform.position.x)
                {
                    facingMultiplier = -1;
                    gameObject.GetComponent<movement>().Movement(false);

                }
            }
        }




            switch (gameObject.GetComponent<MyType>().mytype)
        {
            case MyType.objectTag.Player:
                break;
            case MyType.objectTag.Warrior:

                RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(transform.position.x + transform.right.x, transform.position.y) * facingMultiplier, 2.0f);
                //Debug.DrawLine(transform.position, transform.right);
                Debug.Log(transform.right);
                Debug.DrawRay(transform.position, transform.right, Color.blue);

                if (hit)
                {
                    if (!hit.collider.isTrigger && hit.collider.GetComponent<IsActivePlayer>() == true && hit.collider.GetComponent<IsActivePlayer>().getIsActivePlayer() == true)
                    {
                         print("we Are attack");
                         inAttackRange = true;
                         GetComponentInChildren<Attack>().SwordAttack();
                    }
                    else
                    {
                        inAttackRange = false;
                    }
                }
                else
                {
                    inAttackRange = false;
                }
                if (chase == false)
                    {
                        if (currentMovement < maxMovement)
                        {
                            ++currentMovement;
                            gameObject.GetComponent<movement>().Movement(moveRight);

                        }
                        else
                        {
                            currentMovement = -maxMovement;
                            //GetComponent<Transform>().localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                            moveRight = !moveRight;
                        }
                    }
                GetComponent<Transform>().localScale = new Vector3(facingMultiplier, transform.localScale.y, transform.localScale.z);

                break;
            case MyType.objectTag.Archer:
                break;
            case MyType.objectTag.Wizard:
                break;
            case MyType.objectTag.Floor:
                break;
            default:
                break;
        }

        

    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<IsActivePlayer>())
        {
            if (other.GetComponent<IsActivePlayer>().getIsActivePlayer() == true)
            {
                chase = true;
   
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<IsActivePlayer>())
        {
            if (other.GetComponent<IsActivePlayer>().getIsActivePlayer() == true)
            {
                player = other.gameObject;
            }

            if (player != null && player.GetComponent<IsActivePlayer>().getIsActivePlayer() == true)
            {
                chase = true;

                if (other.GetComponent<movement>())
                {
                    if (other.GetComponent<movement>().OnFloor() == false)
                    {
                        gameObject.GetComponent<movement>().Jump();
                    }
                }

            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<IsActivePlayer>())
        {
            if (other.GetComponent<IsActivePlayer>().getIsActivePlayer() == true)
            {
                chase = false;
                inAttackRange = false;
            }
        }
    }

    public float GetSoulTimer()
    {
        return soulTimer;
    }

    public float GetHp()
    {
        return hp;
    }

    public void SetSoulTimer(float soulTime)
    {
        soulTimer = soulTime;
    }

    public void SetHp(float health)
    {
        hp = health;
    }

    public void takeDamage(int damage)
    {
        hp -= damage;
    }
}
