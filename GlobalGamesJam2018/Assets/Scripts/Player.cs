﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{


    // transfer code 
    public float hp;
    public float soulTimer;
    private float maxSoulTimer;
    public float soulTransmitDistance;
    public GameObject hitIndicator;
    private bool soulTimerActive;
    private bool facingDirection;
    private GameObject enemyLastHit;
    private GameObject thiscamera;
    public float attackCD;
    private float curAttackCD;
    private bool attackOnCD;
    private bool pauseSoulTimer;
    private GameObject healthbar;
    public AudioClip soulTransfer;
    //UI
    private Slider SoulTimerUI;
    // Use this for initialization
    void Start()
    {
        healthbar = transform.GetChild(1).gameObject;
        GetComponent<SpriteRenderer>().color = new Color32(216, 144, 144, 255);
        thiscamera = Camera.main.gameObject;
        thiscamera.GetComponent<FollowPlayer>().setNewPlayer(gameObject);
        GetComponent<AI>().enabled = false;
        GetComponent<IsActivePlayer>().setActivePlayer();
        facingDirection = true;
        attackOnCD = false;
        pauseSoulTimer = false;
        if (soulTimer > 0)
        {
            soulTimerActive = true; //DELETE ME ONCE YOU NO LONGER NEED ME :,(
        }
        maxSoulTimer = soulTimer;
        SoulTimerUI = GameObject.Find("SoulSlider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        float vectorhpshit = hp / 100;
        Debug.Log(vectorhpshit);
        healthbar.transform.localScale = new Vector2(vectorhpshit, healthbar.transform.localScale.y);
        healthbar.transform.localPosition = new Vector2(-.62f - vectorhpshit, healthbar.transform.localPosition.y);

        if (soulTimerActive == true)
        {
            if (pauseSoulTimer == false)
            {
                soulTimer -= Time.deltaTime;
            }
            if (soulTimer < 0)
            {
                soulTimerActive = false;
                print("playerTimed out");
                SceneManager.LoadScene(3);
            }

            if (attackOnCD == true)
            {
                
                curAttackCD += Time.deltaTime;
                if (curAttackCD > attackCD)
                {
                    print("weCool");
                    curAttackCD = 0;
                    attackOnCD = false;
                }
            }
            if(hp<0)
            {
                SceneManager.LoadScene(3);
            }

            //UI update 
            print(maxSoulTimer);
            SoulTimerUI.value = soulTimer /maxSoulTimer;

            if (Input.GetKey(KeyCode.A))
            {
                facingDirection = false;
                GetComponent<movement>().Movement(false);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                facingDirection = true;
                GetComponent<movement>().Movement(true);
            }
            else
            {
                GetComponent<movement>().StopMovement();
            }

            if (Input.GetKey(KeyCode.Space))
            {
                GetComponent<movement>().Jump();
            }

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("CLICK");
                if (attackOnCD != true)
                {
                    print("we actually attack");
                    attackOnCD = true;
                    switch (gameObject.GetComponent<MyType>().mytype)
                    {
                        case MyType.objectTag.Warrior:
                            Debug.Log("PLAYER SWORD ATTACK");
                            GetComponentInChildren<Attack>().SwordAttack();
                            break;
                        case MyType.objectTag.Archer:
                            break;
                        case MyType.objectTag.Wizard:
                            int foo = 1;
                            if (!facingDirection)
                            {
                                foo = -1;
                            }
                            GetComponentInChildren<Attack>().StaffAttack(foo);
                            break;

                        default:
                            break;
                    }
                }
            }

            if(facingDirection==true)
            {
                GetComponent<Transform>().localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                GetComponent<Transform>().localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            }

            //debug
            //enemyLastHit = GameObject.Find("NamemeSomething"); //Make a way to find the enemy last hit
            //debug

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (enemyLastHit != null && enemyLastHit.activeInHierarchy)
                {
                    if (enemyLastHit.transform.position.x >= transform.position.x - soulTransmitDistance && enemyLastHit.transform.position.x <= transform.position.x + soulTransmitDistance)
                    {
                        Debug.Log("Good to transmit bb");
                        Debug.Log(enemyLastHit.name);
                        enemyLastHit.AddComponent<AudioSource>();
                        enemyLastHit.GetComponent<AudioSource>().clip = soulTransfer;
                        enemyLastHit.GetComponent<AudioSource>().Play();
                        enemyLastHit.AddComponent<Player>();
                        enemyLastHit.GetComponent<Player>().hp = enemyLastHit.GetComponent<AI>().GetHp();
                        enemyLastHit.GetComponent<Player>().hitIndicator = hitIndicator;
                        GetComponent<SpriteRenderer>().color = new Color32(255,255, 255, 255);
                        hitIndicator.SetActive(false);
                        GetComponent<AI>().enabled = true; //Sets This Gameobject to have AI
                        GetComponent<AI>().SetSoulTimer(soulTimer);
                        enemyLastHit.GetComponent<Player>().soulTransmitDistance = soulTransmitDistance;
                        enemyLastHit.GetComponent<Player>().soulTimer = enemyLastHit.GetComponent<AI>().GetSoulTimer() + ((enemyLastHit.GetComponent<AI>().GetSoulTimer() / (enemyLastHit.GetComponent<Player>().hp))*20);
                        enemyLastHit.GetComponent<AI>().enabled = false; //Disables AI of target
                        GetComponent<IsActivePlayer>().setActivePlayer();
                        enemyLastHit.GetComponent<Player>().enemyLastHit = null;
                        Destroy(GetComponent<Player>()); //Destory This Script 
                    }
                }
            }
        }
        else
        {
            print("rip boi");
        }
    }


    public void takeDamage(int damage)
    {
        hp -= damage;
    }

    public void SetEnemyLastHit(GameObject input)
    {
        enemyLastHit = input;
    }

    public void SetTimePause(bool input)
    {
        pauseSoulTimer = input;
    }

}
