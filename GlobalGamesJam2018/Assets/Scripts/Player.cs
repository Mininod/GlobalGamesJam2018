using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    //UI
    private Slider SoulTimerUI;
    // Use this for initialization
    void Start()
    {
        thiscamera = Camera.main.gameObject;
        thiscamera.GetComponent<FollowPlayer>().setNewPlayer(gameObject);
        GetComponent<AI>().enabled = false;
        GetComponent<IsActivePlayer>().setActivePlayer();
        facingDirection = true;
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
        if (soulTimerActive == true)
        {
            soulTimer -= Time.deltaTime;
            if (soulTimer < 0)
            {
                soulTimerActive = false;
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
                switch (gameObject.GetComponent<MyType>().mytype)
                {
                    case MyType.objectTag.Warrior:
                        Debug.Log("PLAYER SWORD ATTACK");
                        GetComponentInChildren<Attack>().SwordAttack();
                        break;
                    case MyType.objectTag.Archer:
                        break;
                    case MyType.objectTag.Wizard:
                        break;

                    default:
                        break;
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
                if (enemyLastHit != null)
                {
                    if (enemyLastHit.transform.position.x >= transform.position.x - soulTransmitDistance && enemyLastHit.transform.position.x <= transform.position.x + soulTransmitDistance)
                    {
                        Debug.Log("Good to transmit bb");
                        Debug.Log(enemyLastHit.name);
                        enemyLastHit.AddComponent<Player>();
                        enemyLastHit.GetComponent<Player>().hp = enemyLastHit.GetComponent<AI>().GetHp();
                        enemyLastHit.GetComponent<Player>().hitIndicator = hitIndicator;
                        hitIndicator.SetActive(false);
                        GetComponent<AI>().enabled = true; //Sets This Gameobject to have AI
                        GetComponent<AI>().SetSoulTimer(soulTimer);
                        enemyLastHit.GetComponent<Player>().soulTransmitDistance = soulTransmitDistance;
                        enemyLastHit.GetComponent<Player>().soulTimer = enemyLastHit.GetComponent<AI>().GetSoulTimer();
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

}
